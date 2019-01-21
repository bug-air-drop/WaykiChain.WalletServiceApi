namespace WalletServiceApi.JsonRpc
{
    /// <summary>
    /// 描述区块链当前状态的对象
    /// </summary>
    public class ChainInfo
    {
        /// <summary>
        /// 区块链名称，可以是：main、test或regtest
        /// </summary>
        public string chain { get; set; }
        /// <summary>
        /// 本地最优链中的已验证区块数量
        /// </summary>
        public int blocks { get; set; }
        /// <summary>
        /// 本地最优链中最高区块的哈希
        /// </summary>
        public string bestblockhash { get; set; }
        /// <summary>
        /// 区块验证进度，0.0~1.0
        /// </summary>
        public decimal verificationprogress { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string chainwork { get; set; }
    }
}
