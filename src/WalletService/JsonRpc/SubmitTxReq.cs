using WalletServiceApi.Models;

namespace WalletServiceApi.JsonRpc
{
    /// <summary>
    /// 请求提交RAW
    /// </summary>
    public class SubmitTxReq
    {
        /// <summary>
        /// 交易RAW
        /// </summary>
        public string Raw { get; set; }

        /// <summary>
        /// 节点
        /// </summary>
        public NodeInfo Node { get; set; }
    }
}
