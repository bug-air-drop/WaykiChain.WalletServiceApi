using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WalletServiceApi.JsonRpc
{
    public class GetAddedNodeInfoParams
    {
        /// <summary>
        /// true时返回全部连接信息, false时只返回添加的节点
        /// </summary>
        [Required]
        public bool Dns { get; set; }

        /// <summary>
        /// 可选参数, 指定返回的节点
        /// </summary>
        public string Node { get; set; }
    }
}
