namespace WalletServiceApi.JsonRpc
{
    public enum RpcMethod
    {
        /* Overall control/query calls */

        GetInfo,

        //Help,

        //Stop,

        GenCheckPoint,

        SetCheckPoint,

        ValidateAddress,

        GetTxHashByAddress,


        /* P2P networking */

        GetNetworkInfo,

        AddNode,

        GetAddedNodeInfo,

        GetConnectionCount,

        GetNetTotals,

        GetPeerInfo,

        Ping,

        GetChainState,



        /* Block chain and UTXO */

        GetBlockchainInfo,

        GetBestBlockHash,

        GetBlockCount,

        GetBlock,

        GetBlockHash,

        GetDifficulty,

        GetRawMemPool,

        ListCheckPoint,

        VerifyChain,

        VerifyMessage,

        GetTotalCoin,

        GetTotalAssets,


        /* Mining */

        GetMiningInfo,

        GetNetworkHashPS,

        SubmitBlock,




        /* Raw transactions */

        SendToAddressRaw,

        RegistAccountTxRaw,

        CreateContracTxRaw,

        RegisterScriptTxRaw,





        /* uses wallet if enabled */

        BackupWallet,

        DumpPrivkey,

        DumpWallet,

        EncryptWallet,

        GetAccountInfo,

        GetNewAddress,

        GetTxDetail,

        ListUnconfirmedTx,

        GetWalletInfo,

        ImportPrivkey,

        DropPrivkey,

        ImportWallet,

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

        RegisterAppTx,

        SetTxFee,

        WalletLock,

        WalletPassphraseChange,

        WalletPassphrase,

        SetGenerate,

        ListApp,

        GetAppInfo,

        GenerateBlock,

        ListTxCache,

        GetAppData,

        GetAppDataRaw,

        GetAppConfirmData,

        SignMessage,

        SendToAddress,

        SendToAddressWithFee,

        GetBalance,

        //notionalpoolingbalance

        //dispersebalance

        //notionalpoolingasset

        GetAssets,

        ListAsset,

        SubmitTx,

        SigStr,

        GetAppAccountInfo,

        GetAppKeyValue,

        IsLocked,

        GetSignature,

        GetDelegateList,

        DecodeRawTransaction,



        /* beta function */

        GetTxOperationLog,

        DisconnectBlock,

        ResetClient,

        ReloadTxCache,

        ListSetBlockIndexValid,

        GetAppRegId,

        GetScriptDbSize,

        PrintBlokDbInfo,

        GetAllTxInfo,

        SaveBlockToFile,

        GetHash,

        GetRawTx
    }
}
