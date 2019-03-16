namespace WalletServiceApi.JsonRpc
{
    /// <summary>
    /// 当前网络信息
    /// </summary>
    public class NetworkInfo
    {
        public int version { get; set; }
        public int protocolversion { get; set; }
        public int timeoffset { get; set; }
        public int connections { get; set; }
        public string proxy { get; set; }
        public decimal relayfee { get; set; }
        public string[] localaddresses { get; set; }
    }
}
