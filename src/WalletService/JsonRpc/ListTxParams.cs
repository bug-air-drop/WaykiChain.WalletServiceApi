namespace WalletServiceApi.JsonRpc
{
    public class ListTxParams
    {
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
