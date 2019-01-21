using System;

namespace NBitcoin.Wicc.Core
{
    public class UserId : IBitcoinSerializable
    {
        public UInt32 Height;
        public UInt32 Index;
        public KeyId KeyId;

        public UserId()
        {

        }

        public UserId(UInt32 height, UInt32 index)
        {
            Height = height;
            Index = index;
        }

        public UserId(string address, Network network)
        {
            var scriptAddress = new BitcoinPubKeyAddress(address, network);
            KeyId = scriptAddress.Hash;
        }

        public void ReadWrite(BitcoinStream stream)
        {
            if (stream.Serializing)
            {
                if (KeyId != null)
                {
                    uint fix = 20;

                    stream.ReadWriteAsVarInt(ref fix);
                    stream.ReadWrite(new uint160(KeyId.ToBytes()));
                }
                else
                {
                    uint fix = 4;

                    stream.ReadWriteAsVarInt(ref fix);
                    stream.ReadWriteAsCompactVarInt(ref Height);
                    stream.ReadWriteAsCompactVarInt(ref Index);
                }
            }
            else
            {
                uint fixLenght = 0;
                stream.ReadWriteAsVarInt(ref fixLenght);

                if (fixLenght < 20)
                {
                    stream.ReadWriteAsCompactVarInt(ref Height);
                    stream.ReadWriteAsCompactVarInt(ref Index);
                }
                else
                {
                    var keyHash = uint160.Zero;
                    stream.ReadWrite(ref keyHash);
                    KeyId = new KeyId(keyHash);
                }
            }
        }
    }
}
