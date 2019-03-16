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
    public class RawController : BaseService
    {
        public RawController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }

        /// <summary>
        /// 获取转账交易的RAW
        /// </summary>
        /// <param name="Node">节点名称, 如: testnet</param>
        /// <param name="params">参数</param>
        /// <returns>成功时返回RAW，否则返回错误信息</returns>
        [HttpPost("{Node}/SendToAddressRaw")]
        public async Task<BaseRsp<dynamic>> SendToAddressRaw(string Node, [FromBody]SendToAddressRawParams @params)
        {
            var paramsArr = new List<dynamic>() { @params.Fee, @params.Amount, @params.SrcAddress, @params.RecvAddress };

            if (@params.Height != 0)
            {
                paramsArr.Add(@params.Height);
            }

            return await CallRpc<dynamic>(Node, new BaseRpc() { method = RpcMethod.SendToAddressRaw.ToString().ToLower(), _params = paramsArr.ToArray() });
        }

        /// <summary>
        /// 获取激活地址交易的RAW
        /// </summary>
        /// <param name="Node">节点名称, 如: testnet</param>
        /// <param name="params">参数</param>
        /// <returns>成功时返回RAW，否则返回错误信息</returns>
        [HttpPost("{Node}/RegistAccountTxRaw")]
        public async Task<BaseRsp<RegistAccountTxRaw>> RegistAccountTxRaw(string Node, [FromBody]RegistAccountTxRawParams @params)
        {
            var paramsArr = new List<object>() { @params.Fee, @params.Height, @params.PublicKey };

            if (!string.IsNullOrEmpty(@params.MinerPublicKey))
            {
                paramsArr.Add(@params.MinerPublicKey);
            }

            return await CallRpc<RegistAccountTxRaw>(Node, new BaseRpc() { method = RpcMethod.RegistAccountTxRaw.ToString().ToLower(), _params = paramsArr.ToArray() });
        }

        /// <summary>
        /// 获取调用合约APP的交易RAW
        /// </summary>
        /// <param name="Node">节点名称, 如: testnet</param>
        /// <param name="params">参数</param>
        /// <returns>成功时返回RAW，否则返回错误信息</returns>
        [HttpPost("{Node}/CreateContracTxRaw")]
        public async Task<BaseRsp<dynamic>> CreateContracTxRaw(string Node, [FromBody]CreateContracTxRawParams @params)
        {
            var paramsArr = new List<object>() { @params.Fee, @params.Amount, @params.Addr, @params.AppId, @params.Contract };

            if (@params.Height != 0)
            {
                paramsArr.Add(@params.Height);
            }

            return await CallRpc<dynamic>(Node, new BaseRpc() { method = RpcMethod.CreateContracTxRaw.ToString().ToLower(), _params = paramsArr.ToArray() });
        }

        /// <summary>
        /// 获取发布合约APP的交易RAW
        /// </summary>
        /// <param name="Node">节点名称, 如: testnet</param>
        /// <param name="params">参数</param>
        /// <returns>成功时返回RAW，否则返回错误信息</returns>
        [HttpPost("{Node}/RegisterScriptTxRaw")]
        public async Task<BaseRsp<dynamic>> RegisterScriptTxRaw(string Node, [FromBody]RegisterScriptTxRawParams @params)
        {
            var paramsArr = new List<object>() { @params.Fee, @params.Addr, @params.Flag, @params.Script, @params.Height };

            if (!string.IsNullOrEmpty(@params.Description))
            {
                paramsArr.Add(@params.Description);
            }

            return await CallRpc<dynamic>(Node, new BaseRpc() { method = RpcMethod.RegisterScriptTxRaw.ToString().ToLower(), _params = paramsArr.ToArray() });
        }

        /// <summary>
        /// 创建投票交易
        /// </summary>
        /// <param name="Node">节点名称, 如: testnet</param>
        /// <param name="params">参数</param>
        /// <returns>返回该交易RAW</returns>
        [HttpPost("{Node}/CreateDelegateTxRaw")]
        public async Task<BaseRsp<dynamic>> CreateDelegateTxRaw(string Node, [FromBody]CreateDelegateTxParams @params)
        {
            var paramsArr = new List<object>() { @params.Addr, JsonConvert.SerializeObject(@params.Opervotes), @params.Fee };

            if (@params.Height > 0)
            {
                paramsArr.Add(@params.Height);
            }

            return await CallRpc<dynamic>(Node, new BaseRpc() { method = RpcMethod.CreateDelegateTxRaw.ToString().ToLower(), _params = paramsArr.ToArray() });
        }

        /// <summary>
        /// 解析交易RAW
        /// </summary>
        /// <param name="Node">节点名称, 如: testnet</param>
        /// <param name="content">交易RAW</param>
        /// <returns>解析结果</returns>
        [HttpPost("{Node}/DecodeRawTx")]
        public async Task<BaseRsp<dynamic>> DecodeRawTx(string Node, [FromBody]string content)
        {
            return await CallRpc<dynamic>(Node, new BaseRpc() { method = RpcMethod.DecodeRawTx.ToString().ToLower(), _params = new object[] { content } });
        }
    }
}