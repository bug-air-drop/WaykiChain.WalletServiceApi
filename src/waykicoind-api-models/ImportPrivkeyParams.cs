using System.ComponentModel.DataAnnotations;

namespace WalletServiceApi.JsonRpc
{
    public class ImportPrivkeyParams
    {
        /// <summary>
        /// 要导入的私钥
        /// </summary>
        [Required]
        public string PrivateKey { get; set; }

        /// <summary>
        /// 标签
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// 是否重新扫描区块链
        /// </summary>
        public bool? Rescan { get; set; }
    }
}
