using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WalletServiceApi.JsonRpc
{
    public class WalletPassphraseChangeParams
    {
        /// <summary>
        /// 旧钱包密码
        /// </summary>
        [Required]
        public string OldPassphrase { get; set; }

        /// <summary>
        /// 新钱包密码
        /// </summary>
        [Required]
        public string NewPassphrase { get; set; }
    }
}
