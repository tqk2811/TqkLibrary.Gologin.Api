using System.Collections.Generic;
using TqkLibrary.Gologin.Api.DataClasses;
using TqkLibrary.Gologin.Api.Enums;

namespace TqkLibrary.Gologin.Api
{
    public partial class ProfileConfig
    {
        /// <summary>
        /// 
        /// </summary>
        public static ProfileConfig ChromeWindow
        {
            get
            {
                ProfileConfig profileConfig = new ProfileConfig()
                {
                    BrowserType = "chrome",
                    Os = "win",
                    Dns = "8.8.8.8",
                    ProxyEnabled = false,
                    Proxy = null,
                    Navigator = new Navigator()
                    {
                        DeviceMemory = TqkLibrary.Gologin.Api.Extensions.GetRandomParams(1, 2, 4, 6, 8),
                        HardwareConcurrency = TqkLibrary.Gologin.Api.Extensions.GetRandomNum(1, 32),
                        DoNotTrack = true,
                        MaxTouchPoints = TqkLibrary.Gologin.Api.Extensions.GetRandomNum(1, 2),
                        Language = "en-US,en;q=0.9",
                        Platform = "Win32",
                        Resolution = "1600x900",
                        UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/105.0.5195.102 Safari/537.36",
                    },
                    Canvas = new Canvas(),
                    AudioContext = new AudioContext(),
                    ClientRects = new ClientRects(),
                    //Storage = new Storage()
                    //{
                    //    Extensions = true,
                    //    Bookmarks = true,
                    //    History = true,
                    //    Local = true,
                    //    Passwords = true,
                    //    Session = true
                    //},
                    DebugMode = false,
                    GoogleServicesEnabled = false,
                    LockEnabled = false,
                    Name = "New Profile",
                    Plugins = new Plugins()
                    {
                        EnableFlash = false,
                        EnableVulnerable = true
                    },
                    Timezone = new Timezone()
                    {
                        Enabled = true,
                        FillBasedOnIp = true,
                        TimeZone = "+07:00",
                    },
                    GeoProxyInfo = null,
                    Fonts = new Fonts()
                    {
                        EnableDomRect = true,
                        EnableMasking = true,
                        Families = new List<string>()
                        {

                        }
                    },
                    GoogleClientId = null,
                    MediaDevices = new MediaDevices()
                    {
                        AudioInputs = 0,
                        AudioOutputs = 0,
                        EnableMasking = false,
                        VideoInputs = 0,
                    },
                    WebRTC = new WebRTC()
                    {
                        Enabled = false,
                        Mode = WebRTCMode.alerted,
                        Customize = true,
                        LocalIpMasking = false,
                        FillBasedOnIp = true,
                        LocalIps = new List<string>()
                        {
                            "127.0.0.1"
                        }
                    },
                    WebGL = new WebGL()
                    {
                        GetClientRectsNoise = 0,
                    },
                    WebGLMetadata = new WebGLMetadata()
                    {
                        Mode = WebGLMetadataMode.mask,
                        Vendor = "WebKit",
                        Renderer = "WebKit WebGL",
                    },
                    UpdateExtensions = false,
                    Geolocation = new Geolocation()
                    {
                        Mode = GeolocationMode.block,
                        Enabled = false,
                        Customize = false,
                        FillBasedOnIp = true,
                        Accuracy = 0,
                    }
                };

                return profileConfig;
            }
        }

    }
}
