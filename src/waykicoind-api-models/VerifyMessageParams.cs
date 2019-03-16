namespace WalletServiceApi.JsonRpc
{
    public class VerifyMessageParams
    {
        /// <summary>
        /// 签名私钥对应的地址
        /// </summary>
        public string CoinAddress { get; set; }

        /// <summary>
        /// base64编码的签名
        /// </summary>
        public string Signature { get; set; }

        /// <summary>
        /// 原始消息
        /// </summary>
        public string Message { get; set; }
    }
}
