using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TqkLibrary.Gologin.Api.Enums;

namespace TqkLibrary.Gologin.Api
{
    /// <summary>
    /// 
    /// </summary>
    public static class Extensions
    {
        static readonly Random random = new Random();

        internal static int RandomNum { get { return random.Next(0, int.MaxValue); } }

        internal static int GetRandomNum(int min, int max)
        {
            return random.Next(min, max + 1);
        }
        internal static int GetRandomParams(params int[] @params)
        {
            return @params[random.Next(@params.Length)];
        }
        internal static IEnumerable<T> Concat<T>(this IEnumerable<T> input, params T[] input2)
        {
            foreach (var item in input) yield return item;
            foreach (var item in input2) yield return item;
        }




        public static ProfileConfig ConvertToProfileConfig(this FingerprintResponse fingerprintResponse)
        {
            if (fingerprintResponse is null) throw new ArgumentNullException(nameof(fingerprintResponse));

            ProfileConfig profileConfig = new ProfileConfig();
            profileConfig.Navigator = fingerprintResponse.Navigator;
            profileConfig.Canvas = fingerprintResponse.Canvas;
            profileConfig.MediaDevices = fingerprintResponse.MediaDevices;
            profileConfig.WebRTC = fingerprintResponse.WebRTC;
            profileConfig.WebGLMetadata = fingerprintResponse.WebGLMetadata;
            profileConfig.WebGL = fingerprintResponse.WebGL;
            profileConfig.ClientRects = fingerprintResponse.ClientRects;
            profileConfig.WebglParams = fingerprintResponse.WebglParams;
            profileConfig.Os = fingerprintResponse.Os;
            profileConfig.DevicePixelRatio = fingerprintResponse.DevicePixelRatio;
            profileConfig.Fonts = new Fonts()
            {
                Families = fingerprintResponse.Fonts,
                EnableMasking = true,
                EnableDomRect = true,
            };

            //profileConfig.Navigator.DeviceMemory = profileConfig.Navigator.DeviceMemory * 1024;
            if (profileConfig.WebGLMetadata is not null)
                profileConfig.WebGLMetadata.Mode = profileConfig.WebGLMetadata.Mode == WebGLMetadataMode.noise ? WebGLMetadataMode.mask : WebGLMetadataMode.off;
            if (profileConfig.WebRTC is not null)
                profileConfig.WebRTC.Mode = WebRTCMode.alerted;

            profileConfig.BrowserType = "chrome";
            profileConfig.GoogleServicesEnabled = false;
            if ("win".Equals(profileConfig.Os)) profileConfig.IsM1 = false;
            profileConfig.LockEnabled = false;
            profileConfig.DebugMode = false;
            profileConfig.Storage = new Storage()
            {
                Local = true,
                Extensions = true,
                Bookmarks = true,
                History = true,
                Passwords = true,
                Session = true,
            };
            profileConfig.ProxyEnabled = false;
            profileConfig.Proxy = new Proxy()
            {
                AutoProxyRegion = "us",
                Host = String.Empty,
                Mode = ProxyMode.none,
                Password = String.Empty,
                Port = 80,
                TorProxyRegion = "us",
                Username = String.Empty,
            };
            profileConfig.Dns = "";
            profileConfig.Plugins = new Plugins()
            {
                EnableFlash = false,
                EnableVulnerable = true,
            };
            profileConfig.Timezone = new Timezone()
            {
                Enabled = true,
                FillBasedOnIp = true,
                TimeZone = String.Empty,
            };
            profileConfig.Plugins = new Plugins()
            {
                EnableFlash = true,
                EnableVulnerable = true,
            };

            profileConfig.Geolocation = new Geolocation()
            {
                Mode = GeolocationMode.prompt,
                Enabled = true,
                FillBasedOnIp = true,
                Customize = true,
                Latitude = 0,
                Longitude = 0,
                Accuracy = 10,
            };
            profileConfig.Extensions = new Extension()
            {
                Enabled = true,
                Names = new List<string>() { },
                PreloadCustom = true,
            };
            profileConfig.AudioContext = new AudioContext()
            {
                Mode = AudioContextMode.noise
            };
            profileConfig.Cookies = new object[] { };
            profileConfig.GoogleClientId = String.Empty;
            //profileConfig.Profile = "ProfileAutoGenerate";
            profileConfig.Name = "ProfileAutoGenerate";
            profileConfig.Notes = "ProfileAutoGenerate";
            //profileConfig.UpdateExtensions = false;
            //profileConfig.ChromeExtensions = new List<string>() { };

            profileConfig.UserChromeExtensions = new List<string>() { };
            profileConfig.UserChromeExtensionsToNewProfiles = new List<object>() { };
            return profileConfig;
        }



        public static string GeneratePreferences(this ProfileResponse profileResponse)
        {

        }
    }
}
