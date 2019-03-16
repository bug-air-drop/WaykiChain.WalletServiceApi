namespace WalletServiceApi.JsonRpc
{
    public class RegistAccountTxParams
    {
        /// <summary>
        /// 待激活的地址, 该地址必须存在于当前钱包节点中
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 手续费
        /// </summary>
        public long Fee { get; set; }
    }
}
