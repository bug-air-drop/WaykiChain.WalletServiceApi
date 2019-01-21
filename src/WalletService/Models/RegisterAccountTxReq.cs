namespace WalletServiceApi.Models
{
    /// <summary>
    /// 激活账号交易
    /// </summary>
    public class RegisterAccountTxReq : BaseTxReq
    {
        /// <summary>
        /// 手续费
        /// </summary>
        public ulong Fees { get; set; }
    }
}
