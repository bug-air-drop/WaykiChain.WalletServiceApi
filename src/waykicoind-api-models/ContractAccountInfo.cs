using System;
using System.Collections.Generic;
using System.Text;

namespace WalletServiceApi.JsonRpc
{
    public class ContractAccountInfo
    {
        public string mAccUserID { get; set; }
        public long FreeValues { get; set; }
        public object[] FrozenFunds { get; set; }
    }
}
