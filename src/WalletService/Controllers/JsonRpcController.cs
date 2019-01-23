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
                else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    return new BaseRsp<T>()
                    {
                        success = false,
                        error = 400,
                        msg = "用户鉴权失败",
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