namespace WalletServiceApi.JsonRpc
{
    /// <summary>
    /// 区块信息
    /// </summary>
    public class BlockInfo
    {
        /// <summary>
        /// 哈希
        /// </summary>
        public string hash { get; set; }
        /// <summary>
        /// 确认数
        /// </summary>
        public int confirmations { get; set; }
        /// <summary>
        /// 区块大小
        /// </summary>
        public int size { get; set; }
        /// <summary>
        /// 区块高度
        /// </summary>
        public int height { get; set; }
        /// <summary>
        /// 协议版本
        /// </summary>
        public int version { get; set; }
        /// <summary>
        /// Merkle树根哈希
        /// </summary>
        public string merkleroot { get; set; }
        /// <summary>
        /// 包含的交易笔数
        /// </summary>
        public int txnumber { get; set; }
        /// <summary>
        /// 包含的交易哈希
        /// </summary>
        public string[] tx { get; set; }
        /// <summary>
        /// 出块时间
        /// </summary>
        public long time { get; set; }
        /// <summary>
        /// nonce值
        /// </summary>
        public int nonce { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string chainwork { get; set; }
        /// <summary>
        /// 燃料
        /// </summary>
        public long fuel { get; set; }
        /// <summary>
        /// 燃料率
        /// </summary>
        public long fuelrate { get; set; }
        /// <summary>
        /// 前一个区块哈希
        /// </summary>
        public string previousblockhash { get; set; }
        /// <summary>
        /// 后一个区块哈希
        /// </summary>
        public string nextblockhash { get; set; }
    }
}
