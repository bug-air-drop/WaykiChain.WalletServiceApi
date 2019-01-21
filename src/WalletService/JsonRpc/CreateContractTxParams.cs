using System.ComponentModel.DataAnnotations;

namespace WalletServiceApi.JsonRpc
{
    public class CreateContractTxParams
    {
        /// <summary>
        /// 发送方地址
        /// </summary>
        [Required]
        public string SenderAddr { get; set; }

        /// <summary>
        /// 合约的RegId
        /// </summary>
        [Required]
        public string AppRegId { get; set; }

        /// <summary>
        /// 交易转账金额
        /// </summary>
        [Required]
        public long Amount { get; set; }

        /// <summary>
        /// 合约内容
        /// </summary>
        [Required]
        public string Contract { get; set; }

        /// <summary>
        /// 手续费
        /// </summary>
        [Required]
        public long Fee { get; set; }

        /// <summary>
        /// 可选参数, 高度
        /// </summary>
        public int Height { get; set; }
    }
}
