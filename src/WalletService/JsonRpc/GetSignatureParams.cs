using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WalletServiceApi.JsonRpc
{
    public class GetSignatureParams
    {
        /// <summary>
        /// 用于签名的私钥
        /// </summary>
        [Required]
        public string PrivKey { get; set; }

        /// <summary>
        /// 需要签名的Hash数据
        /// </summary>
        [Required]
        public string Hash { get; set; }
    }
}
