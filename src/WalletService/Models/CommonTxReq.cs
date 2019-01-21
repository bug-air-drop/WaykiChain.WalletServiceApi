using System.ComponentModel.DataAnnotations;

namespace WalletServiceApi.Models
{
    /// <summary>
    /// 普通（转账）交易
    /// </summary>
    public class CommonTxReq : BaseTxReq
    {
        /// <summary>
        /// 发起地址
        /// </summary>
        [Required]
        public string From { get; set; }
        /// <summary>
        /// 接收地址
        /// </summary>
        [Required]
        public string To { get; set; }
        /// <summary>
        /// 手续费
        /// </summary>
        [Required]
        public ulong Fees { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        [Required]
        public ulong Amount { get; set; }
    }
}
