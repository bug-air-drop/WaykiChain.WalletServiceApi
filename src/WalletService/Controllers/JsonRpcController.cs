using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WalletServiceApi.JsonRpc;
using WalletServiceApi.Models;

namespace WalletServiceApi.Controllers
{
    /// <summary>
    /// 调用预配置节点的远程服务
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class JsonRpcController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public JsonRpcController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        /// <summary>
        /// 获取本地最优链中的区块数量
        /// </summary>
        /// <param name="Node">节点名称, 如: test</param>
        /// <returns>一个整数值，表示本地最优链中的区块数量</returns>
        [HttpGet("{Node}/GetBlockCount")]
        public async Task<BaseRsp<int>> GetBlockCount(string Node)
        {
            return await CallRpc<int>(Node, new BaseRpc() { method = RpcMethod.GetBlockCount.ToString().ToLower() });
        }

        /// <summary>
        /// 获取当前连接数
        /// </summary>
        /// <param name="Node">节点名称, 如: test</param>
        /// <returns></returns>
        [HttpGet("{Node}/GetConnectionCount")]
        public async Task<BaseRsp<int>> GetConnectionCount(string Node)
        {
            return await CallRpc<int>(Node, new BaseRpc() { method = RpcMethod.GetConnectionCount.ToString().ToLower() });
        }

        /// <summary>
        /// 获取当前连接信息
        /// </summary>
        /// <param name="Node">节点名称, 如: test</param>
        /// <returns></returns>
        [HttpGet("{Node}/GetPeerInfo")]
        public async Task<BaseRsp<PeerInfo[]>> GetPeerInfo(string Node)
        {
            return await CallRpc<PeerInfo[]>(Node, new BaseRpc() { method = RpcMethod.GetPeerInfo.ToString().ToLower() });
        }

        /// <summary>
        /// 请求节点测试与已连接节点间的网络延时
        /// </summary>
        /// <param name="Node">节点名称, 如: test</param>
        /// <returns>无返回信息</returns>
        [HttpGet("{Node}/Ping")]
        public async Task<BaseRsp<object>> Ping(string Node)
        {
            return await CallRpc<object>(Node, new BaseRpc() { method = RpcMethod.Ping.ToString().ToLower() });
        }

        /// <summary>
        /// 添加P2P连接点
        /// </summary>
        /// <param name="Node">节点名称, 如: test</param>
        /// <param name="IpEndPoint">IP地址与端口, 如:192.168.0.1:6968</param>
        /// <param name="Action">add|remove|onetry 方式之一</param>
        /// <returns></returns>
        [HttpGet("{Node}/AddNode")]
        public async Task<BaseRsp<object>> AddNode(string Node, string IpEndPoint, string Action)
        {
            return await CallRpc<object>(Node, new BaseRpc() { method = RpcMethod.AddNode.ToString().ToLower() });
        }

        /// <summary>
        /// 获取网络统计信息
        /// </summary>
        /// <param name="Node">节点名称, 如: test</param>
        /// <returns></returns>
        [HttpGet("{Node}/GetNetTotals")]
        public async Task<BaseRsp<NetTotalInfo>> GetNetTotals(string Node)
        {
            return await CallRpc<NetTotalInfo>(Node, new BaseRpc() { method = RpcMethod.GetNetTotals.ToString().ToLower() });
        }

        /// <summary>
        /// 获取指定数量的最新块的基础信息
        /// </summary>
        /// <param name="Count">数量</param>
        /// <param name="Node">节点名称, 如: test</param>
        /// <returns></returns>
        [HttpGet("{Node}/GetCoinState/{Count}")]
        public async Task<BaseRsp<CoinStateInfo>> GetCoinState(string Node, int Count)
        {
            return await CallRpc<CoinStateInfo>(Node, new BaseRpc() { method = RpcMethod.GetCoinState.ToString().ToLower(), _params = new object[] { Count } });
        }

        /// <summary>
        /// 导出指定地址对应的私钥，格式为WIF。该调用需要 节点启用钱包支持，而且钱包解锁或未加密
        /// </summary>
        /// <param name="Node">节点名称, 如: test</param>
        /// <param name="Address">一个钱包内的P2PKH地址</param>
        /// <returns>指定地址对应的WIF格式的私钥</returns>
        [HttpGet("{Node}/DumpPrivkey/{Address}")]
        public async Task<BaseRsp<DumpPrivkey>> DumpPrivkey(string Node, string Address)
        {
            return await CallRpc<DumpPrivkey>(Node, new BaseRpc() { method = RpcMethod.DumpPrivkey.ToString().ToLower(), _params = new object[] { Address } });
        }

        /// <summary>
        /// 将指定的私钥导入钱包，要导入的私钥应当采用WIF格式， 例如可以使用dumpprivkey调用获得。
        /// </summary>
        /// <param name="Node">节点名称, 如: test</param>
        /// <param name="content">要导入的私钥</param>
        /// <returns></returns>
        [HttpPost("{Node}/ImportPrivkey")]
        public async Task<BaseRsp<ImportPrivkey>> ImportPrivkey(string Node, [FromBody]ImportPrivkeyParams content)
        {
            var @params = new List<object>() { content.PrivateKey };

            if (!string.IsNullOrEmpty(content.Label))
            {
                @params.Add(content.Label);

                if (content.Rescan != null)
                {
                    @params.Add(content.Rescan);
                }
            }

            return await CallRpc<ImportPrivkey>(Node, new BaseRpc() { method = RpcMethod.ImportPrivkey.ToString().ToLower(), _params = @params.ToArray() });
        }

        /// <summary>
        /// ClearAllCkeyForCoolMiner
        /// </summary>
        /// <param name="Node">节点名称, 如: test</param>
        /// <returns></returns>
        [HttpGet("{Node}/DropPrivkey")]
        public async Task<BaseRsp<object>> DropPrivkey(string Node)
        {
            return await CallRpc<object>(Node, new BaseRpc() { method = RpcMethod.DropPrivkey.ToString().ToLower() });
        }

        /// <summary>
        /// 获取节点基础信息
        /// </summary>
        /// <param name="Node">节点名称, 如: test</param>
        /// <returns></returns>
        [HttpGet("{Node}/GetInfo")]
        public async Task<BaseRsp<NodeEnvInfo>> GetInfo(string Node)
        {
            return await CallRpc<NodeEnvInfo>(Node, new BaseRpc() { method = RpcMethod.GetInfo.ToString().ToLower() });
        }

        /// <summary>
        /// 获取指定地址的相关信息
        /// </summary>
        /// <param name="Node">节点名称, 如: test</param>
        /// <param name="Address">地址</param>
        /// <returns>关于指定地址的信息</returns>
        [HttpGet("{Node}/ValidateAddress/{Address}")]
        public async Task<BaseRsp<dynamic>> ValidateAddress(string Node, string Address)
        {
            return await CallRpc<dynamic>(Node, new BaseRpc() { method = RpcMethod.ValidateAddress.ToString().ToLower(), _params = new object[] { Address } });
        }

        /// <summary>
        /// GetTxHashByAddress
        /// </summary>
        /// <param name="Node">节点名称, 如: test</param>
        /// <param name="Address">地址</param>
        /// <param name="Height">高度</param>
        /// <returns></returns>
        [HttpGet("{Node}/GetTxHashByAddress/{Address}/{Height}")]
        public async Task<BaseRsp<dynamic>> GetTxHashByAddress(string Node, string Address, uint Height)
        {
            return await CallRpc<dynamic>(Node, new BaseRpc() { method = RpcMethod.GetTxHashByAddress.ToString().ToLower(), _params = new object[] { Address } });
        }

        /// <summary>
        /// 获取节点网络信息
        /// </summary>
        /// <param name="Node">节点名称, 如: test</param>
        /// <returns></returns>
        [HttpGet("{Node}/GetNetworkInfo")]
        public async Task<BaseRsp<NetworkInfo>> GetNetworkInfo(string Node)
        {
            return await CallRpc<NetworkInfo>(Node, new BaseRpc() { method = RpcMethod.GetNetworkInfo.ToString().ToLower() });
        }

        /// <summary>
        /// 获取区块链的当前状态
        /// </summary>
        /// <param name="Node">节点名称, 如: test</param>
        /// <returns>描述区块链当前状态的对象</returns>
        [HttpGet("{Node}/GetBlockChainInfo")]
        public async Task<BaseRsp<ChainInfo>> GetBlockChainInfo(string Node)
        {
            return await CallRpc<ChainInfo>(Node, new BaseRpc() { method = RpcMethod.GetBlockchainInfo.ToString().ToLower() });
        }

        /// <summary>
        /// 获取节点上最优链上最后一个区块的哈希
        /// </summary>
        /// <param name="Node">节点名称, 如: test</param>
        /// <returns>最高位的区块哈希</returns>
        [HttpGet("{Node}/GetBestBlockHash")]
        public async Task<BaseRsp<string>> GetBestBlockHash(string Node)
        {
            return await CallRpc<string>(Node, new BaseRpc() { method = RpcMethod.GetBestBlockHash.ToString().ToLower() });
        }

        /// <summary>
        /// 获取指定哈希的区块信息
        /// </summary>
        /// <param name="Node">节点名称, 如: test</param>
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
        /// <param name="Node">节点名称, 如: test</param>
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
        /// <param name="Node">节点名称, 如: test</param>
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
        /// <param name="Node">节点名称, 如: test</param>
        /// <returns></returns>
        [HttpGet("{Node}/GetDifficulty")]
        public async Task<BaseRsp<int>> GetDifficulty(string Node)
        {
            return await CallRpc<int>(Node, new BaseRpc() { method = RpcMethod.GetDifficulty.ToString().ToLower() });
        }


        /// <summary>
        /// 获取区块检查点
        /// </summary>
        /// <param name="Node">节点名称, 如: test</param>
        /// <returns></returns>
        [HttpGet("{Node}/ListCheckPoint")]
        public async Task<BaseRsp<dynamic>> ListCheckPoint(string Node)
        {
            return await CallRpc<dynamic>(Node, new BaseRpc() { method = RpcMethod.ListCheckPoint.ToString().ToLower() });
        }

        /// <summary>
        /// 验证本地区块链数据库中的每个成员
        /// </summary>
        /// <param name="Node">节点名称, 如: test</param>
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
        /// <param name="Node">节点名称, 如: test</param>
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
        /// <param name="Node">节点名称, 如: test</param>
        /// <returns></returns>
        [HttpGet("{Node}/GetTotalCoin")]
        public async Task<BaseRsp<dynamic>> GetTotalCoin(string Node)
        {
            return await CallRpc<dynamic>(Node, new BaseRpc() { method = RpcMethod.GetTotalCoin.ToString().ToLower() });
        }

        /// <summary>
        /// 获取由指定应用发行的资产总和
        /// </summary>
        /// <param name="Node">节点名称, 如: test</param>
        /// <param name="ScriptId">应用RegId</param>
        /// <returns></returns>
        [HttpGet("{Node}/GetTotalAssets/{ScriptId}")]
        public async Task<BaseRsp<dynamic>> GetTotalAssets(string Node, string ScriptId)
        {
            return await CallRpc<dynamic>(Node, new BaseRpc() { method = RpcMethod.GetTotalAssets.ToString().ToLower(), _params = new object[] { ScriptId } });
        }

        ///// <summary>
        ///// 获取挖矿相关的信息
        ///// </summary>
        ///// <param name="Node">节点名称, 如: test</param>
        ///// <returns></returns>
        //[HttpGet("{Node}/GetMiningInfo")]
        //public async Task<BaseRsp<MiningInfo>> GetMiningInfo(string Node)
        //{
        //    return await CallRpc<MiningInfo>(Node, new BaseRpc() { method = RpcMethod.GetMiningInfo.ToString().ToLower() });
        //}

        ///// <summary>
        ///// 获取基于最近n个区块估算的全网每秒可生成的哈希数量
        ///// </summary>
        ///// <param name="Node">节点名称, 如: test</param>
        ///// <param name="Blocks">用于估算的区块数量，默认值：120，设置为-1则使用自上次 难度变化之后的所有区块进行估算</param>
        ///// <param name="Height">用于计算平均值的最后一个区块高度。默认值：-1，表示使用 最高位区块</param>
        ///// <returns>估算的哈希生成速率</returns>
        //[HttpGet("{Node}/GetNetworkHashPS/{Blocks}/{Height}")]
        //public async Task<BaseRsp<MiningInfo>> GetNetworkHashPS(string Node, int Blocks, int Height)
        //{
        //    return await CallRpc<MiningInfo>(Node, new BaseRpc() { method = RpcMethod.GetNetworkHashPS.ToString().ToLower(), _params = new object[] { Blocks, Height } });
        //}

        ///// <summary>
        ///// 提交一个区块，进行验证，然后广播到网络中
        ///// </summary>
        ///// <param name="Node">节点名称, 如: test</param>
        ///// <param name="params">参数</param>
        ///// <returns>成功时返回null，否则返回错误信息</returns>
        //[HttpPost("{Node}/SubmitBlock")]
        //public async Task<BaseRsp<dynamic>> SubmitBlock(string Node, [FromBody]SubmitBlockParams @params)
        //{
        //    var paramsArr = new List<dynamic>() { @params.HexData };

        //    if (@params.Parameters != null)
        //    {
        //        paramsArr.Add(JsonConvert.SerializeObject(@params.Parameters));
        //    }

        //    return await CallRpc<dynamic>(Node, new BaseRpc() { method = RpcMethod.SubmitBlock.ToString().ToLower(), _params = paramsArr.ToArray() });
        //}

        /// <summary>
        /// 获取转账交易的RAW
        /// </summary>
        /// <param name="Node">节点名称, 如: test</param>
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
        /// <param name="Node">节点名称, 如: test</param>
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
        /// <param name="Node">节点名称, 如: test</param>
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
        /// <param name="Node">节点名称, 如: test</param>
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
        /// 将钱包文件wallet.data安全地拷贝到指定文件或目录。 该调用需要节点启用钱包支持
        /// </summary>
        /// <param name="Node">节点名称, 如: test</param>
        /// <param name="params">参数</param>
        /// <returns>成功时backupwallet调用返回null，否则返回一个错误对象</returns>
        [HttpPost("{Node}/BackupWallet")]
        public async Task<BaseRsp<bool>> BackupWallet(string Node, [FromBody]BackupWalletParams @params)
        {
            return await CallRpc<bool>(Node, new BaseRpc() { method = RpcMethod.BackupWallet.ToString().ToLower(), _params = new object[] { @params.Destination } });
        }

        /// <summary>
        /// 将指定的密文加密钱包。该操作只需调用一次，一旦启用加密， 每次需要使用钱包中的密钥时，就需要输入密文。
        /// </summary>
        /// <param name="Node">节点名称, 如: test</param>
        /// <param name="params">参数</param>
        /// <returns>返回一个提醒信息，提示钱包已加密、节点重启。</returns>
        [HttpPost("{Node}/EncryptWallet")]
        public async Task<BaseRsp<dynamic>> EncryptWallet(string Node, [FromBody]EncryptWalletParams @params)
        {
            return await CallRpc<dynamic>(Node, new BaseRpc() { method = RpcMethod.EncryptWallet.ToString().ToLower(), _params = new object[] { @params.Passphrase } });
        }

        /// <summary>
        /// 获取指定地址的相关信息
        /// </summary>
        /// <param name="Node">节点名称, 如: test</param>
        /// <param name="Address">地址</param>
        /// <returns>关于指定地址的信息</returns>
        [HttpGet("{Node}/GetAccountInfo/{Address}")]
        public async Task<BaseRsp<AccountInfo>> GetAccountInfo(string Node, string Address)
        {
            return await CallRpc<AccountInfo>(Node, new BaseRpc() { method = RpcMethod.GetAccountInfo.ToString().ToLower(), _params = new object[] { Address } });
        }


        /// <summary>
        /// 获取一个用于接收支付的新的比特币地址，如果调用时指定了 账户，那么该地址接收到的支付将计入该账户
        /// </summary>
        /// <param name="Node">节点名称, 如: test</param>
        /// <param name="IsMiner">是否为旷工地址</param>
        /// <returns>一个新的地址</returns>
        [HttpGet("{Node}/GetNewAddress")]
        public async Task<BaseRsp<dynamic>> GetNewAddress(string Node, bool IsMiner = false)
        {
            return await CallRpc<dynamic>(Node, new BaseRpc() { method = RpcMethod.GetNewAddress.ToString().ToLower(), _params = new object[] { IsMiner } });
        }

        /// <summary>
        /// 获取指定交易的详情
        /// </summary>
        /// <param name="Node">节点名称, 如: test</param>
        /// <param name="Hash">交易哈希</param>
        /// <returns>交易详情</returns>
        [HttpGet("{Node}/GetTxDetail/{Hash}")]
        public async Task<BaseRsp<TxDetail>> GetTxDetail(string Node, string Hash)
        {
            return await CallRpc<TxDetail>(Node, new BaseRpc() { method = RpcMethod.GetTxDetail.ToString().ToLower(), _params = new object[] { Hash } });
        }

        /// <summary>
        /// 列出当前未确认的交易
        /// </summary>
        /// <param name="Node">节点名称, 如: test</param>
        /// <returns>交易哈希列表</returns>
        [HttpGet("{Node}/ListUnconfirmedTx")]
        public async Task<BaseRsp<string[]>> ListUnconfirmedTx(string Node)
        {
            return await CallRpc<string[]>(Node, new BaseRpc() { method = RpcMethod.ListUnconfirmedTx.ToString().ToLower() });
        }

        /// <summary>
        /// 获取钱包节点的信息
        /// </summary>
        /// <param name="Node">节点名称, 如: test</param>
        /// <returns>钱包节点的信息</returns>
        [HttpGet("{Node}/GetWalletInfo")]
        public async Task<BaseRsp<WalletInfo>> GetWalletInfo(string Node)
        {
            return await CallRpc<WalletInfo>(Node, new BaseRpc() { method = RpcMethod.GetWalletInfo.ToString().ToLower() });
        }

        /// <summary>
        /// 获取节点上的地址列表
        /// </summary>
        /// <param name="Node">节点名称, 如: test</param>
        /// <returns></returns>
        [HttpGet("{Node}/ListAddr")]
        public async Task<BaseRsp<dynamic>> ListAddr(string Node)
        {
            return await CallRpc<dynamic>(Node, new BaseRpc() { method = RpcMethod.ListAddr.ToString().ToLower() });
        }

        /// <summary>
        /// 获取最近发生的与钱包有关的交易清单。该调用需要节点启用钱包功能。
        /// </summary>
        /// <param name="Node">节点名称, 如: test</param>
        /// <param name="params">参数</param>
        /// <returns>返回指定数量的交易数组</returns>
        [HttpPost("{Node}/ListTransactions")]
        public async Task<BaseRsp<TransactionInfo[]>> ListTransactions(string Node, [FromBody]ListTransactionsParams @params)
        {
            var paramsArr = new List<object>() { };

            if (!string.IsNullOrEmpty(@params.Address))
            {
                paramsArr.Add(@params.Address);

                if (@params.Count > 0)
                {
                    paramsArr.Add(@params.Count);

                    if (@params.Skip > 0)
                    {
                        paramsArr.Add(@params.Skip);
                    }
                }
            }

            return await CallRpc<TransactionInfo[]>(Node, new BaseRpc() { method = RpcMethod.ListTransactions.ToString().ToLower(), _params = paramsArr.ToArray() });
        }

        /// <summary>
        /// 获取最近发生的与钱包有关的所有交易[哈希]清单, 包含未确认交易, 调用需要节点启用钱包功能。
        /// </summary>
        /// <param name="Node">节点名称, 如: test</param>
        /// <param name="params">参数</param>
        /// <returns>返回指定数量的交易数组</returns>
        [HttpPost("{Node}/ListTx")]
        public async Task<BaseRsp<dynamic>> ListTx(string Node, [FromBody]ListTxParams @params)
        {
            var paramsArr = new List<object>() { };

            if (@params.Count > 0)
            {
                paramsArr.Add(@params.Count);

                if (@params.Skip > 0)
                {
                    paramsArr.Add(@params.Skip);
                }
            }

            return await CallRpc<dynamic>(Node, new BaseRpc() { method = RpcMethod.ListTx.ToString().ToLower(), _params = paramsArr.ToArray() });
        }

        /// <summary>
        /// 获取最近发生的与钱包有关的合约交易[哈希]清单。该调用需要节点启用钱包功能。
        /// </summary>
        /// <param name="Node">节点名称, 如: test</param>
        /// <param name="params">参数</param>
        /// <returns>返回指定数量的交易数组</returns>
        [HttpPost("{Node}/ListContractTx")]
        public async Task<BaseRsp<dynamic>> ListContractTx(string Node, [FromBody]ListContractTxParams @params)
        {
            var paramsArr = new List<object>() { };

            if (@params.Count > 0)
            {
                paramsArr.Add(@params.Count);

                if (@params.Skip > 0)
                {
                    paramsArr.Add(@params.Skip);
                }
            }

            return await CallRpc<dynamic>(Node, new BaseRpc() { method = RpcMethod.ListContractTx.ToString().ToLower(), _params = paramsArr.ToArray() });
        }

        /// <summary>
        /// 获取指定交易的详情
        /// </summary>
        /// <param name="Node">节点名称, 如: test</param>
        /// <param name="Hash">交易哈希</param>
        /// <returns>交易详情</returns>
        [HttpGet("{Node}/GetTransaction/{Hash}")]
        public async Task<BaseRsp<TransactionDetailInfo>> GetTransaction(string Node, string Hash)
        {
            return await CallRpc<TransactionDetailInfo>(Node, new BaseRpc() { method = RpcMethod.GetTransaction.ToString().ToLower(), _params = new object[] { Hash } });
        }

        /// <summary>
        /// 创建激活交易, 并提交到链上
        /// </summary>
        /// <param name="Node">节点名称, 如: test</param>
        /// <param name="params">参数</param>
        /// <returns>返回该交易的哈希</returns>
        [HttpPost("{Node}/RegistAccountTx")]
        public async Task<BaseRsp<dynamic>> RegistAccountTx(string Node, [FromBody]RegistAccountTxParams @params)
        {
            return await CallRpc<dynamic>(Node, new BaseRpc() { method = RpcMethod.RegistAccountTx.ToString().ToLower(), _params = new object[] { @params.Address, @params.Fee } });
        }

        /// <summary>
        /// 创建激活交易, 并提交到链上
        /// </summary>
        /// <param name="Node">节点名称, 如: test</param>
        /// <param name="params">参数</param>
        /// <returns>返回该交易的哈希</returns>
        [HttpPost("{Node}/RegisterAccountTx")]
        public async Task<BaseRsp<dynamic>> RegisterAccountTx(string Node, [FromBody]RegistAccountTxParams @params)
        {
            return await CallRpc<dynamic>(Node, new BaseRpc() { method = RpcMethod.RegisterAccountTx.ToString().ToLower(), _params = new object[] { @params.Address, @params.Fee } });
        }

        /// <summary>
        /// 创建调用合约交易, 并提交到链上
        /// </summary>
        /// <param name="Node">节点名称, 如: test</param>
        /// <param name="params">参数</param>
        /// <returns>返回该交易的哈希</returns>
        [HttpPost("{Node}/CreateContractTx")]
        public async Task<BaseRsp<dynamic>> CreateContractTx(string Node, [FromBody]CreateContractTxParams @params)
        {
            var paramsArr = new List<object>() { @params.SenderAddr, @params.AppRegId, @params.Amount, @params.Contract, @params.Fee };

            if (@params.Height > 0)
            {
                paramsArr.Add(@params.Height);
            }

            return await CallRpc<dynamic>(Node, new BaseRpc() { method = RpcMethod.CreateContractTx.ToString().ToLower(), _params = paramsArr.ToArray() });
        }

        /// <summary>
        /// 创建投票交易, 并提交到链上
        /// </summary>
        /// <param name="Node">节点名称, 如: test</param>
        /// <param name="params">参数</param>
        /// <returns>返回该交易的哈希</returns>
        [HttpPost("{Node}/CreateDelegateTx")]
        public async Task<BaseRsp<dynamic>> CreateDelegateTx(string Node, [FromBody]CreateDelegateTxParams @params)
        {
            var paramsArr = new List<object>() { @params.Addr, JsonConvert.SerializeObject(@params.Opervotes), @params.Fee };

            if (@params.Height > 0)
            {
                paramsArr.Add(@params.Height);
            }

            return await CallRpc<dynamic>(Node, new BaseRpc() { method = RpcMethod.CreateDelegateTx.ToString().ToLower(), _params = paramsArr.ToArray() });
        }

        /// <summary>
        /// 创建投票交易
        /// </summary>
        /// <param name="Node">节点名称, 如: test</param>
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
        /// 创建投票交易
        /// </summary>
        /// <param name="Node">节点名称, 如: test</param>
        /// <param name="params">参数</param>
        /// <returns>返回该交易RAW</returns>
        [HttpPost("{Node}/RegisterAppTx")]
        public async Task<BaseRsp<dynamic>> RegisterAppTx(string Node, [FromBody]RegisterAppTxParams @params)
        {
            var paramsArr = new List<object>() { @params.Addr, @params.FilePath, @params.Fee };

            if (@params.Height > 0)
            {
                paramsArr.Add(@params.Height);

                if (!string.IsNullOrEmpty(@params.ScriptDesc))
                {
                    paramsArr.Add(@params.ScriptDesc);
                }
            }

            return await CallRpc<dynamic>(Node, new BaseRpc() { method = RpcMethod.RegisterAppTx.ToString().ToLower(), _params = paramsArr.ToArray() });
        }

        private async Task<BaseRsp<T>> CallRpc<T>(string nodeName, BaseRpc postData)
        {
            try
            {
                var client = _httpClientFactory.CreateClient(nodeName);

                if (client?.BaseAddress == null)
                {
                    return new BaseRsp<T>()
                    {
                        success = false,
                        error = 1404,
                        msg = "找不到指定的节点",
                    };
                }

                var response = await client.PostAsync(client.BaseAddress, new StringContent(JsonConvert.SerializeObject(postData), Encoding.UTF8, "application/json"));

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var json = response.Content.ReadAsStringAsync().Result;
                    var model = response.Content.ReadAsAsync<BaseRpcMsg<T>>().Result;

                    return new BaseRsp<T>()
                    {
                        success = model.error == null,
                        error = model.error?.code ?? 0,
                        msg = model.error?.message ?? null,
                        data = model.result
                    };
                }
                else
                {
                    return new BaseRsp<T>()
                    {
                        success = false,
                        error = 1404,
                        msg = "远程服务发生错误",
                    };
                }
            }
            catch (Exception ex)
            {
                return new BaseRsp<T>()
                {
                    error = 1005,
                    success = false,
                    msg = ex.Message
                };
            }
        }
    }
}