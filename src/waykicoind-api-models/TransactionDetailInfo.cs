namespace WalletServiceApi.JsonRpc
{
    public class TransactionDetailInfo
    {
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
        /// 交易详情
        /// </summary>
        public Detail[] details { get; set; }
        /// <summary>
        /// 交易RAW
        /// </summary>
        public string hex { get; set; }

        public class Detail
        {
            /// <summary>
            /// 交易类型
            /// </summary>
            public string txtype { get; set; }
            /// <summary>
            /// 合约内容
            /// </summary>
            public string contract { get; set; }
            /// <summary>
            /// 地址
            /// </summary>
            public string address { get; set; }
            /// <summary>
            /// 交易类型
            /// </summary>
            public string category { get; set; }
            /// <summary>
            /// 金额
            /// </summary>
            public decimal amount { get; set; }
        }
    }
}
