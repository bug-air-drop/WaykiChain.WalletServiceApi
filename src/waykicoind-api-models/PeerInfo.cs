namespace WalletServiceApi.JsonRpc
{
    public class PeerInfo
    {
        public string addr { get; set; }
        public string services { get; set; }
        public int lastsend { get; set; }
        public int lastrecv { get; set; }
        public int bytessent { get; set; }
        public int bytesrecv { get; set; }
        public int conntime { get; set; }
        public float pingtime { get; set; }
        public int version { get; set; }
        public string subver { get; set; }
        public bool inbound { get; set; }
        public int startingheight { get; set; }
        public int banscore { get; set; }
        public bool syncnode { get; set; }
    }
}
