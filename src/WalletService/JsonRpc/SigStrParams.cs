using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WalletServiceApi.JsonRpc
{
    public class SigStrParams
    {
        /// <summary>
        /// 需要签名的字符串
        /// </summary>
        [Required]
        public string Str { get; set; }

        /// <summary>
        /// 用于签名的地址
        /// </summary>
        [Required]
        public string Addr { get; set; }
    }
}
