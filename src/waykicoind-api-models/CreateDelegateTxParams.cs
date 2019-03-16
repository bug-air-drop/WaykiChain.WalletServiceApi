using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace WalletServiceApi.JsonRpc
{
    public class CreateDelegateTxParams
    {
        /// <summary>
        /// 投票人地址
        /// </summary>
        [Required]
        public string Addr { get; set; }

        /// <summary>
        /// 投票信息
        /// </summary>
        [Required]
        public Opervoter[] Opervotes { get; set; }

        /// <summary>
        /// 手续费
        /// </summary>
        [Required]
        public long Fee { get; set; }

        /// <summary>
        /// 可选参数, 高度
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// 投票信息
        /// </summary>
        public class Opervoter
        {
            /// <summary>
            /// 候选人地址
            /// </summary>
            [Required]
            [JsonProperty(PropertyName = "delegate")]
            public string Delegate { get; set; }

            /// <summary>
            /// 投票数量
            /// </summary>
            [Required]
            [JsonProperty(PropertyName = "votes")]
            public long Votes { get; set; }
        }
    }
}
