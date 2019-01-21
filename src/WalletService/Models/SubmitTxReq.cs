using System.ComponentModel.DataAnnotations;

namespace WalletServiceApi.Models
{
    /// <summary>
    /// 签名交易
    /// </summary>
    public class SubmitTxReq
    {
        /// <summary>
        /// 指定节点
        /// </summary>
        [Required]
        public NodeInfo Node { get; set; }

        /// <summary>
        /// 交易
        /// </summary>
        [Required]
        public string TxRaw { get; set; }
    }
}
