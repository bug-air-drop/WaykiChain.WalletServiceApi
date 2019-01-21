using System.ComponentModel.DataAnnotations;

namespace WalletServiceApi.Models
{
    /// <summary>
    /// 请求对象基类
    /// </summary>
    public class BaseTxReq
    {
        /// <summary>
        /// 私钥
        /// </summary>
        [Required(ErrorMessage = "必须提供私钥")]
        public string PrivateKey { get; set; }

        /// <summary>
        /// 是否直接提交
        /// </summary>
        public bool Submit { get; set; }

        /// <summary>
        /// 设置节点类型， 0 测试链 1 主网链
        /// </summary>
        [Range(1, 2, ErrorMessage = "不正确的节点类型")]
        [Required]
        public int NetType { get; set; }

        /// <summary>
        /// 指定节点
        /// </summary>
        public NodeInfo Node { get; set; }

        /// <summary>
        /// 超时高度
        /// </summary>
        [Range(0, 99999999, ErrorMessage = "不正确的高度")]
        public uint ValidHeight { get; set; }
    }

}
