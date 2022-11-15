using System.Diagnostics;
using TqkLibrary.Gologin.Api;

//acc abasda2c
#if DEBUG
string access_token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiI2MzcxYTgxYzI2MGQ0YzJlNzY4OTJhM2YiLCJ0eXBlIjoiZGV2Iiwiand0aWQiOiI2MzcxYmFhZjQ0ZGY2ZmIyMTM5N2FhOGUifQ.ovMSCzT5u7Dileq2uDa5sHJHfieXLLTTKDFZTaQQyN8";
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
while (true)
{
    ProfileResponse? profile = null;
    try
    {
        Console.WriteLine("Fingerprint.GetNew");
        var fingerprint = await gologinApi.Fingerprint.GetNew("win");

        ProfileConfig profileConfig = fingerprint.ConvertToProfileConfig();

        Console.WriteLine("Profile.Create");
        profile = await gologinApi.Profile.Create(profileConfig);

        while (!CheckOrbita())//wait until opening
        {
            Console.WriteLine($"LocalApi.StartProfile: {profile?.Id}");
            await gologinApi.LocalApi.StartProfile(profile.Id, true);
            await Task.Delay(1000);
        }

        Console.WriteLine($"Get Profile Preferences");
        GetProfilePreferences(profile.Id);

    }
    catch(GologinException ge)
    {
        Console.WriteLine($"{ge.GetType().FullName}: {ge.Message}");
        foreach(var err in ge.GologinError.Errors)
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
            while (CheckOrbita())//wait until closed
            {
                Console.WriteLine($"LocalApi.StopProfile");
                await gologinApi.LocalApi.StopProfile(profile.Id);
                await Task.Delay(1000);
            }

            await Task.Delay(1000);
            Console.WriteLine($"Profile.Delete: {profile.Id}");
            await gologinApi.Profile.Delete(profile.Id);

            profile = null;
        }
    }
}

//true  = opening
bool CheckOrbita()
{
    IEnumerable<Process> process = Process.GetProcessesByName("chrome");
    process = process.Where(x =>
    {
        try
        {
            return x.MainModule.FileName.IndexOf("orbita", StringComparison.OrdinalIgnoreCase) >= 0;
        }
        catch
        {
            return false;
        }
    }).ToList();
    return process.Count() > 0;
}

void GetProfilePreferences(string profileID)
{
    string path = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
        "Temp\\GoLogin\\profiles",
        profileID,
        "Default\\Preferences");

    if (File.Exists(path))
    {
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