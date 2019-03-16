namespace WalletServiceApi.JsonRpc
{
    public class AccountInfo
    {
        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// KeyID
        /// </summary>
        public string KeyID { get; set; }
        /// <summary>
        /// RegId
        /// </summary>
        public string RegID { get; set; }
        /// <summary>
        /// 公钥
        /// </summary>
        public string PublicKey { get; set; }
        /// <summary>
        /// 挖矿公钥
        /// </summary>
        public string MinerPKey { get; set; }
        /// <summary>
        /// 账号余额
        /// </summary>
        public long Balance { get; set; }
        /// <summary>
        /// 投票
        /// </summary>
        public long Votes { get; set; }
        /// <summary>
        /// 更新高度
        /// </summary>
        public long UpdateHeight { get; set; }
        public object[] voteFundList { get; set; }
        public string postion { get; set; }
    }
}
