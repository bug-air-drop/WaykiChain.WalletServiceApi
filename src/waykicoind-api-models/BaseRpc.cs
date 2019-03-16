using Newtonsoft.Json;

namespace WalletServiceApi.JsonRpc
{
    public class BaseRpc
    {
        public string jsonrpc { get; set; } = "2.0";
        public string id { get; set; } = "curltext";
        public string method { get; set; }

        [JsonProperty(PropertyName = "params")]
        public object[] _params { get; set; }
    }
}
