using Newtonsoft.Json;
using System.Diagnostics;
using System.Management;
using TqkLibrary.Gologin.Api;

Console.OutputEncoding = System.Text.Encoding.UTF8;
//acc abasda2c
#if DEBUG
string access_token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiI2MzkxOGU4MjZlYjkwNDgyMGI4Y2UwZTciLCJ0eXBlIjoiZGV2Iiwiand0aWQiOiI2MzkxOTE1NDM0NDJkYTFkNzVmMjgzZDIifQ.COrtpjHBjG3v7GvnWl36Yif_NCj_RdPkwK2nsIfZNIY";
#else
string access_token = args.FirstOrDefault();
while (string.IsNullOrWhiteSpace(access_token))
{
    Console.WriteLine("Nhập AccessToken:");
    access_token = Console.ReadLine();
}
#endif
using GologinApi gologinApi = new GologinApi(access_token);

Directory.CreateDirectory("Preferences");
Directory.CreateDirectory("Fingerprints");
while (true)
{
    ProfileResponse? profile = null;
    try
    {
        Console.WriteLine("Fingerprint.GetNew");
        var fingerprint = await gologinApi.Fingerprint.GetNew("win");
        SaveFingerprint(fingerprint);


        ProfileConfig profileConfig = fingerprint.ConvertToProfileConfig();
        //profileConfig.Proxy.Host = "127.0.0.1";
        //profileConfig.Proxy.Host = "15625";
        //profileConfig.Proxy.Username = "admin";
        //profileConfig.Proxy.Password = "password123";
        //profileConfig.Proxy.Mode = TqkLibrary.Gologin.Api.Enums.ProxyMode.http;


        Console.WriteLine("Profile.Create");
        profile = await gologinApi.Profile.Create(profileConfig);

        profile = await gologinApi.Profile.Get(profile.Id);
        while (!CheckOrbita(profile.Id))//wait until opening
        {
            Console.WriteLine($"LocalApi.StartProfile: {profile?.Id}");
            await gologinApi.LocalApi.StartProfile(profile.Id, true);
            await Task.Delay(1000);
        }

        Console.WriteLine($"Get Profile Preferences");
        await GetProfilePreferences(profile.Id);

    }
    catch (GologinException ge)
    {
        Console.WriteLine($"{ge.GetType().FullName}: {ge.Message}");
        foreach (var err in ge.GologinError.Errors)
        {
            Console.WriteLine($"\t-{err.Property}: {err.Messages}");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"{ex.GetType().FullName}: {ex.Message}, {ex.StackTrace}");
        await Task.Delay(2000);
    }
    finally
    {
        if (!string.IsNullOrWhiteSpace(profile?.Id))
        {
            int loopCount = 0;
            while (CheckOrbita(profile.Id))//wait until closed
            {
                Console.WriteLine($"LocalApi.StopProfile");
                try
                {
                    await gologinApi.LocalApi.StopProfile(profile.Id);
                }

                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.GetType().FullName}: {ex.Message}, {ex.StackTrace}");
                }
                await Task.Delay(500);
                loopCount++;
                if (loopCount > 10)
                {
                    KillProcess(GetProcessIdOrbita(profile.Id));
                    await Task.Delay(500);
                }
                else await Task.Delay(500);
            }

            await Task.Delay(1000);
            Console.WriteLine($"Profile.Delete: {profile.Id}");
            try
            {
                await gologinApi.Profile.Delete(profile.Id);
            }

            catch (Exception ex)
            {
                Console.WriteLine($"{ex.GetType().FullName}: {ex.Message}, {ex.StackTrace}");
            }
            profile = null;
        }
        Console.WriteLine();
        Console.WriteLine("---------------------------------------");
        Console.WriteLine();
    }
}

//true  = opening
bool CheckOrbita(string id)
{
    return GetProcessIdOrbita(id) != 0;
}
uint GetProcessIdOrbita(string id)
{
    try
    {
        string wmiQuery = "select ProcessId,ExecutablePath,CommandLine from Win32_Process where Name='chrome.exe'";
        using ManagementObjectSearcher searcher = new ManagementObjectSearcher(wmiQuery);
        using ManagementObjectCollection retObjectCollection = searcher.Get();
        foreach (ManagementObject retObject in retObjectCollection)
        {
            try
            {
                string ExecutablePath = retObject["ExecutablePath"].ToString();
                string CommandLine = retObject["CommandLine"].ToString();
                uint ProcessId = (uint)retObject["ProcessId"];
                if (ExecutablePath.IndexOf("orbita", StringComparison.OrdinalIgnoreCase) >= 0 &&
                    CommandLine.IndexOf(id, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    return ProcessId;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.GetType().FullName}: {ex.Message}, {ex.StackTrace}");
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"{ex.GetType().FullName}: {ex.Message}, {ex.StackTrace}");
    }
    return 0;
}

async Task GetProfilePreferences(string profileID)
{
    string path = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
        "Temp\\GoLogin\\profiles",
        profileID,
        "Default\\Preferences");
    FileInfo fileInfo = new FileInfo(path);

    if (File.Exists(path))
    {
        while (true)
        {
            fileInfo.Refresh();
            if (fileInfo.Length > 30 * 1024) //> 30KiB
                break;
            await Task.Delay(500);
        }


        int i = 0;
        string fileName = string.Empty;
        do
        {
            fileName = Path.Combine(Directory.GetCurrentDirectory(), "Preferences", $"{i:000000000}.json");
            i++;
        }
        while (File.Exists(fileName));

        File.Copy(path, fileName);
    }
    else
    {
        Console.WriteLine($"Profile: {profileID}, Preferences not found");
    }
}

void SaveFingerprint(FingerprintResponse fingerprintResponse)
{
    int i = 0;
    string fileName = string.Empty;
    do
    {
        fileName = Path.Combine(Directory.GetCurrentDirectory(), "Fingerprints", $"{i:000000000}.json");
        i++;
    }
    while (File.Exists(fileName));

    File.WriteAllText(fileName, JsonConvert.SerializeObject(fingerprintResponse));
}

void KillProcess(uint processId)
{
    Console.WriteLine($"Kill {processId}");
    using Process process = Process.Start(new ProcessStartInfo()
    {
        FileName = "taskkill",
        Arguments = $"/f /PID {processId}",
        CreateNoWindow = true,
        WindowStyle = ProcessWindowStyle.Hidden
    });
    process.WaitForExit();
}