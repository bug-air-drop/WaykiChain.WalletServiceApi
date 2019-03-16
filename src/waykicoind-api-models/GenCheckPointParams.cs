using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WalletServiceApi.JsonRpc
{
    public class GenCheckPointParams
    {
        /// <summary>
        /// 用于签名的私钥
        /// </summary>
        [Required]
        public string PrivateKey { get; set; }

        /// <summary>
        /// 区块文件路径
        /// </summary>
        [Required]
        public string FilePath { get; set; }
    }
}
