using System.Collections.Generic;
using System.IO;
using Hik.Communication.Scs.Communication.Messages;
using Hik.Communication.Scs.Communication.Protocols;
using Network.Messages;

namespace Network.Protocol
{
    public class KeyProtocol : IScsWireProtocol
    {
        protected MemoryStream Stream = new MemoryStream();

        public byte[] GetBytes(IScsMessage message)
        {
            return ((KeyMessage) message).Key;
        }

        public IEnumerable<IScsMessage> CreateMessages(byte[] receivedBytes)
        {
            Stream.Write(receivedBytes, 0, receivedBytes.Length);

            List<IScsMessage> messages = new List<IScsMessage>();

            // ReSharper disable CSharpWarnings::CS0642
            while (ReadKeyMessage(messages)) ;
            // ReSharper restore CSharpWarnings::CS0642

            return messages;
        }

        public void Reset()
        {
        }

        private bool ReadKeyMessage(List<IScsMessage> messages)
        {
            Stream.Position = 0;

            if (Stream.Length < 128)
                return false;

            KeyMessage message = new KeyMessage {Key = new byte[128]};

            Stream.Read(message.Key, 0, 128);

            messages.Add(message);

            TrimStream();

            return true;
        }

        private void TrimStream()
        {
            if (Stream.Position == Stream.Length)
            {
                Stream = new MemoryStream();
                return;
            }

            byte[] remaining = new byte[Stream.Length - Stream.Position];
            Stream.Read(remaining, 0, remaining.Length);
            Stream = new MemoryStream();
            Stream.Write(remaining, 0, remaining.Length);
        }
    }
}