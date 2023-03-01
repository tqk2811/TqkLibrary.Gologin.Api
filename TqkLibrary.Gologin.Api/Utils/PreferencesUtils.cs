using Newtonsoft.Json;
using System;
using System.IO;
using System.IO.Compression;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TqkLibrary.Gologin.Api.Enums;

namespace TqkLibrary.Gologin.Api.Utils
{
    public static class PreferencesUtils
    {
        public static async Task<string> GeneratePreferences(this ProfileResponse profileResponse)
        {
            if (profileResponse is null) throw new ArgumentNullException(nameof(profileResponse));

#if NET5_0_OR_GREATER || NETSTANDARD || NETCOREAPP
            bool isDiffOs = "android".Equals(profileResponse.Os) ? true : RuntimeInformation.IsOSPlatform(profileResponse.Os switch
            {
                "win" => OSPlatform.Windows,
                "lin" => OSPlatform.Linux,
                "mac" => OSPlatform.OSX,
                _ => throw new NotSupportedException($"unknow os type {profileResponse.Os}")
            });
#else
            bool isDiffOs = "win".Equals(profileResponse.Os, StringComparison.OrdinalIgnoreCase);
#endif
            string resolution = profileResponse.Navigator?.Resolution ?? "1920x1080";
            string language = profileResponse.Navigator?.Language ?? "en-US,en;q=0.9";

            dynamic raw_preferences = JsonConvert.DeserializeObject(GetRawPreferences());
            //extension

            switch (profileResponse.Proxy?.Mode)
            {
                case ProxyMode.gologin:
                case ProxyMode.tor:
                    break;

                case ProxyMode.geolocation:
                    //mode = ProxyMode.http;
                    break;

                default:
                    break;
            }







            return string.Empty;
        }


        internal static string GetRawPreferences()
        {
            using MemoryStream zero_profile = new MemoryStream(Resource.zero_profile);
            using ZipArchive zipArchive = new ZipArchive(zero_profile, ZipArchiveMode.Read, true, Encoding.UTF8);
            var preferencesEntry = zipArchive.GetEntry("Default\\Preferences");
            using Stream preferencesEntryStream = preferencesEntry.Open();
            using StreamReader preferencesEntryStreamReaderr = new StreamReader(preferencesEntryStream);
            return preferencesEntryStreamReaderr.ReadToEnd();
        }

        internal static void ExtractTo(this ZipArchive zipArchive, string directory)
        {
            if (zipArchive is null) throw new ArgumentNullException(nameof(zipArchive));
            if (string.IsNullOrWhiteSpace(directory)) throw new ArgumentNullException(nameof(directory));
            if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);

            foreach (var entry in zipArchive.Entries)
            {
                FileInfo fileInfo = new FileInfo(Path.Combine(directory, entry.FullName));
                fileInfo.Directory.Create();
                entry.ExtractToFile(fileInfo.FullName, true);
            }
        }

        //static async Task GetTimeZone(this Proxy proxy)
        //{
        //    if (proxy is null || proxy.Mode == ProxyMode.none) return;
        //    NameValueCollection nameValueCollection = HttpUtility.ParseQueryString(string.Empty);
        //    using HttpClient httpClient = new HttpClient();
        //    using HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "https://time.gologin.com/timezone");
        //}
    }
}
