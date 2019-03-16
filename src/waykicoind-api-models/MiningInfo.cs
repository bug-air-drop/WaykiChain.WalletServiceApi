namespace WalletServiceApi.JsonRpc
{
    /// <summary>
    /// 挖矿相关的信息
    /// </summary>
    public class MiningInfo
    {
        /// <summary>
        /// 本地最高位区块的高度
        /// </summary>
        public int blocks { get; set; }
        /// <summary>
        /// 当前节点生成的前一个区块的大小
        /// </summary>
        public int currentblocksize { get; set; }
        /// <summary>
        /// 当前节点生成的前一个区块中的交易数量
        /// </summary>
        public int currentblocktx { get; set; }
        /// <summary>
        /// 当前节点检测到的错误信息
        /// </summary>
        public string errors { get; set; }
        /// <summary>
        /// 用于挖矿的cpu核心数量上限，默认值：-1
        /// </summary>
        public int genproclimit { get; set; }
        /// <summary>
        /// 为维持当前难度，全网每秒需要生成的哈希数量
        /// </summary>
        public int networkhashps { get; set; }
        /// <summary>
        /// 内存交易池中的交易数量
        /// </summary>
        public int pooledtx { get; set; }
        /// <summary>
        /// 当前所连接网络，main、test或regtest
        /// </summary>
        public string nettype { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int posmaxnonce { get; set; }
        /// <summary>
        /// 如果当前节点启用挖矿，则为true，否则为false
        /// </summary>
        public bool generate { get; set; }
    }
}
