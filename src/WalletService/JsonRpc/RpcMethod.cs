namespace WalletServiceApi.JsonRpc
{
    public enum RpcMethod
    {
        SubmitTx,

        //DumpWallet,

        /* Overall control/query calls */

        GetInfo,

        //gencheckpoint,

        //setcheckpoint,

        ValidateAddress,

        GetTxHashByAddress,


        /* P2P networking */

        GetNetworkInfo,

        AddNode,

        //GetAddedNodeInfo,

        GetConnectionCount,

        GetNetTotals,

        GetPeerInfo,

        Ping,

        GetCoinState,


        /* Block chain and UTXO */

        GetBlockchainInfo,

        GetBestBlockHash,

        GetBlockCount,

        GetBlock,

        GetBlockHash,

        GetDifficulty,

        //getrawmempool,

        ListCheckPoint,

        VerifyChain,

        VerifyMessage,

        GetTotalCoin,

        GetTotalAssets,


        /* Mining */

        GetMiningInfo,

        GetNetworkHashPS,

        SubmitBlock,

        SendToAddressRaw,

        RegistAccountTxRaw,

        CreateContracTxRaw,

        RegisterScriptTxRaw,


        /* uses wallet if enabled */

        BackupWallet,

        DumpPrivkey,

        //DumpWallet,

        EncryptWallet,

        GetAccountInfo,

        GetNewAddress,

        GetTxDetail,

        ListUnconfirmedTx,

        GetWalletInfo,

        ImportPrivkey,

        DropPrivkey,

        //ImportWallet,

        ListAddr,

        ListTransactions,

        ListTransactionsV2,

        ListTx,

        ListContractTx,

        GetTransaction,

        RegistAccountTx,

        RegisterAccountTx,

        CreateContractTx,

        CreateDelegateTx,

        CreateDelegateTxRaw,

        RegisterAppTx
    }
}
