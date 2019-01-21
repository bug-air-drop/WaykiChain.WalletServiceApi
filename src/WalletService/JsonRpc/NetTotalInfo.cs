namespace WalletServiceApi.JsonRpc
{
    public class NetTotalInfo
    {
        /// <summary>
        /// 总接收字节数
        /// </summary>
        public long totalbytesrecv { get; set; }
        /// <summary>
        /// 总发送字节数
        /// </summary>
        public long totalbytessent { get; set; }
        public long timemillis { get; set; }
    }
}
