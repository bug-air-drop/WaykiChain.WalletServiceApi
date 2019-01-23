using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WalletServiceApi.JsonRpc;
using WalletServiceApi.Models;

namespace WalletServiceApi.Controllers.JsonRpcService
{

    [ApiController]
    public class BetaFunController : JsonRpcService
    {
        public BetaFunController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {

        }

        /// <summary>
        /// 获取交易产生的日志
        /// </summary>
        /// <param name="Node">节点名称, 如: testnet</param>
        /// <param name="Hash">交易Hash</param>
        /// <returns>日志列表</returns>
        [HttpGet("{Node}/GetTxOperationLog/{Hash}")]
        public async Task<BaseRsp<dynamic>> GetTxOperationLog(string Node, string Hash)
        {
            return await CallRpc<dynamic>(Node, new BaseRpc() { method = RpcMethod.GetTxOperationLog.ToString().ToLower(), _params = new object[] { Hash } });
        }

        /// <summary>
        /// DisconnectBlock
        /// </summary>
        /// <param name="Node">节点名称, 如: testnet</param>
        /// <param name="Block">the block numbers</param>
        /// <returns>日志列表</returns>
        [HttpGet("{Node}/DisconnectBlock/{Block}")]
        public async Task<BaseRsp<dynamic>> DisconnectBlock(string Node, int Block)
        {
            return await CallRpc<dynamic>(Node, new BaseRpc() { method = RpcMethod.DisconnectBlock.ToString().ToLower(), _params = new object[] { Block } });
        }

        /// <summary>
        /// ResetClient
        /// </summary>
        /// <param name="Node">节点名称, 如: testnet</param>
        /// <returns>操作结果</returns>
        [HttpGet("{Node}/ResetClient")]
        public async Task<BaseRsp<dynamic>> ResetClient(string Node)
        {
            return await CallRpc<dynamic>(Node, new BaseRpc() { method = RpcMethod.ResetClient.ToString().ToLower() });
        }

        /// <summary>
        /// 重新加载缓存中的交易
        /// </summary>
        /// <param name="Node">节点名称, 如: testnet</param>
        /// <returns>操作结果</returns>
        [HttpGet("{Node}/ReloadTxCache")]
        public async Task<BaseRsp<dynamic>> ReloadTxCache(string Node)
        {
            return await CallRpc<dynamic>(Node, new BaseRpc() { method = RpcMethod.ReloadTxCache.ToString().ToLower() });
        }

        /// <summary>
        /// ListSetBlockIndexValid
        /// </summary>
        /// <param name="Node">节点名称, 如: testnet</param>
        /// <returns>操作结果</returns>
        [HttpGet("{Node}/ListSetBlockIndexValid")]
        public async Task<BaseRsp<dynamic>> ListSetBlockIndexValid(string Node)
        {
            return await CallRpc<dynamic>(Node, new BaseRpc() { method = RpcMethod.ListSetBlockIndexValid.ToString().ToLower() });
        }

        /// <summary>
        /// 获取应用的RegId
        /// </summary>
        /// <param name="Node">节点名称, 如: testnet</param>
        /// <param name="Address">应用的地址</param>
        /// <returns>操作结果</returns>
        [HttpGet("{Node}/GetAppRegId/{Address}")]
        public async Task<BaseRsp<dynamic>> GetAppRegId(string Node, string Address)
        {
            return await CallRpc<dynamic>(Node, new BaseRpc() { method = RpcMethod.GetAppRegId.ToString().ToLower(), _params = new object[] { Address } });
        }

        /// <summary>
        /// 获取应用已使用的存储空间
        /// </summary>
        /// <param name="Node">节点名称, 如: testnet</param>
        /// <param name="AppId">应用RegId</param>
        /// <returns>操作结果</returns>
        [HttpGet("{Node}/GetScriptDbSize/{AppId}")]
        public async Task<BaseRsp<dynamic>> GetScriptDbSize(string Node, string AppId)
        {
            return await CallRpc<dynamic>(Node, new BaseRpc() { method = RpcMethod.GetScriptDbSize.ToString().ToLower(), _params = new object[] { AppId } });
        }

        /// <summary>
        /// 获取区块数据库的信息
        /// </summary>
        /// <param name="Node">节点名称, 如: testnet</param>
        /// <returns>操作结果</returns>
        [HttpGet("{Node}/PrintBlokDbInfo")]
        public async Task<BaseRsp<dynamic>> PrintBlokDbInfo(string Node)
        {
            return await CallRpc<dynamic>(Node, new BaseRpc() { method = RpcMethod.PrintBlokDbInfo.ToString().ToLower() });
        }

        /// <summary>
        /// 获取已确认和未确认的交易列表
        /// </summary>
        /// <param name="Node">节点名称, 如: testnet</param>
        /// <returns>操作结果</returns>
        [HttpGet("{Node}/GetAllTxInfo")]
        public async Task<BaseRsp<dynamic>> GetAllTxInfo(string Node)
        {
            return await CallRpc<dynamic>(Node, new BaseRpc() { method = RpcMethod.GetAllTxInfo.ToString().ToLower() });
        }

        /// <summary>
        /// 将指定区块保存到本地文件
        /// </summary>
        /// <param name="Node">节点名称, 如: testnet</param>
        /// <param name="params">参数</param>
        /// <returns>操作结果</returns>
        [HttpPost("{Node}/SaveBlockToFile")]
        public async Task<BaseRsp<dynamic>> SaveBlockToFile(string Node, [FromBody]SaveBlockToFileParams @params)
        {
            return await CallRpc<dynamic>(Node, new BaseRpc() { method = RpcMethod.SaveBlockToFile.ToString().ToLower(), _params = new object[] { @params.BlockHash, @params.FilePath } });
        }

        /// <summary>
        /// 获取字符串的哈希
        /// </summary>
        /// <param name="Node">节点名称, 如: testnet</param>
        /// <param name="content">字符串</param>
        /// <returns>哈希</returns>
        [HttpPost("{Node}/GetHash")]
        public async Task<BaseRsp<dynamic>> GetHash(string Node, [FromBody]string content)
        {
            return await CallRpc<dynamic>(Node, new BaseRpc() { method = RpcMethod.GetHash.ToString().ToLower(), _params = new object[] { content } });
        }

        /// <summary>
        /// GetRawTx
        /// </summary>
        /// <param name="Node">节点名称, 如: testnet</param>
        /// <param name="content">Raw</param>
        /// <returns>结果</returns>
        [HttpPost("{Node}/GetRawTx")]
        public async Task<BaseRsp<dynamic>> GetRawTx(string Node, [FromBody]string content)
        {
            return await CallRpc<dynamic>(Node, new BaseRpc() { method = RpcMethod.GetRawTx.ToString().ToLower(), _params = new object[] { content } });
        }
    }
}