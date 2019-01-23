using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WalletServiceApi.JsonRpc
{
    public class SetGenerateParams
    {
        /// <summary>
        /// 是否启用
        /// </summary>
        [Required]
        public bool Generate { get; set; }

        /// <summary>
        /// 最大线程数
        /// </summary>
        public int GenerateLimit { get; set; }
    }
}
