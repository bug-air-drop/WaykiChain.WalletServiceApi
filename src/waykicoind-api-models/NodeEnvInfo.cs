namespace WalletServiceApi.JsonRpc
{
    public class NodeEnvInfo
    {
        public int version { get; set; }
        public string fullversion { get; set; }
        public int protocolversion { get; set; }
        public int walletversion { get; set; }
        public float balance { get; set; }
        public int blocks { get; set; }
        public int timeoffset { get; set; }
        public int connections { get; set; }
        public string proxy { get; set; }
        public string nettype { get; set; }
        public string chainwork { get; set; }
        public long tipblocktime { get; set; }
        public float paytxfee { get; set; }
        public float relayfee { get; set; }
        public long fuelrate { get; set; }
        public long fuel { get; set; }
        public string datadirectory { get; set; }
        public long syncheight { get; set; }
        public string tipblockhash { get; set; }
        public string errors { get; set; }
    }
}
