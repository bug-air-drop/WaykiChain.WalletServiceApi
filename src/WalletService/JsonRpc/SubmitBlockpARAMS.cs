using System.ComponentModel.DataAnnotations;

namespace WalletServiceApi.JsonRpc
{
    public class SubmitBlockParams
    {
        /// <summary>
        /// 序列化的区块
        /// </summary>
        [Required]
        public string HexData { get; set; }

        /// <summary>
        /// 可选的参数对象，该对象不会广播到网络中，但可能会被节点交易池使用
        /// </summary>
        public AppandInfo Parameters { get; set; }

        public class AppandInfo 
        {
            public string workid { get; set; }
        }
    }


}
