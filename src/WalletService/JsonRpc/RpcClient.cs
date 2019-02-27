using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;

namespace WalletServiceApi.JsonRpc
{
    public class RpcClient
    {
        /// <summary>
        /// 发起POST异步请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="postData"></param>
        /// <param name="authInfo"></param>
        /// <returns></returns>
        public static string CallRpc(string url, string authInfo, BaseRpc postData)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes(authInfo)));
                var json = client.PostAsync(url, new StringContent(JsonConvert.SerializeObject(postData), Encoding.UTF8, "application/json")).Result.Content.ReadAsStringAsync().Result;
                return json;
            }
        }

        public static BaseRpcMsg<int> GetBlockCount(string url, string authInfo)
        {
            var json = CallRpc(url, authInfo, new BaseRpc() { method = RpcMethod.GetBlockCount.ToString().ToLower() });
            return JsonConvert.DeserializeObject<BaseRpcMsg<int>>(json);
        }

        public static BaseRpcMsg<HashResault> SubmitTx(string url, string authInfo, string raw)
        {
            var json = CallRpc(url, authInfo, new BaseRpc() { method = RpcMethod.SubmitTx.ToString().ToLower(), _params = new object[] { raw } });
            return !string.IsNullOrEmpty(json) ? JsonConvert.DeserializeObject<BaseRpcMsg<HashResault>>(json) : new BaseRpcMsg<HashResault>() { error = new RpcError() { code = 400, message = "远程节点无响应" } };
        }
    }
}
