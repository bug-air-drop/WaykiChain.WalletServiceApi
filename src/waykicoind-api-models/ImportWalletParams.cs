using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WalletServiceApi.JsonRpc
{
    public class ImportWalletParams
    {
        /// <summary>
        /// 要导入的钱包转储文件名
        /// </summary>
        [Required]
        public string FileName { get; set; }
    }
}
