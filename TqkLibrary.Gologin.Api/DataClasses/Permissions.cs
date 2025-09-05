using Newtonsoft.Json;

namespace TqkLibrary.Gologin.Api.DataClasses
{
    public class Permissions
    {
        [JsonProperty("transferProfile")]
        public bool? TransferProfile { get; set; }

        [JsonProperty("transferToMyWorkspace")]
        public bool? TransferToMyWorkspace { get; set; }

        [JsonProperty("shareProfile")]
        public bool? ShareProfile { get; set; }

        [JsonProperty("manageFolders")]
        public bool? ManageFolders { get; set; }

        [JsonProperty("editProfile")]
        public bool? EditProfile { get; set; }

        [JsonProperty("deleteProfile")]
        public bool? DeleteProfile { get; set; }

        [JsonProperty("cloneProfile")]
        public bool? CloneProfile { get; set; }

        [JsonProperty("exportProfile")]
        public bool? ExportProfile { get; set; }

        [JsonProperty("updateUA")]
        public bool? UpdateUA { get; set; }

        [JsonProperty("addVpnUfoProxy")]
        public bool? AddVpnUfoProxy { get; set; }

        [JsonProperty("runProfile")]
        public bool? RunProfile { get; set; }

        [JsonProperty("runProfileWeb")]
        public bool? RunProfileWeb { get; set; }

        [JsonProperty("viewProfile")]
        public bool? ViewProfile { get; set; }

        [JsonProperty("addProfileTag")]
        public bool? AddProfileTag { get; set; }

        [JsonProperty("removeProfileTag")]
        public bool? RemoveProfileTag { get; set; }

        [JsonProperty("viewShareLinks")]
        public bool? ViewShareLinks { get; set; }

        [JsonProperty("createShareLinks")]
        public bool? CreateShareLinks { get; set; }

        [JsonProperty("updateShareLinks")]
        public bool? UpdateShareLinks { get; set; }

        [JsonProperty("deleteShareLinks")]
        public bool? DeleteShareLinks { get; set; }

        [JsonProperty("viewCustomExtensions")]
        public bool? ViewCustomExtensions { get; set; }
    }
}
