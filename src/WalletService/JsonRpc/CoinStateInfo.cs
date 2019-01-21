namespace WalletServiceApi.JsonRpc
{
    /// <summary>
    /// 区块信息
    /// </summary>
    public class CoinStateInfo
    {
        /// <summary>
        /// 出块时间
        /// </summary>
        public long[] blocktime { get; set; }
        /// <summary>
        /// 交易笔数
        /// </summary>
        public long[] transactions { get; set; }
        /// <summary>
        /// 燃料消耗
        /// </summary>
        public long[] fuel { get; set; }
        /// <summary>
        /// 矿工RegId
        /// </summary>
        public string[] blockminer { get; set; }
    }
}
