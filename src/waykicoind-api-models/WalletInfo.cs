namespace WalletServiceApi.JsonRpc
{
    public class WalletInfo
    {
        /// <summary>
        /// 钱包版本
        /// </summary>
        public int walletversion { get; set; }
        /// <summary>
        /// 总资产
        /// </summary>
        public decimal balance { get; set; }
        /// <summary>
        /// 已确认交易笔数
        /// </summary>
        public int Inblocktx { get; set; }
        /// <summary>
        /// 未确认交易笔数
        /// </summary>
        public int unconfirmtx { get; set; }

    }
}
