using System.ComponentModel.DataAnnotations;

namespace WalletServiceApi.JsonRpc
{
    public class SendToAddressRawParams
    {
        /// <summary>
        /// 手续费
        /// </summary>
        [Required]
        public ulong Fee { get; set; }

        /// <summary>
        /// 转账金额
        /// </summary>
        [Required]
        public ulong Amount { get; set; }

        /// <summary>
        /// 发送方账户, 该地址必须存在于当前钱包中
        /// </summary>
        [Required]
        public string SrcAddress { get; set; }

        /// <summary>
        /// 接收方地址
        /// </summary>
        [Required]
        public string RecvAddress { get; set; }

        /// <summary>
        /// 可选参数, 高度
        /// </summary>
        public uint Height { get; set; }
    }
}
