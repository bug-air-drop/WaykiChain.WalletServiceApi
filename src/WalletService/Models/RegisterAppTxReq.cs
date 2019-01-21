namespace WalletServiceApi.Models
{
    /// <summary>
    /// 注册APP交易
    /// </summary>
    public class RegisterAppTxReq : BaseTxReq
    {
        /// <summary>
        /// 调用人RegID
        /// </summary>
        public string FromRegId { get; set; }

        /// <summary>
        /// 手续费
        /// </summary>
        public ulong Fees { get; set; }

        /// <summary>
        /// APP脚本内容
        /// </summary>
        public string Contract { get; set; }
    }
}
