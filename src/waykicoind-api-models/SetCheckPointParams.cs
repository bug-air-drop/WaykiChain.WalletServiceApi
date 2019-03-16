using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WalletServiceApi.JsonRpc
{
    public class SetCheckPointParams
    {
        /// <summary>
        /// 区块文件路径
        /// </summary>
        [Required]
        public string FilePath { get; set; }
    }
}
