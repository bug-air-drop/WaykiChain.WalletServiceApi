namespace WalletServiceApi.JsonRpc
{
    public class ListTransactionsParams
    {
        /// <summary>
        /// 可选参数, 钱包地址
        /// </summary>
        public string Address { get; set; }

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
