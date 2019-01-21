using System;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using NBitcoin;
using NBitcoin.Wicc;
using NBitcoin.Wicc.Core;
using WalletServiceApi.Models;

namespace WalletServiceApi.Controllers
{
    /// <summary>
    /// 签名
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    [ErrorActionFilter]
    public class SignController : ControllerBase
    {
        private static readonly Network _mainnet = Wicc.Instance.Mainnet;
        private static readonly Network _testnet = Wicc.Instance.Testnet;

        /// <summary>
        /// 普通交易签名
        /// </summary>
        /// <param name="data">请求体</param>
        /// <returns>结果</returns>
        [HttpPost("Common")]
        public BaseRsp<string> CommonTx(CommonTxReq data)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    CheckAddress(data.From, data.NetType, 2);
                    CheckAddress(data.To, data.NetType, 0);
                }
                catch (Exception ex)
                {
                    return new BaseRsp<string>()
                    {
                        success = false,
                        error = 1001,
                        msg = ex.Message

                    };
                }

                Wallet wt = new Wallet()
                {
                    Network = data.NetType == 1 ? _mainnet : _testnet,
                    Prikey = data.PrivateKey,
                    UserId = new UserId(uint.Parse(data.From.Split('-')[0]), uint.Parse(data.From.Split('-')[1])),
                };

                try
                {
                    var toAddress = data.To.Contains("-") ? new UserId(uint.Parse(data.To.Split('-')[0]), uint.Parse(data.To.Split('-')[1])) : new UserId(data.To, wt.Network);

                    var sign = wt.CreateCommonTxRaw(toAddress, data.Fees, data.Amount, data.ValidHeight == 0 ? GetCurBlockHeight(data) : data.ValidHeight);

                    if (!data.Submit)
                    {
                        return new BaseRsp<string>()
                        {
                            success = true,
                            data = sign
                        };
                    }
                    else
                    {
                        return SubmitTx(data, sign);
                    }
                }
                catch (Exception ex)
                {
                    return new BaseRsp<string>()
                    {
                        success = false,
                        error = 1002,
                        msg = ex.Message
                    };
                }
            }

            return new BaseRsp<string>()
            {
                success = false,
                error = 1001,
            };
        }

        /// <summary>
        /// 激活地址交易签名
        /// </summary>
        /// <param name="data">交易参数</param>
        /// <returns>签名结果</returns>
        [HttpPost("RegisterAccount")]
        public BaseRsp<string> RegisterAccountTx(RegisterAccountTxReq data)
        {
            if (ModelState.IsValid)
            {
                Wallet wt = new Wallet()
                {
                    Network = data.NetType == 1 ? _mainnet : _testnet,
                    Prikey = data.PrivateKey,
                };

                try
                {
                    var sign = wt.GetRegisteAccountRaw(data.Fees, data.ValidHeight == 0 ? GetCurBlockHeight(data) : data.ValidHeight);

                    if (!data.Submit)
                    {
                        return new BaseRsp<string>()
                        {
                            success = true,
                            data = sign
                        };
                    }
                    else
                    {
                        return SubmitTx(data, sign);
                    }
                }
                catch (Exception ex)
                {
                    return new BaseRsp<string>()
                    {
                        success = false,
                        error = 1002,
                        msg = ex.Message
                    };
                }
            }

            return new BaseRsp<string>()
            {
                success = false,
                error = 1001,
            };
        }

        /// <summary>
        /// 注册应用交易签名
        /// </summary>
        /// <param name="data">交易参数</param>
        /// <returns>签名结果</returns>
        [HttpPost("RegisterApp")]
        public BaseRsp<string> RegisterAppTx(RegisterAppTxReq data)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    CheckAddress(data.FromRegId, data.NetType, 2);
                }
                catch (Exception ex)
                {
                    return new BaseRsp<string>()
                    {
                        success = false,
                        error = 1001,
                        msg = ex.Message

                    };
                }

                Wallet wt = new Wallet()
                {
                    Network = data.NetType == 1 ? _mainnet : _testnet,
                    Prikey = data.PrivateKey,
                    UserId = new UserId(uint.Parse(data.FromRegId.Split('-')[0]), uint.Parse(data.FromRegId.Split('-')[1]))
                };

                try
                {
                    var sign = wt.GetRegisteAppRaw(string.Empty, data.Contract, data.Fees, data.ValidHeight == 0 ? GetCurBlockHeight(data) : data.ValidHeight);

                    if (!data.Submit)
                    {
                        return new BaseRsp<string>()
                        {
                            success = true,
                            data = sign
                        };
                    }
                    else
                    {
                        return SubmitTx(data, sign);
                    }
                }
                catch (Exception ex)
                {
                    return new BaseRsp<string>()
                    {
                        success = false,
                        error = 1002,
                        msg = ex.Message
                    };
                }
            }

            return new BaseRsp<string>()
            {
                success = false,
                error = 1001,
            };
        }

        /// <summary>
        /// 调用应用交易签名
        /// </summary>
        /// <param name="data">交易参数</param>
        /// <returns>签名结果</returns>
        [HttpPost("Contract")]
        public BaseRsp<string> ContractTx(ContractTxReq data)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    CheckAddress(data.FromRegId, data.NetType, 2);
                    CheckAddress(data.ToScriptId, data.NetType, 2);
                }
                catch (Exception ex)
                {
                    return new BaseRsp<string>()
                    {
                        success = false,
                        error = 1001,
                        msg = ex.Message

                    };
                }

                Wallet wt = new Wallet()
                {
                    Network = data.NetType == 1 ? _mainnet : _testnet,
                    Prikey = data.PrivateKey,
                    UserId = new UserId(uint.Parse(data.FromRegId.Split('-')[0]), uint.Parse(data.FromRegId.Split('-')[1]))
                };

                try
                {
                    var sign = wt.CreateContractTxRaw(data.ToScriptId, data.Contract, data.Fees, data.ValidHeight == 0 ? GetCurBlockHeight(data) : data.ValidHeight);

                    if (!data.Submit)
                    {
                        return new BaseRsp<string>()
                        {
                            success = true,
                            data = sign
                        };
                    }
                    else
                    {
                        return SubmitTx(data, sign);
                    }
                }
                catch (Exception ex)
                {
                    return new BaseRsp<string>()
                    {
                        success = false,
                        error = 1002,
                        msg = ex.Message
                    };
                }
            }

            return new BaseRsp<string>()
            {
                success = false,
                error = 1001,
            };
        }

        private static void CheckAddress(string address, int netType, int checkType)
        {
            if ((checkType == 1) && (!address.StartsWith("W") || netType != 1 || address.Length != 34))
            {
                throw new Exception("地址与网络类型不匹配");
            }
            else if ((checkType == 1) && (!address.StartsWith("w") || netType != 2 || address.Length != 34))
            {
                throw new Exception("地址与网络类型不匹配");
            }
            else if ((checkType == 2) && !Regex.IsMatch(address, "^[0-9]{1,8}-[0-9]{1,2}$"))
            {
                throw new Exception("不正确的RegId");
            }
            else if ((checkType == 0) && !(Regex.IsMatch(address, "^[0-9]{1,8}-[0-9]{1,2}$") || (address.StartsWith("W") && netType == 1 && address.Length == 34) || (address.StartsWith("w") && netType == 2 && address.Length == 34)))
            {
                throw new Exception("不正确的地址");
            }
        }

        private static BaseRsp<string> SubmitTx(BaseTxReq data, string raw)
        {
            if (data.Node == null || string.IsNullOrEmpty(data.Node.Url))
            {
                return new BaseRsp<string>()
                {
                    data = string.Empty,
                    success = false,
                    error = 1004,
                    msg = "没有提供远程节点"
                };
            }

            try
            {
                var info = JsonRpc.RpcClient.SubmitTx(data.Node.Url, data.Node.AuthInfo, raw);

                return new BaseRsp<string>()
                {
                    data = info.result?.hash,
                    success = info.error == null,
                    error = info.error?.code ?? 0,
                    msg = info.error?.message ?? null,
                };
            }
            catch (Exception e)
            {
                return new BaseRsp<string>()
                {
                    data = string.Empty,
                    success = false,
                    error = 1003,
                    msg = e.Message
                };
            }
        }

        private static uint GetCurBlockHeight(BaseTxReq data)
        {
            if (data.Node == null || string.IsNullOrEmpty(data.Node.Url))
            {
                throw new Exception("没有提供远程节点");
            }

            try
            {
                var info = JsonRpc.RpcClient.GetBlockCount(data.Node.Url, data.Node.AuthInfo);
                return (uint)info.result;
            }
            catch
            {
                throw new Exception("无法从远程节点获取当前高度信息");
            }
        }
    }
}