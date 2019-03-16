using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WalletServiceApi.JsonRpc;
using WalletServiceApi.Models;

namespace WalletServiceApi.Controllers.JsonRpcService
{
    [ApiController]
    public class ContractController : BaseService
    {
        public ContractController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {

        }

        /// <summary>
        /// 获取指定地址在指定应用的账号信息
        /// </summary>
        /// <param name="Node">节点名称, 如: testnet</param>
        /// <param name="AppId">应用ID</param>
        /// <param name="Address">地址</param>
        /// <returns>成功时返回RAW，否则返回错误信息</returns>
        [HttpPost("{Node}/GetContractAccountInfo/{AppId}/{Address}")]
        public async Task<BaseRsp<ContractAccountInfo>> SendToAddressRaw(string Node, string AppId, string Address)
        {
            var paramsArr = new List<dynamic>() { AppId, Address };

            return await CallRpc<ContractAccountInfo>(Node, new BaseRpc() { method = RpcMethod.GetContractAccountInfo.ToString().ToLower(), _params = paramsArr.ToArray() });
        }
    }
}