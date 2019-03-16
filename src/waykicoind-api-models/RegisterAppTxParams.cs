using System.ComponentModel.DataAnnotations;

namespace WalletServiceApi.JsonRpc
{
    public class RegisterAppTxParams
    {
        /// <summary>
        /// 注册人地址
        /// </summary>
        [Required]
        public string Addr { get; set; }

        /// <summary>
        /// 合约脚本文件在节点本地上的路径
        /// </summary>
        [Required]
        public string FilePath { get; set; }

        /// <summary>
        /// 手续费
        /// </summary>
        [Required]
        public ulong Fee { get; set; }

        /// <summary>
        /// 指示合约的类型, 为0时是本地文件名, 为1时是已发布的合约RegId
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// 合约代码来源, 为0时是本地文件名, 为1时是已发布的合约RegId
        /// </summary>
        public string ScriptDesc { get; set; }
    }
}
