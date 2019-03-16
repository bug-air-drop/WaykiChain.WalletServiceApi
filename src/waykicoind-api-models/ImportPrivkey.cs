using Newtonsoft.Json;

namespace WalletServiceApi.JsonRpc
{
    public class ImportPrivkey
    {
        [JsonProperty(PropertyName = "imorpt key address")]
        public string imorptkeyaddress { get; set; }
    }
}
