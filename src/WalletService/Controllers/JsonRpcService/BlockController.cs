using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WalletServiceApi.JsonRpc;
using WalletServiceApi.Models;

namespace WalletServiceApi.Controllers.JsonRpcService
{
    [ApiController]
    public class BlockController : BaseService
    {
        public BlockController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {

        }

        /// <summary>
        /// 获取区块链的当前状态
        /// </summary>
        /// <param name="Node">节点名称, 如: testnet</param>
        /// <returns>描述区块链当前状态的对象</returns>
        [HttpGet("{Node}/GetBlockChainInfo")]
        public async Task<BaseRsp<ChainInfo>> GetBlockChainInfo(string Node)
        {
            return await CallRpc<ChainInfo>(Node, new BaseRpc() { method = RpcMethod.GetBlockchainInfo.ToString().ToLower() });
        }

        /// <summary>
        /// 获取节点上最优链上最后一个区块的哈希
        /// </summary>
        /// <param name="Node">节点名称, 如: testnet</param>
        /// <returns>最高位的区块哈希</returns>
        [HttpGet("{Node}/GetBestBlockHash")]
        public async Task<BaseRsp<string>> GetBestBlockHash(string Node)
        {
            return await CallRpc<string>(Node, new BaseRpc() { method = RpcMethod.GetBestBlockHash.ToString().ToLower() });
        }

        /// <summary>
        /// 获取本地最优链中的区块数量
        /// </summary>
        /// <param name="Node">节点名称, 如: testnet</param>
        /// <returns>一个整数值，表示本地最优链中的区块数量</returns>
        [HttpGet("{Node}/GetBlockCount")]
        public async Task<BaseRsp<int>> GetBlockCount(string Node)
        {
            return await CallRpc<int>(Node, new BaseRpc() { method = RpcMethod.GetBlockCount.ToString().ToLower() });
        }

        /// <summary>
        /// 获取指定哈希的区块信息
        /// </summary>
        /// <param name="Node">节点名称, 如: testnet</param>
        /// <param name="HashOrHeight">区块哈希或高度</param>
        /// <returns></returns>
        [HttpGet("{Node}/GetBlock/{HashOrHeight}")]
        public async Task<BaseRsp<BlockInfo>> GetBlock(string Node, string HashOrHeight)
        {
            if (Regex.IsMatch(HashOrHeight, "^[0-9]*$"))
            {
                return await CallRpc<BlockInfo>(Node, new BaseRpc() { method = RpcMethod.GetBlock.ToString().ToLower(), _params = new object[] { int.Parse(HashOrHeight) } });
            }
            else
            {
                return await CallRpc<BlockInfo>(Node, new BaseRpc() { method = RpcMethod.GetBlock.ToString().ToLower(), _params = new object[] { HashOrHeight } });
            }
        }

        /// <summary>
        /// 获取指定哈希的区块，根据参数不同，返回结果可以是序列化码流 或者JSON对象
        /// </summary>
        /// <param name="Node">节点名称, 如: testnet</param>
        /// <param name="HashOrHeight">区块哈希或高度</param>
        /// <param name="Format">是否解析为Json格式</param>
        /// <returns></returns>
        [HttpGet("{Node}/GetBlock/{HashOrHright}/{Format}")]
        public async Task<BaseRsp<dynamic>> GetBlock(string Node, string HashOrHeight, bool Format)
        {
            if (Regex.IsMatch(HashOrHeight, "^[0-9]*$"))
            {
                return await CallRpc<dynamic>(Node, new BaseRpc() { method = RpcMethod.GetBlock.ToString().ToLower(), _params = new object[] { int.Parse(HashOrHeight), Format } });
            }
            else
            {
                return await CallRpc<dynamic>(Node, new BaseRpc() { method = RpcMethod.GetBlock.ToString().ToLower(), _params = new object[] { HashOrHeight, Format } });
            }

        }

        /// <summary>
        /// 获取在本地最优链中指定高度区块的哈希
        /// </summary>
        /// <param name="Node">节点名称, 如: testnet</param>
        /// <param name="Height">区块在链中的高度</param>
        /// <returns>指定高度区块的块头哈希值</returns>
        [HttpGet("{Node}/GetBlockHash/{Height}")]
        public async Task<BaseRsp<GetBlockHash>> GetBlockHash(string Node, uint Height)
        {
            return await CallRpc<GetBlockHash>(Node, new BaseRpc() { method = RpcMethod.GetBlockHash.ToString().ToLower(), _params = new object[] { Height } });
        }

        /// <summary>
        /// 获取当前记账计算量难度
        /// </summary>
        /// <param name="Node">节点名称, 如: testnet</param>
        /// <returns></returns>
        [HttpGet("{Node}/GetDifficulty")]
        public async Task<BaseRsp<int>> GetDifficulty(string Node)
        {
            return await CallRpc<int>(Node, new BaseRpc() { method = RpcMethod.GetDifficulty.ToString().ToLower() });
        }

        /// <summary>
        /// 获取内存池信息
        /// </summary>
        /// <param name="Node">节点名称, 如: testnet</param>
        /// <param name="Verbose">true 返回Json格式, flase 返回交易ID列表</param>
        /// <returns></returns>
        [HttpGet("{Node}/GetRawMemPool/{Verbose}")]
        public async Task<BaseRsp<dynamic>> GetRawMemPool(string Node, bool Verbose)
        {
            return await CallRpc<dynamic>(Node, new BaseRpc() { method = RpcMethod.GetRawMemPool.ToString().ToLower(), _params = new object[] { Verbose } });
        }

        /// <summary>
        /// 获取区块检查点
        /// </summary>
        /// <param name="Node">节点名称, 如: testnet</param>
        /// <returns></returns>
        [HttpGet("{Node}/ListCheckPoint")]
        public async Task<BaseRsp<dynamic>> ListCheckPoint(string Node)
        {
            return await CallRpc<dynamic>(Node, new BaseRpc() { method = RpcMethod.ListCheckPoint.ToString().ToLower() });
        }

        /// <summary>
        /// 验证本地区块链数据库中的每个成员
        /// </summary>
        /// <param name="Node">节点名称, 如: testnet</param>
        /// <param name="params">检查范围</param>
        /// <returns>返回验证结果，true或false</returns>
        [HttpPost("{Node}/VerifyChain")]
        public async Task<BaseRsp<bool>> VerifyChain(string Node, [FromBody]VerifyChainParams @params)
        {
            return await CallRpc<bool>(Node, new BaseRpc() { method = RpcMethod.VerifyChain.ToString().ToLower(), _params = new object[] { @params.CheckLevel, @params.NumBlocks } });
        }

        /// <summary>
        /// 验证一个签名消息
        /// </summary>
        /// <param name="Node">节点名称, 如: testnet</param>
        /// <param name="params">检查范围</param>
        /// <returns>验证成功时返回true，否则返回false或者错误信息</returns>
        [HttpPost("{Node}/VerifyMessage")]
        public async Task<BaseRsp<bool>> VerifyMessage(string Node, [FromBody]VerifyMessageParams @params)
        {
            return await CallRpc<bool>(Node, new BaseRpc() { method = RpcMethod.VerifyMessage.ToString().ToLower(), _params = new object[] { @params.CoinAddress, @params.Signature, @params.Message } });
        }

        /// <summary>
        /// 获取全网的币的总和
        /// </summary>
        /// <param name="Node">节点名称, 如: testnet</param>
        /// <returns></returns>
        [HttpGet("{Node}/GetTotalCoin")]
        public async Task<BaseRsp<dynamic>> GetTotalCoin(string Node)
        {
            return await CallRpc<dynamic>(Node, new BaseRpc() { method = RpcMethod.GetTotalCoin.ToString().ToLower() });
        }

        /// <summary>
        /// 获取由指定应用发行的资产总和
        /// </summary>
        /// <param name="Node">节点名称, 如: testnet</param>
        /// <param name="ScriptId">应用RegId</param>
        /// <returns></returns>
        [HttpGet("{Node}/GetTotalAssets/{ScriptId}")]
        public async Task<BaseRsp<dynamic>> GetTotalAssets(string Node, string ScriptId)
        {
            return await CallRpc<dynamic>(Node, new BaseRpc() { method = RpcMethod.GetTotalAssets.ToString().ToLower(), _params = new object[] { ScriptId } });
        }
    }
}