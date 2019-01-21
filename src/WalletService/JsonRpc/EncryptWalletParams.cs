namespace WalletServiceApi.JsonRpc
{
    public class EncryptWalletParams
    {
        /// <summary>
        /// 用于加密钱包的密文，最短1个字符
        /// </summary>
        public string Passphrase { get; set; }
    }
}
