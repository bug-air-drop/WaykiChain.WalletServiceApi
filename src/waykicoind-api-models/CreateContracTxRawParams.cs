using System.ComponentModel.DataAnnotations;

namespace WalletServiceApi.JsonRpc
{
    public class CreateContracTxRawParams
    {
        /// <summary>
        /// 手续费
        /// </summary>
        [Required]
        public ulong Fee { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        [Required]
        public ulong Amount { get; set; }

        /// <summary>
        /// 调用方地址, 该地址必须存在于当前钱包节点
        /// </summary>
        [Required]
        public string Addr { get; set; }

        /// <summary>
        /// 合约应用的RegId
        /// </summary>
        [Required]
        public string AppId { get; set; }

        /// <summary>
        /// 提交的合约内容
        /// </summary>
        [Required]
        public string Contract { get; set; }

        /// <summary>
        /// 高度
        /// </summary>
        public uint Height { get; set; }
    }
}
