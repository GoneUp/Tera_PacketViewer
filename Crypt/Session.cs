using System;

namespace Crypt
{
    public class Session
    {
        protected Cryptor Encryptor = new Cryptor();
        protected Cryptor Decryptor = new Cryptor();

        public byte[] EncryptKey = new byte[128];
        public byte[] DecryptKey = new byte[128];

        public byte[] ClientKey1 = new byte[128];
        public byte[] ClientKey2 = new byte[128];
        public byte[] ServerKey1 = Utils.Random128Key();
        public byte[] ServerKey2 = Utils.Random128Key();

        public byte[] TmpKey1 = new byte[128];
        public byte[] TmpKey2 = new byte[128];

        public void Init()
        {
            TmpKey1 = Utils.ShiftKey(ServerKey1, 31);
            TmpKey2 = Utils.XorKey(TmpKey1, ClientKey1);

            TmpKey1 = Utils.ShiftKey(ClientKey2, 17, false);
            DecryptKey = Utils.XorKey(TmpKey1, TmpKey2);

            Decryptor.GenerateKey(DecryptKey);

            TmpKey1 = Utils.ShiftKey(ServerKey2, 79);
            Decryptor.ApplyCryptor(ref TmpKey1, 128);
            EncryptKey = new byte[128];
            Buffer.BlockCopy(TmpKey1, 0, EncryptKey, 0, 128);

            Encryptor.GenerateKey(EncryptKey);
        }

        public void Encrypt(ref byte[] data)
        {
            Encryptor.ApplyCryptor(ref data, data.Length);
        }

        public void Decrypt(ref byte[] data)
        {
            Decryptor.ApplyCryptor(ref data, data.Length);
        }

        public void Decrypt(ref byte[] data, int length)
        {
            Decryptor.ApplyCryptor(ref data, length);
        }
    }
}