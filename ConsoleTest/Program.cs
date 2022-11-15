using TqkLibrary.Gologin.Api;

string access_token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiI2MzcxYTgxYzI2MGQ0YzJlNzY4OTJhM2YiLCJ0eXBlIjoiZGV2Iiwiand0aWQiOiI2MzcxYmFhZjQ0ZGY2ZmIyMTM5N2FhOGUifQ.ovMSCzT5u7Dileq2uDa5sHJHfieXLLTTKDFZTaQQyN8";
using GologinApi gologinApi = new GologinApi(access_token);

var fingerprint = await gologinApi.Fingerprint.GetNew("win", "1600x900");

ProfileConfig profileConfig = fingerprint.ConvertToProfileConfig();
var profile = await gologinApi.Profile.Create(profileConfig);




Console.ReadLine();