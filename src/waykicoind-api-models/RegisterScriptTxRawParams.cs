using System.ComponentModel.DataAnnotations;

namespace WalletServiceApi.JsonRpc
{
    public class RegisterScriptTxRawParams
    {
        /// <summary>
        /// 手续费
        /// </summary>
        [Required]
        public ulong Fee { get; set; }

        /// <summary>
        /// 合约发起人地址, 该地址必须存在于当前钱包节点
        /// </summary>
        [Required]
        public string Addr { get; set; }

        /// <summary>
        /// 指示合约的类型, 为0时是本地文件名, 为1时是已发布的合约RegId
        /// </summary>
        [Required]
        public int Flag { get; set; }

        /// <summary>
        /// 合约代码来源, 为0时是本地文件名, 为1时是已发布的合约RegId
        /// </summary>
        [Required]
        public string Script { get; set; }

        /// <summary>
        /// 高度
        /// </summary>
        [Required]
        public uint Height { get; set; }

        /// <summary>
        /// 可选参数, 合约的描述信息
        /// </summary>
        public string Description { get; set; }
    }
}
