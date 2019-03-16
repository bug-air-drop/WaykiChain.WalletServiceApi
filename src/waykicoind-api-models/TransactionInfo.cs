namespace WalletServiceApi.JsonRpc
{
    public class TransactionInfo
    {
        /// <summary>
        /// 接收方地址
        /// </summary>
        public string address { get; set; }

        /// <summary>
        /// 接收方地址[V2版本]
        /// </summary>
        public string desaddr { get; set; }

        /// <summary>
        /// 交易类别
        /// </summary>
        public string category { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        public decimal amount { get; set; }
        /// <summary>
        /// 确认数量
        /// </summary>
        public int confirmations { get; set; }
        /// <summary>
        /// 区块哈希
        /// </summary>
        public string blockhash { get; set; }
        /// <summary>
        /// 区块时间戳
        /// </summary>
        public int blocktime { get; set; }
        /// <summary>
        /// 交易id
        /// </summary>
        public string txid { get; set; }
        /// <summary>
        /// 交易类型
        /// </summary>
        public string txtype { get; set; }
        /// <summary>
        /// 发送方地址
        /// </summary>
        public string srcaddr { get; set; }
        /// <summary>
        /// 合约内容/交易备注
        /// </summary>
        public string contract { get; set; }
    }
}
