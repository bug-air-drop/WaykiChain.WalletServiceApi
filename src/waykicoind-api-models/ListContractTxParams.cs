using System.ComponentModel.DataAnnotations;

namespace WalletServiceApi.JsonRpc
{
    public class ListContractTxParams
    {
        /// <summary>
        /// 合约RegId
        /// </summary>
        [Required]
        public string ScriptId { get; set; }

        /// <summary>
        /// 可选参数, 要提取的交易数量，默认值：10
        /// </summary>
        public uint Count { get; set; } = 10;

        /// <summary>
        /// 可选参数, 要跳过的交易数量，默认值：0
        /// </summary>
        public uint Skip { get; set; } = 0;
    }
}
