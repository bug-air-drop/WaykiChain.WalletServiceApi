using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WalletServiceApi.JsonRpc
{
    /// <summary>
    /// 合约信息
    /// </summary>
    public class AppInfo
    {
        /// <summary>
        /// 合约的RegId
        /// </summary>
        public string scriptId { get; set; }
        /// <summary>
        /// 合约的ID
        /// </summary>
        public string scriptId2 { get; set; }
        /// <summary>
        /// 描述信息
        /// </summary>
        public string description { get; set; }
        /// <summary>
        /// 合约代码
        /// </summary>
        public string scriptContent { get; set; }
    }
}
