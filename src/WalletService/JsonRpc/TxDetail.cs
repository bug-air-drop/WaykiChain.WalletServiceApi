namespace WalletServiceApi.JsonRpc
{
    public class TxDetail
    {
        /// <summary>
        /// 交易哈希
        /// </summary>
        public string hash { get; set; }
        /// <summary>
        /// 交易类型
        /// </summary>
        public string txtype { get; set; }
        /// <summary>
        /// 协议版本
        /// </summary>
        public int ver { get; set; }
        /// <summary>
        /// 签名方RegId
        /// </summary>
        public string regid { get; set; }
        /// <summary>
        /// 签名方地址
        /// </summary>
        public string addr { get; set; }
        /// <summary>
        /// 交易金额
        /// </summary>
        public long money { get; set; }
        /// <summary>
        /// 所在区块的高度
        /// </summary>
        public int height { get; set; }
        /// <summary>
        /// 所在区块的哈希值
        /// </summary>
        public string blockhash { get; set; }
        /// <summary>
        /// 交易确认的高度
        /// </summary>
        public int confirmHeight { get; set; }
        /// <summary>
        /// 交易确认的时间
        /// </summary>
        public int confirmedtime { get; set; }
        /// <summary>
        /// RAW内容
        /// </summary>
        public string rawtx { get; set; }


        /// <summary>
        /// 签名方公钥哈希[激活地址时]
        /// </summary>
        public string pubkey { get; set; }
        /// <summary>
        /// 签名方挖矿公钥的哈希[激活地址时]
        /// </summary>
        public string miner_pubkey { get; set; }
        /// <summary>
        /// 手续费
        /// </summary>
        public int fees { get; set; }

        /// <summary>
        /// 合约描述[注册应用时]
        /// </summary>
        public string script { get; set; }

        /// <summary>
        /// 接收方RegId
        /// </summary>
        public string desregid { get; set; }
        /// <summary>
        /// 接收方地址
        /// </summary>
        public string desaddr { get; set; }
        /// <summary>
        /// 请求合约的内容[调用合约时]
        /// </summary>
        public string Contract { get; set; }
        /// <summary>
        /// 合约输出内容[调用合约时]
        /// </summary>
        public object[] listOutput { get; set; }



    }
}
