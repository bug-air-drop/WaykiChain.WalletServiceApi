using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WalletServiceApi.JsonRpc
{
    public class WalletPassphraseParams
    {
        /// <summary>
        /// 钱包密码
        /// </summary>
        [Required]
        public string Passphrase { get; set; }

        /// <summary>
        /// 持续时间， 超时以后将自动从内存中删除钱包密码， 钱包将再次处于锁定状态
        /// </summary>
        [Required]
        public int Timeout { get; set; }
    }
}
