namespace WalletServiceApi.JsonRpc
{
    public class BackupWalletParams
    {
        /// <summary>
        /// 备份目录或文件名，如果是文件名，则该文件被覆盖；如果是目录， 那么该目录下将新建或覆盖wallet.data文件
        /// </summary>
        public string Destination { get; set; }
    }
}
