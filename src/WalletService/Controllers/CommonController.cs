using System;
using Microsoft.AspNetCore.Mvc;
using WalletServiceApi.Models;

namespace WalletServiceApi.Controllers
{
    /// <summary>
    /// 其他接口
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class CommonController : ControllerBase
    {
        /// <summary>
        /// 提交已签名交易
        /// </summary>
        /// <param name="data">交易数据</param>
        /// <returns>处理结果</returns>
        [HttpPost("SubmitTx")]
        public BaseRsp<string> SubmitTx(SubmitTxReq data)
        {
            try
            {
                var info = JsonRpc.RpcClient.SubmitTx(data.Node.Url, data.Node.AuthInfo, data.TxRaw);

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

        /// <summary>
        /// 获取指定节点上的区块高度
        /// </summary>
        /// <param name="node">节点信息</param>
        /// <returns></returns>
        [HttpPost("GetBlockCount")]
        public BaseRsp<int> GetBlockCount(NodeInfo node)
        {
            try
            {
                var info = JsonRpc.RpcClient.GetBlockCount(node.Url, node.AuthInfo);

                return new BaseRsp<int>()
                {
                    data = info.result,
                    success = info.error == null,
                    error = info.error?.code ?? 0,
                    msg = info.error?.message ?? null,
                };
            }
            catch (Exception e)
            {
                return new BaseRsp<int>()
                {
                    data = 0,
                    success = false,
                    error = 1003,
                    msg = e.Message
                };
            }

        }
    }
}