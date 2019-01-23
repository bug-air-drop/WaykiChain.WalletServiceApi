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
    public class P2PController : JsonRpcService
    {
        public P2PController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {

        }

        /// <summary>
        /// 获取节点网络信息
        /// </summary>
        /// <param name="Node">节点名称, 如: testnet</param>
        /// <returns></returns>
        [HttpGet("{Node}/GetNetworkInfo")]
        public async Task<BaseRsp<NetworkInfo>> GetNetworkInfo(string Node)
        {
            return await CallRpc<NetworkInfo>(Node, new BaseRpc() { method = RpcMethod.GetNetworkInfo.ToString().ToLower() });
        }

        /// <summary>
        /// 添加P2P连接点
        /// </summary>
        /// <param name="Node">节点名称, 如: testnet</param>
        /// <param name="IpEndPoint">IP地址与端口, 如:192.168.0.1:6968</param>
        /// <param name="Action">add|remove|onetry 方式之一</param>
        /// <returns></returns>
        [HttpGet("{Node}/AddNode")]
        public async Task<BaseRsp<object>> AddNode(string Node, string IpEndPoint, string Action)
        {
            return await CallRpc<object>(Node, new BaseRpc() { method = RpcMethod.AddNode.ToString().ToLower() });
        }

        /// <summary>
        /// 获取所有的节点信息。本方法返回所有的节点信息，其中即有已连接的，也有未连接的地址
        /// </summary>
        /// <param name="Node">节点名称, 如: testnet</param>
        /// <param name="Dns">true时返回全部连接信息, false时只返回添加的节点</param>
        /// <param name="LimitNode">可选, 只返回指定节点</param>
        /// <returns></returns>
        [HttpGet("{Node}/GetAddedNodeInfo/{Dns}/{LimitNode}")]
        public async Task<BaseRsp<object>> AddNode(string Node, bool Dns, string LimitNode = "")
        {
            var paramsArr = new List<object>() { Dns };

            if (!string.IsNullOrEmpty(LimitNode))
            {
                paramsArr.Add(LimitNode);
            }

            return await CallRpc<object>(Node, new BaseRpc() { method = RpcMethod.GetAddedNodeInfo.ToString().ToLower(), _params = paramsArr.ToArray() });
        }

        /// <summary>
        /// 获取当前连接数
        /// </summary>
        /// <param name="Node">节点名称, 如: testnet</param>
        /// <returns></returns>
        [HttpGet("{Node}/GetConnectionCount")]
        public async Task<BaseRsp<int>> GetConnectionCount(string Node)
        {
            return await CallRpc<int>(Node, new BaseRpc() { method = RpcMethod.GetConnectionCount.ToString().ToLower() });
        }


        /// <summary>
        /// 获取网络统计信息
        /// </summary>
        /// <param name="Node">节点名称, 如: testnet</param>
        /// <returns></returns>
        [HttpGet("{Node}/GetNetTotals")]
        public async Task<BaseRsp<NetTotalInfo>> GetNetTotals(string Node)
        {
            return await CallRpc<NetTotalInfo>(Node, new BaseRpc() { method = RpcMethod.GetNetTotals.ToString().ToLower() });
        }

        /// <summary>
        /// 获取当前连接信息
        /// </summary>
        /// <param name="Node">节点名称, 如: testnet</param>
        /// <returns></returns>
        [HttpGet("{Node}/GetPeerInfo")]
        public async Task<BaseRsp<PeerInfo[]>> GetPeerInfo(string Node)
        {
            return await CallRpc<PeerInfo[]>(Node, new BaseRpc() { method = RpcMethod.GetPeerInfo.ToString().ToLower() });
        }


        /// <summary>
        /// 请求节点测试与已连接节点间的网络延时
        /// </summary>
        /// <param name="Node">节点名称, 如: testnet</param>
        /// <returns>无返回信息</returns>
        [HttpGet("{Node}/Ping")]
        public async Task<BaseRsp<object>> Ping(string Node)
        {
            return await CallRpc<object>(Node, new BaseRpc() { method = RpcMethod.Ping.ToString().ToLower() });
        }


        /// <summary>
        /// 获取指定数量的最新块的基础信息
        /// </summary>
        /// <param name="Count">数量</param>
        /// <param name="Node">节点名称, 如: testnet</param>
        /// <returns></returns>
        [HttpGet("{Node}/GetChainState/{Count}")]
        public async Task<BaseRsp<CoinStateInfo>> GetChainState(string Node, int Count)
        {
            return await CallRpc<CoinStateInfo>(Node, new BaseRpc() { method = RpcMethod.GetChainState.ToString().ToLower(), _params = new object[] { Count } });
        }

    }
}