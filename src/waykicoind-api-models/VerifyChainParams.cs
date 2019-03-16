namespace WalletServiceApi.JsonRpc
{
    /// <summary>
    /// 参数
    /// </summary>
    public class VerifyChainParams
    {
        /// <summary>
        /// 指定检查的细致等级，0~4，默认值：3，等级越高 检查越细致
        /// </summary>
        public uint CheckLevel { get; set; } = 3;

        /// <summary>
        /// 要检查的区块数量，0表示检查所有区块，默认值：288
        /// </summary>
        public uint NumBlocks { get; set; } = 288;
    }
}
