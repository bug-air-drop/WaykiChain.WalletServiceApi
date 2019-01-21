using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WalletServiceApi.JsonRpc;
using WalletServiceApi.Models;

namespace WalletServiceApi.Controllers.JsonRpcService
{
    [ApiController]
    public class MiningController : JsonRpcService
    {
        public MiningController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {

        }

        /// <summary>
        /// 获取挖矿相关的信息
        /// </summary>
        /// <param name="Node">节点名称, 如: test</param>
        /// <returns></returns>
        [HttpGet("{Node}/GetMiningInfo")]
        public async Task<BaseRsp<MiningInfo>> GetMiningInfo(string Node)
        {
            return await CallRpc<MiningInfo>(Node, new BaseRpc() { method = RpcMethod.GetMiningInfo.ToString().ToLower() });
        }

        /// <summary>
        /// 获取基于最近n个区块估算的全网每秒可生成的哈希数量
        /// </summary>
        /// <param name="Node">节点名称, 如: test</param>
        /// <param name="Blocks">用于估算的区块数量，默认值：120，设置为-1则使用自上次 难度变化之后的所有区块进行估算</param>
        /// <param name="Height">用于计算平均值的最后一个区块高度。默认值：-1，表示使用 最高位区块</param>
        /// <returns>估算的哈希生成速率</returns>
        [HttpGet("{Node}/GetNetworkHashPS/{Blocks}/{Height}")]
        public async Task<BaseRsp<MiningInfo>> GetNetworkHashPS(string Node, int Blocks, int Height)
        {
            return await CallRpc<MiningInfo>(Node, new BaseRpc() { method = RpcMethod.GetNetworkHashPS.ToString().ToLower(), _params = new object[] { Blocks, Height } });
        }

        /// <summary>
        /// 提交一个区块，进行验证，然后广播到网络中
        /// </summary>
        /// <param name="Node">节点名称, 如: test</param>
        /// <param name="params">参数</param>
        /// <returns>成功时返回null，否则返回错误信息</returns>
        [HttpPost("{Node}/SubmitBlock")]
        public async Task<BaseRsp<dynamic>> SubmitBlock(string Node, [FromBody]SubmitBlockParams @params)
        {
            var paramsArr = new List<dynamic>() { @params.HexData };

            if (@params.Parameters != null)
            {
                paramsArr.Add(JsonConvert.SerializeObject(@params.Parameters));
            }

            return await CallRpc<dynamic>(Node, new BaseRpc() { method = RpcMethod.SubmitBlock.ToString().ToLower(), _params = paramsArr.ToArray() });
        }
    }
}