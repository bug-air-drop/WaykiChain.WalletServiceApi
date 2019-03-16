using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WalletServiceApi.JsonRpc
{
    public class DumpWalletParams
    {
        /// <summary>
        /// 导出文件名
        /// </summary>
        [Required]
        public string FileName { get; set; }
    }
}
