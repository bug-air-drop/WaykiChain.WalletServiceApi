using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WalletServiceApi.JsonRpc
{
    public class SaveBlockToFileParams
    {
        /// <summary>
        /// 投票人地址
        /// </summary>
        [Required]
        public string BlockHash { get; set; }

        /// <summary>
        /// 保存的文件路径
        /// </summary>
        [Required]
        public string FilePath { get; set; }
    }
}
