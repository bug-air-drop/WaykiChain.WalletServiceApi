namespace WalletServiceApi.JsonRpc
{
    public class BaseRpcMsg<T>
    {
        public T result { get; set; }
        public RpcError error { get; set; }
        public string id { get; set; }
    }

    public class RpcError
    {
        public int code { get; set; }
        public string message { get; set; }
    }


}
