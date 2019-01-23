using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WalletServiceApi.JsonRpc
{
    public class SignMessageParams
    {
        /// <summary>
        /// 钱包中用于签名的地址
        /// </summary>
        [Required]
        public string Address { get; set; }

        /// <summary>
        /// 消息
        /// </summary>
        [Required]
        public string Message { get; set; }
    }
}
