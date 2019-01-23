using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WalletServiceApi.JsonRpc
{
    public class SendToAddressWithFeeParams
    {
        /// <summary>
        /// 发送方地址, 缺省时将自动在钱包中选择余额充足的地址
        /// </summary>
        public string SendAddress { get; set; }

        /// <summary>
        /// 接收方地址
        /// </summary>
        [Required]
        public string RecvAddress { get; set; }

        /// <summary>
        /// 转账金额
        /// </summary>
        [Required]
        public long Amount { get; set; }

        /// <summary>
        /// 手续费
        /// </summary>
        [Required]
        public long Fee { get; set; }
    }
}
