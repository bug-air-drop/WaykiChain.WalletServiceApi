namespace WalletServiceApi.Models
{
    /// <summary>
    /// 节点信息
    /// </summary>
    public class NodeInfo
    {
        /// <summary>
        /// JSON-RPC服务地址
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 鉴权信息
        /// </summary>
        public string AuthInfo { get; set; }
    }
}
