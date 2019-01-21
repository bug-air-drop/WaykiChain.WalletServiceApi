namespace WalletServiceApi.Models
{
    /// <summary>
    /// 调用合约交易
    /// </summary>
    public class ContractTxReq : BaseTxReq
    {
        /// <summary>
        /// 调用人RegID
        /// </summary>
        public string FromRegId { get; set; }
        /// <summary>
        /// 合约RegID
        /// </summary>
        public string ToScriptId { get; set; }
        /// <summary>
        /// 手续费
        /// </summary>
        public ulong Fees { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        public ulong Amount { get; set; }
        /// <summary>
        /// 合约内容
        /// </summary>
        public string Contract { get; set; }
    }
}
