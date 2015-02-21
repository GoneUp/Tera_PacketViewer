using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Network;
using Utils;

namespace PacketViewer
{
    public class Packet
    {
        public static Dictionary<short, string> ServerPacketNames = new Dictionary<short, string>();
        public static Dictionary<short, string> ClientPacketNames = new Dictionary<short, string>();

        public static void Init()
        {
            OpCodes.Init();

            foreach (KeyValuePair<Type, short> keyValuePair in OpCodes.Send)
                ServerPacketNames.Add(keyValuePair.Value, keyValuePair.Key.Name);

            foreach (KeyValuePair<short, Type> keyValuePair in OpCodes.Recv)
                ClientPacketNames.Add(keyValuePair.Key, keyValuePair.Value.Name);
        }

        public bool IsServer { get; set; }
        public short OpCode { get; set; }
        public byte[] Data { get; set; }

        public string Name { get; set; }

        public string Hex { get; set; }
        public string Text { get; set; }

        public Packet(bool isServer, short opCode, byte[] data)
        {
            IsServer = isServer;
            OpCode = opCode;
            Data = data;

            if (isServer && ServerPacketNames.ContainsKey(opCode))
            {
                Name = ServerPacketNames[opCode];
            }
            else if (!isServer && ClientPacketNames.ContainsKey(opCode))
            {
                Name = ClientPacketNames[opCode];
            }
            else
            {
                string opCodeLittleEndianHex = BitConverter.GetBytes(opCode).ToHex();
                Name = string.Format("0x{0}{1}", opCodeLittleEndianHex.Substring(2),
                                     opCodeLittleEndianHex.Substring(0, 2));
            }
            
            Hex = Data.ToHex().Substring(4);

            Text = "0x" + Hex.Substring(2, 2) + Hex.Substring(0, 2) + "\n\n" + Data.FormatHex();
        }

        public static short GetPacketOpcode(MainWindow window, string name, bool isServer = true)
        {
            short opCode =
                (from val in isServer ? ServerPacketNames : ClientPacketNames
                 where val.Value.Equals(name)
                 select val.Key).FirstOrDefault();

            if(opCode == 0)
            {
                while (true)
                {
                    try
                    {
                        InputValueBox inputBox = new InputValueBox(window, "Need to enter opcode", "Enter "+ name +" opcode: ");
                        if (inputBox.Show() == false)
                            return 0;

                        opCode = BitConverter.ToInt16(inputBox.Result.ToBytes(), 0);
                        break;
                    }
                    // ReSharper disable EmptyGeneralCatchClause
                    catch
                    // ReSharper restore EmptyGeneralCatchClause
                    {
                        MessageBox.Show("WRONG PARAMS!", "Error", 0, MessageBoxImage.Warning);
                    }
                }
            }

            return opCode;
        }
    }
}
