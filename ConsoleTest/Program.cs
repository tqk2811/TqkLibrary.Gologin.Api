using ConsoleTest;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Management;
using TqkLibrary.Gologin.Api;
using TqkLibrary.Gologin.Api.Exceptions;

Console.OutputEncoding = System.Text.Encoding.UTF8;
//acc abasda2c
#if DEBUG
string access_token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiI2OGI5MGMwYzE4YzhiMDc1ZmJhOTg2M2UiLCJ0eXBlIjoiZGV2Iiwiand0aWQiOiI2OGI5NDZlNWVkYWIxMmQyMzFiMDhmMmEifQ.EtCHGaYUwzi8U1yS6b-qAYhIi7t-MvaPKFGMIScQsvA";
#else
string access_token = args.FirstOrDefault();
while (string.IsNullOrWhiteSpace(access_token))
{
    Console.WriteLine("Nhập AccessToken:");
    access_token = Console.ReadLine();
}
#endif
using GologinApi gologinApi = new GologinApi(access_token);

//await gologinApi.CrawlerAsync();

var profiles = await gologinApi.Profile.GetAll.RequestAsync();
var proxys = await gologinApi.Profile.UpdateProxies.RequestAsync(new UpdateProxiesRequest()
{
    Proxies = [
        new ProfileProxyUpdate()
        {
            ProfileId =profiles.Profiles.First().Id,
            Proxy = new Proxy()
            {
                Host = "192.168.1.8",
                Port = 28111,
                Username = null,
                Mode = TqkLibrary.Gologin.Api.Enums.ProxyMode.http,
            }
        }
    ]
});
await gologinApi.Local.StartProfile.RequestAsync(new ProfileStartQuery() { Id = profiles.Profiles!.First().Id, IsSync = true });

Console.ReadLine();