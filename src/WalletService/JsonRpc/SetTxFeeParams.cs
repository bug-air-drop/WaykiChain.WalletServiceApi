using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WalletServiceApi.JsonRpc
{
    public class SetTxFeeParams
    {
        /// <summary>
        /// 每KB的费用
        /// </summary>
        [Required]
        public long Amount { get; set; }
    }
}
