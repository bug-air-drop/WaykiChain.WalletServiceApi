using System.ComponentModel.DataAnnotations;

namespace WalletServiceApi.JsonRpc
{
    public class RegistAccountTxRawParams
    {
        /// <summary>
        /// 手续费
        /// </summary>
        [Required]
        public ulong Fee { get; set; }

        /// <summary>
        /// 高度
        /// </summary>
        [Required]
        public uint Height { get; set; }

        /// <summary>
        /// 待激活地址的公钥
        /// </summary>
        [Required]
        public string PublicKey { get; set; }

        /// <summary>
        /// 可选参数, 待激活地址的旷工公钥
        /// </summary>
        public string MinerPublicKey { get; set; }
    }
}
