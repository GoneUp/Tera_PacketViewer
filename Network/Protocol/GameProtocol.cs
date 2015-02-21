using System;
using System.Collections.Generic;
using System.IO;
using Crypt;
using Hik.Communication.Scs.Communication.Messages;
using Hik.Communication.Scs.Communication.Protocols;
using Network.Messages;

namespace Network.Protocol
{
    public class GameProtocol : IScsWireProtocol
    {
        protected Session Session;

        protected MemoryStream Stream = new MemoryStream();

        public GameProtocol(Session session)
        {
            Session = session;
        }

        public byte[] GetBytes(IScsMessage message)
        {
            Session.Encrypt(ref ((GameMessage) message).Data);
            return ((GameMessage) message).Data;
        }

        public IEnumerable<IScsMessage> CreateMessages(byte[] receivedBytes)
        {
            Session.Decrypt(ref receivedBytes);
            Stream.Write(receivedBytes, 0, receivedBytes.Length);

            List<IScsMessage> messages = new List<IScsMessage>();

            // ReSharper disable CSharpWarnings::CS0642
            while (ReadMessage(messages)) ;
            // ReSharper restore CSharpWarnings::CS0642

            return messages;
        }

        public void Reset()
        {
        }

        private bool ReadMessage(List<IScsMessage> messages)
        {
            Stream.Position = 0;

            if (Stream.Length < 4)
                return false;

            byte[] headerBytes = new byte[4];
            Stream.Read(headerBytes, 0, 4);

            int length = BitConverter.ToUInt16(headerBytes, 0);

            if (Stream.Length < length)
                return false;

            GameMessage message = new GameMessage
                                      {
                                          OpCode = BitConverter.ToInt16(headerBytes, 2),
                                          Data = new byte[length - 4]
                                      };

            Stream.Read(message.Data, 0, message.Data.Length);

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