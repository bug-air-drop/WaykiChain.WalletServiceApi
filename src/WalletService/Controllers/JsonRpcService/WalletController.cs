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
    public class WalletController : BaseService
    {
        public WalletController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {

        }

        /// <summary>
        /// 获取节点基础信息
        /// </summary>
        /// <param name="Node">节点名称, 如: testnet</param>
        /// <returns></returns>
        [HttpGet("{Node}/GetInfo")]
        public async Task<BaseRsp<NodeEnvInfo>> GetInfo(string Node)
        {
            return await CallRpc<NodeEnvInfo>(Node, new BaseRpc() { method = RpcMethod.GetInfo.ToString().ToLower() });
        }


        /// <summary>
        /// 生成CheckPoint
        /// </summary>
        /// <param name="Node">节点名称, 如: testnet</param>
        /// <param name="params">参数</param>
        /// <returns>结果</returns>
        [HttpPost("{Node}/GenCheckPoint")]
        public async Task<BaseRsp<dynamic>> GenCheckPoint(string Node, [FromBody]GenCheckPointParams @params)
        {
            return await CallRpc<dynamic>(Node, new BaseRpc() { method = RpcMethod.GenCheckPoint.ToString().ToLower(), _params = new object[] { @params.PrivateKey, @params.FilePath } });
        }

        /// <summary>
        /// 设置CheckPoint
        /// </summary>
        /// <param name="Node">节点名称, 如: testnet</param>
        /// <param name="params">参数</param>
        /// <returns>结果</returns>
        [HttpPost("{Node}/SetCheckPoint")]
        public async Task<BaseRsp<dynamic>> SetCheckPoint(string Node, [FromBody]SetCheckPointParams @params)
        {
            return await CallRpc<dynamic>(Node, new BaseRpc() { method = RpcMethod.SetCheckPoint.ToString().ToLower(), _params = new object[] { @params.FilePath } });
        }

        /// <summary>
        /// 获取指定地址的相关信息
        /// </summary>
        /// <param name="Node">节点名称, 如: testnet</param>
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
        /// <param name="Node">节点名称, 如: testnet</param>
        /// <param name="Address">地址</param>
        /// <param name="Height">高度</param>
        /// <returns></returns>
        [HttpGet("{Node}/GetTxHashByAddress/{Address}/{Height}")]
        public async Task<BaseRsp<dynamic>> GetTxHashByAddress(string Node, string Address, uint Height)
        {
            return await CallRpc<dynamic>(Node, new BaseRpc() { method = RpcMethod.GetTxHashByAddress.ToString().ToLower(), _params = new object[] { Address } });
        }


        /// <summary>
        /// 将钱包文件wallet.data安全地拷贝到指定文件或目录。 该调用需要节点启用钱包支持
        /// </summary>
        /// <param name="Node">节点名称, 如: testnet</param>
        /// <param name="params">参数</param>
        /// <returns>成功时backupwallet调用返回null，否则返回一个错误对象</returns>
        [HttpPost("{Node}/BackupWallet")]
        public async Task<BaseRsp<bool>> BackupWallet(string Node, [FromBody]BackupWalletParams @params)
        {
            return await CallRpc<bool>(Node, new BaseRpc() { method = RpcMethod.BackupWallet.ToString().ToLower(), _params = new object[] { @params.Destination } });
        }

        /// <summary>
        /// 导出指定地址对应的私钥，格式为WIF。该调用需要 节点启用钱包支持，而且钱包解锁或未加密
        /// </summary>
        /// <param name="Node">节点名称, 如: testnet</param>
        /// <param name="Address">一个钱包内的P2PKH地址</param>
        /// <returns>指定地址对应的WIF格式的私钥</returns>
        [HttpGet("{Node}/DumpPrivkey/{Address}")]
        public async Task<BaseRsp<DumpPrivkey>> DumpPrivkey(string Node, string Address)
        {
            return await CallRpc<DumpPrivkey>(Node, new BaseRpc() { method = RpcMethod.DumpPrivkey.ToString().ToLower(), _params = new object[] { Address } });
        }

        /// <summary>
        /// 将钱包里的所有密钥导出到指定的文件。该调用 需要节点启用钱包，并且钱包解锁或未加密。
        /// </summary>
        /// <param name="Node">节点名称, 如: testnet</param>
        /// <param name="params">参数</param>
        /// <returns>成功时，dumpwallet调用返回null，否则返回一个错误对象。</returns>
        [HttpPost("{Node}/DumpWallet")]
        public async Task<BaseRsp<dynamic>> DumpWallet(string Node, [FromBody]DumpWalletParams @params)
        {
            return await CallRpc<dynamic>(Node, new BaseRpc() { method = RpcMethod.DumpWallet.ToString().ToLower(), _params = new object[] { @params.FileName } });
        }

        /// <summary>
        /// 将指定的密文加密钱包。该操作只需调用一次，一旦启用加密， 每次需要使用钱包中的密钥时，就需要输入密文。
        /// </summary>
        /// <param name="Node">节点名称, 如: testnet</param>
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
        /// <param name="Node">节点名称, 如: testnet</param>
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
        /// <param name="Node">节点名称, 如: testnet</param>
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
        /// <param name="Node">节点名称, 如: testnet</param>
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
        /// <param name="Node">节点名称, 如: testnet</param>
        /// <returns>交易哈希列表</returns>
        [HttpGet("{Node}/ListUnconfirmedTx")]
        public async Task<BaseRsp<string[]>> ListUnconfirmedTx(string Node)
        {
            return await CallRpc<string[]>(Node, new BaseRpc() { method = RpcMethod.ListUnconfirmedTx.ToString().ToLower() });
        }

        /// <summary>
        /// 获取钱包节点的信息
        /// </summary>
        /// <param name="Node">节点名称, 如: testnet</param>
        /// <returns>钱包节点的信息</returns>
        [HttpGet("{Node}/GetWalletInfo")]
        public async Task<BaseRsp<WalletInfo>> GetWalletInfo(string Node)
        {
            return await CallRpc<WalletInfo>(Node, new BaseRpc() { method = RpcMethod.GetWalletInfo.ToString().ToLower() });
        }

        /// <summary>
        /// 将指定的私钥导入钱包，要导入的私钥应当采用WIF格式， 例如可以使用dumpprivkey调用获得。
        /// </summary>
        /// <param name="Node">节点名称, 如: testnet</param>
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
        /// <param name="Node">节点名称, 如: testnet</param>
        /// <returns></returns>
        [HttpGet("{Node}/DropPrivkey")]
        public async Task<BaseRsp<object>> DropPrivkey(string Node)
        {
            return await CallRpc<object>(Node, new BaseRpc() { method = RpcMethod.DropPrivkey.ToString().ToLower() });
        }

        /// <summary>
        /// 导入钱包转储文件（通过DumpWallet调用获得）。 该文件中的私钥将添加到节点钱包中。由于加入了新的私钥，该调用可能需要重新扫描区块链。
        /// </summary>
        /// <param name="Node">节点名称, 如: testnet</param>
        /// <param name="params">参数</param>
        /// <returns>成功时，调用返回null，否则返回一个错误对象。</returns>
        [HttpPost("{Node}/ImportWallet")]
        public async Task<BaseRsp<dynamic>> ImportWallet(string Node, [FromBody]ImportWalletParams @params)
        {
            return await CallRpc<dynamic>(Node, new BaseRpc() { method = RpcMethod.ImportWallet.ToString().ToLower(), _params = new object[] { @params.FileName } });
        }

        /// <summary>
        /// 获取节点上的地址列表
        /// </summary>
        /// <param name="Node">节点名称, 如: testnet</param>
        /// <returns></returns>
        [HttpGet("{Node}/ListAddr")]
        public async Task<BaseRsp<dynamic>> ListAddr(string Node)
        {
            return await CallRpc<dynamic>(Node, new BaseRpc() { method = RpcMethod.ListAddr.ToString().ToLower() });
        }

        /// <summary>
        /// 获取最近发生的与钱包有关的交易清单。该调用需要节点启用钱包功能。
        /// </summary>
        /// <param name="Node">节点名称, 如: testnet</param>
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
        /// <param name="Node">节点名称, 如: testnet</param>
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
        /// <param name="Node">节点名称, 如: testnet</param>
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
        /// <param name="Node">节点名称, 如: testnet</param>
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
        /// <param name="Node">节点名称, 如: testnet</param>
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
        /// <param name="Node">节点名称, 如: testnet</param>
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
        /// <param name="Node">节点名称, 如: testnet</param>
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
        /// <param name="Node">节点名称, 如: testnet</param>
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
        /// 创建注册应用交易, 并提交到链上
        /// </summary>
        /// <param name="Node">节点名称, 如: testnet</param>
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

        /// <summary>
        /// 设置交易的手续费用， 以每kB计算
        /// </summary>
        /// <param name="Node">节点名称, 如: testnet</param>
        /// <param name="params">参数</param>
        /// <returns>返回操作结果</returns>
        [HttpPost("{Node}/SetTxFee")]
        public async Task<BaseRsp<bool>> SetTxFee(string Node, [FromBody]SetTxFeeParams @params)
        {
            return await CallRpc<bool>(Node, new BaseRpc() { method = RpcMethod.SetTxFee.ToString().ToLower(), _params = new object[] { @params.Amount } });
        }

        /// <summary>
        /// 从内存中移除钱包加密密钥，锁定钱包。调用此方法后，您需要再次调用walletpassphrase才能调用任何需要解锁钱包的方法
        /// </summary>
        /// <param name="Node">节点名称, 如: testnet</param>
        /// <returns>交易详情</returns>
        [HttpGet("{Node}/WalletLock")]
        public async Task<BaseRsp<dynamic>> WalletLock(string Node)
        {
            return await CallRpc<dynamic>(Node, new BaseRpc() { method = RpcMethod.WalletLock.ToString().ToLower() });
        }

        /// <summary>
        /// 修改钱包密码
        /// </summary>
        /// <param name="Node">节点名称, 如: testnet</param>
        /// <param name="params">参数</param>
        /// <returns>返回操作结果</returns>
        [HttpPost("{Node}/WalletPassphraseChange")]
        public async Task<BaseRsp<dynamic>> WalletPassphraseChange(string Node, [FromBody]WalletPassphraseChangeParams @params)
        {
            return await CallRpc<dynamic>(Node, new BaseRpc() { method = RpcMethod.WalletPassphraseChange.ToString().ToLower(), _params = new object[] { @params.OldPassphrase, @params.NewPassphrase } });
        }

        /// <summary>
        /// 解锁钱包
        /// </summary>
        /// <param name="Node">节点名称, 如: testnet</param>
        /// <param name="params">参数</param>
        /// <returns>返回该交易RAW</returns>
        [HttpPost("{Node}/WalletPassphrase")]
        public async Task<BaseRsp<dynamic>> WalletPassphrase(string Node, [FromBody]WalletPassphraseParams @params)
        {
            var paramsArr = new List<object>() { @params.Passphrase };

            if (@params.Timeout > 0)
            {
                paramsArr.Add(@params.Timeout);
            }

            return await CallRpc<dynamic>(Node, new BaseRpc() { method = RpcMethod.WalletPassphrase.ToString().ToLower(), _params = paramsArr.ToArray() });
        }

        /// <summary>
        /// 解锁钱包
        /// </summary>
        /// <param name="Node">节点名称, 如: testnet</param>
        /// <param name="params">参数</param>
        /// <returns>返回该交易RAW</returns>
        [HttpPost("{Node}/SetGenerate")]
        public async Task<BaseRsp<dynamic>> SetGenerate(string Node, [FromBody]SetGenerateParams @params)
        {
            var paramsArr = new List<object>() { @params.Generate };

            if (@params.GenerateLimit > 0)
            {
                paramsArr.Add(@params.GenerateLimit);
            }

            return await CallRpc<dynamic>(Node, new BaseRpc() { method = RpcMethod.SetGenerate.ToString().ToLower(), _params = paramsArr.ToArray() });
        }

        /// <summary>
        /// 列出所有的合约应用
        /// </summary>
        /// <param name="Node">节点名称, 如: testnet</param>
        /// <param name="ShowDetail">是否列出合约代码[慎重]</param>
        /// <returns>列表</returns>
        [HttpGet("{Node}/ListApp/{ShowDetail}")]
        public async Task<BaseRsp<dynamic>> ListApp(string Node, bool ShowDetail)
        {
            return await CallRpc<dynamic>(Node, new BaseRpc() { method = RpcMethod.ListApp.ToString().ToLower(), _params = new object[] { ShowDetail } });
        }

        /// <summary>
        /// 获取合约应用的信息
        /// </summary>
        /// <param name="Node">节点名称, 如: testnet</param>
        /// <param name="AppId">应用ID</param>
        /// <returns>列表</returns>
        [HttpGet("{Node}/GetAppInfo/{AppId}")]
        public async Task<BaseRsp<dynamic>> GetAppInfo(string Node, string AppId)
        {
            return await CallRpc<dynamic>(Node, new BaseRpc() { method = RpcMethod.GetAppInfo.ToString().ToLower(), _params = new object[] { AppId } });
        }

        /// <summary>
        /// 创建具有指定地址的块
        /// </summary>
        /// <param name="Node">节点名称, 如: testnet</param>
        /// <param name="Addr">地址</param>
        /// <returns>列表</returns>
        [HttpGet("{Node}/GenerateBlock/{Addr}")]
        public async Task<BaseRsp<dynamic>> GenerateBlock(string Node, string Addr)
        {
            return await CallRpc<dynamic>(Node, new BaseRpc() { method = RpcMethod.GenerateBlock.ToString().ToLower(), _params = new object[] { Addr } });
        }

        /// <summary>
        /// 获取缓存中的交易列表
        /// </summary>
        /// <param name="Node">节点名称, 如: testnet</param>
        /// <returns>列表</returns>
        [HttpGet("{Node}/ListTxCache")]
        public async Task<BaseRsp<dynamic>> ListTxCache(string Node)
        {
            return await CallRpc<dynamic>(Node, new BaseRpc() { method = RpcMethod.ListTxCache.ToString().ToLower() });
        }

        /// <summary>
        /// 获取合约应用内部数据
        /// </summary>
        /// <param name="Node">节点名称, 如: testnet</param>
        /// <param name="AppId">应用的RegId</param>
        /// <param name="Key">Key</param>
        /// <returns>列表</returns>
        [HttpGet("{Node}/GetAppData/{AppId}/{Key}")]
        public async Task<BaseRsp<dynamic>> GetAppData(string Node, string AppId, string Key)
        {
            return await CallRpc<dynamic>(Node, new BaseRpc() { method = RpcMethod.GetAppData.ToString().ToLower(), _params = new object[] { AppId, Key } });
        }

        /// <summary>
        /// 获取合约应用内部数据
        /// </summary>
        /// <param name="Node">节点名称, 如: testnet</param>
        /// <param name="AppId">应用的RegId</param>
        /// <param name="PageSize">PageSize</param>
        /// <param name="Index">Index</param>
        /// <returns>列表</returns>
        [HttpGet("{Node}/GetAppData/{AppId}/{PageSize}/{Index}")]
        public async Task<BaseRsp<dynamic>> GetAppData(string Node, string AppId, int PageSize, int Index)
        {
            return await CallRpc<dynamic>(Node, new BaseRpc() { method = RpcMethod.GetAppData.ToString().ToLower(), _params = new object[] { AppId, PageSize, Index } });
        }

        /// <summary>
        /// 获取智能合约相关原生数据信息(RAW格式)
        /// </summary>
        /// <param name="Node">节点名称, 如: testnet</param>
        /// <param name="AppId">应用的RegId</param>
        /// <param name="Key">Key</param>
        /// <returns>列表</returns>
        [HttpGet("{Node}/GetAppDataRaw/{AppId}/{Key}")]
        public async Task<BaseRsp<dynamic>> GetAppDataRaw(string Node, string AppId, string Key)
        {
            return await CallRpc<dynamic>(Node, new BaseRpc() { method = RpcMethod.GetAppDataRaw.ToString().ToLower(), _params = new object[] { AppId, Key } });
        }

        /// <summary>
        /// 获取智能合约相关原生数据信息(RAW格式)
        /// </summary>
        /// <param name="Node">节点名称, 如: testnet</param>
        /// <param name="AppId">应用的RegId</param>
        /// <param name="PageSize">PageSize</param>
        /// <param name="Index">Index</param>
        /// <returns>列表</returns>
        [HttpGet("{Node}/GetAppDataRaw/{AppId}/{PageSize}/{Index}")]
        public async Task<BaseRsp<dynamic>> GetAppDataRaw(string Node, string AppId, int PageSize, int Index)
        {
            return await CallRpc<dynamic>(Node, new BaseRpc() { method = RpcMethod.GetAppDataRaw.ToString().ToLower(), _params = new object[] { AppId, PageSize, Index } });
        }

        /// <summary>
        /// 获取已确认的合约应用内部数据
        /// </summary>
        /// <param name="Node">节点名称, 如: testnet</param>
        /// <param name="AppId">应用的RegId</param>
        /// <param name="PageSize">PageSize</param>
        /// <param name="Index">Index</param>
        /// <param name="Count">最小确认数</param>
        /// <returns>列表</returns>
        [HttpGet("{Node}/GetAppConfirmData/{AppId}/{PageSize}/{Index}/{Count}")]
        public async Task<BaseRsp<dynamic>> GetAppConfirmData(string Node, string AppId, int PageSize, int Index, int Count = 1)
        {
            return await CallRpc<dynamic>(Node, new BaseRpc() { method = RpcMethod.GetAppConfirmData.ToString().ToLower(), _params = new object[] { AppId, PageSize, Index, Count } });
        }

        /// <summary>
        /// 用指定地址签名消息
        /// </summary>
        /// <param name="Node">节点名称, 如: testnet</param>
        /// <param name="params">参数</param>
        /// <returns>结果</returns>
        [HttpPost("{Node}/SignMessage")]
        public async Task<BaseRsp<dynamic>> SignMessage(string Node, [FromBody]SignMessageParams @params)
        {
            return await CallRpc<dynamic>(Node, new BaseRpc() { method = RpcMethod.SignMessage.ToString().ToLower(), _params = new object[] { @params.Address, @params.Message } });
        }

        /// <summary>
        /// 发起一笔转账交易
        /// </summary>
        /// <param name="Node">节点名称, 如: testnet</param>
        /// <param name="params">参数</param>
        /// <returns>交易哈希</returns>
        [HttpPost("{Node}/SendToAddress")]
        public async Task<BaseRsp<dynamic>> SendToAddress(string Node, [FromBody]SendToAddressParams @params)
        {
            var paramsArr = new List<object>() { };

            if (!string.IsNullOrEmpty(@params.SendAddress))
            {
                paramsArr.Add(@params.SendAddress);
            }

            paramsArr.Add(@params.RecvAddress);
            paramsArr.Add(@params.Amount);

            return await CallRpc<dynamic>(Node, new BaseRpc() { method = RpcMethod.SendToAddress.ToString().ToLower(), _params = paramsArr.ToArray() });
        }

        /// <summary>
        /// 发起一笔转账交易, 并指定手续费
        /// </summary>
        /// <param name="Node">节点名称, 如: testnet</param>
        /// <param name="params">参数</param>
        /// <returns>交易哈希</returns>
        [HttpPost("{Node}/SendToAddressWithFee")]
        public async Task<BaseRsp<dynamic>> SendToAddressWithFee(string Node, [FromBody]SendToAddressWithFeeParams @params)
        {
            var paramsArr = new List<object>() { };

            if (!string.IsNullOrEmpty(@params.SendAddress))
            {
                paramsArr.Add(@params.SendAddress);
            }

            paramsArr.Add(@params.RecvAddress);
            paramsArr.Add(@params.Amount);
            paramsArr.Add(@params.Fee);

            return await CallRpc<dynamic>(Node, new BaseRpc() { method = RpcMethod.SendToAddressWithFee.ToString().ToLower(), _params = paramsArr.ToArray() });
        }

        /// <summary>
        /// 获取钱包中所有账户的维基币数量，该调用需要节点启用钱包功能。
        /// </summary>
        /// <param name="Node">节点名称, 如: testnet</param>
        /// <returns>返回以wicc为单位的余额列表</returns>
        [HttpGet("{Node}/GetBalance")]
        public async Task<BaseRsp<dynamic>> GetBalance(string Node)
        {
            return await CallRpc<dynamic>(Node, new BaseRpc() { method = RpcMethod.GetBalance.ToString().ToLower() });
        }

        /// <summary>
        /// 获取钱包中指定账户的维基币数量，该调用需要节点启用钱包功能。
        /// </summary>
        /// <param name="Node">节点名称, 如: testnet</param>
        /// <param name="Address">要查看余额的钱包账户，可选，默认值为*，表示全部账户</param>
        /// <param name="MinConf">可计入余额所需要的最小确认数，可选，默认值：1</param>
        /// <returns>返回以wicc为单位的余额</returns>
        [HttpGet("{Node}/GetBalance/{Address}/{MinConf}")]
        public async Task<BaseRsp<dynamic>> GetBalance(string Node, string Address, int MinConf = 1)
        {
            return await CallRpc<dynamic>(Node, new BaseRpc() { method = RpcMethod.GetBalance.ToString().ToLower(), _params = new object[] { Address, MinConf } });
        }

        /// <summary>
        /// 获取钱包中所有地址指定的APP资产总额
        /// </summary>
        /// <param name="Node">节点名称, 如: testnet</param>
        /// <param name="AppId">应用的RegId</param>
        /// <returns>列表</returns>
        [HttpGet("{Node}/GetAssets/{AppId}")]
        public async Task<BaseRsp<dynamic>> GetAssets(string Node, string AppId)
        {
            return await CallRpc<dynamic>(Node, new BaseRpc() { method = RpcMethod.GetAssets.ToString().ToLower(), _params = new object[] { AppId } });
        }

        /// <summary>
        /// 列出指定APP下的资产
        /// </summary>
        /// <param name="Node">节点名称, 如: testnet</param>
        /// <param name="AppId">应用的RegId</param>
        /// <returns>列表</returns>
        [HttpGet("{Node}/ListAsset/{AppId}")]
        public async Task<BaseRsp<dynamic>> ListAsset(string Node, string AppId)
        {
            return await CallRpc<dynamic>(Node, new BaseRpc() { method = RpcMethod.ListAsset.ToString().ToLower(), _params = new object[] { AppId } });
        }

        /// <summary>
        /// 提交交易RAW
        /// </summary>
        /// <param name="Node">节点名称, 如: testnet</param>
        /// <param name="content">交易RAW</param>
        /// <returns>提交结果</returns>
        [HttpPost("{Node}/SubmitTx")]
        public async Task<BaseRsp<dynamic>> SubmitTx(string Node, [FromBody]string content)
        {
            return await CallRpc<dynamic>(Node, new BaseRpc() { method = RpcMethod.SubmitTx.ToString().ToLower(), _params = new object[] { content } });
        }

        /// <summary>
        /// 对字符串进行签名
        /// </summary>
        /// <param name="Node">节点名称, 如: testnet</param>
        /// <param name="params">参数</param>
        /// <returns>签名结果</returns>
        [HttpPost("{Node}/SigStr")]
        public async Task<BaseRsp<dynamic>> SigStr(string Node, [FromBody]SigStrParams @params)
        {
            return await CallRpc<dynamic>(Node, new BaseRpc() { method = RpcMethod.SigStr.ToString().ToLower(), _params = new object[] { @params.Str, @params.Addr } });
        }

        /// <summary>
        /// 获取已确认的合约应用内部数据
        /// </summary>
        /// <param name="Node">节点名称, 如: testnet</param>
        /// <param name="AppId">应用的RegId</param>
        /// <param name="Address">管理员地址???</param>
        /// <param name="Count">最小确认数, 默认为1</param>
        /// <returns>列表</returns>
        [HttpGet("{Node}/GetAppAccountInfo/{AppId}/{Address}/{Count}")]
        public async Task<BaseRsp<dynamic>> GetAppAccountInfo(string Node, string AppId, string Address, int Count = 1)
        {
            return await CallRpc<dynamic>(Node, new BaseRpc() { method = RpcMethod.GetAppAccountInfo.ToString().ToLower(), _params = new object[] { AppId, Address, Count } });
        }

        /// <summary>
        /// 获取合约内部KV数据
        /// </summary>
        /// <param name="Node">节点名称, 如: testnet</param>
        /// <param name="AppId">应用的RegId</param>
        /// <param name="Key">Key</param>
        /// <returns>Value</returns>
        [HttpGet("{Node}/GetAppKeyValue/{AppId}/{Key}")]
        public async Task<BaseRsp<dynamic>> GetAppKeyValue(string Node, string AppId, string Key)
        {
            return await CallRpc<dynamic>(Node, new BaseRpc() { method = RpcMethod.GetAppKeyValue.ToString().ToLower(), _params = new object[] { AppId, Key } });
        }

        /// <summary>
        /// 获取钱包的加密状态
        /// </summary>
        /// <param name="Node">节点名称, 如: testnet</param>
        /// <returns>0 - 未加密, 1 - 钱包已加密,当前未锁定, 2 - 钱包处于锁定状态</returns>
        [HttpGet("{Node}/IsLocked")]
        public async Task<BaseRsp<dynamic>> IsLocked(string Node)
        {
            return await CallRpc<dynamic>(Node, new BaseRpc() { method = RpcMethod.IsLocked.ToString().ToLower() });
        }

        /// <summary>
        /// 用私钥对哈希串进行签名
        /// </summary>
        /// <param name="Node">节点名称, 如: testnet</param>
        /// <param name="params">参数</param>
        /// <returns>签名结果</returns>
        [HttpPost("{Node}/GetSignature")]
        public async Task<BaseRsp<dynamic>> GetSignature(string Node, [FromBody]GetSignatureParams @params)
        {
            return await CallRpc<dynamic>(Node, new BaseRpc() { method = RpcMethod.GetSignature.ToString().ToLower(), _params = new object[] { @params.PrivKey, @params.Hash } });
        }

        /// <summary>
        /// 获取投票的统计信息
        /// </summary>
        /// <param name="Node">节点名称, 如: testnet</param>
        /// <param name="Count">名次, 范围:1~11</param>
        /// <returns>投票统计列表</returns>
        [HttpGet("{Node}/GetDelegateList/{Count}")]
        public async Task<BaseRsp<dynamic>> GetDelegateList(string Node, int Count)
        {
            return await CallRpc<dynamic>(Node, new BaseRpc() { method = RpcMethod.GetDelegateList.ToString().ToLower(), _params = new object[] { Count } });
        }

        /// <summary>
        /// 解析交易RAW
        /// </summary>
        /// <param name="Node">节点名称, 如: testnet</param>
        /// <param name="content">交易RAW</param>
        /// <returns>提交结果</returns>
        [HttpPost("{Node}/DecodeRawTransaction")]
        public async Task<BaseRsp<dynamic>> DecodeRawTransaction(string Node, [FromBody]string content)
        {
            return await CallRpc<dynamic>(Node, new BaseRpc() { method = RpcMethod.DecodeRawTransaction.ToString().ToLower(), _params = new object[] { content } });
        }


    }
}