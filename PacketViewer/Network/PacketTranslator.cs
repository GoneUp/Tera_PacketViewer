using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using PacketViewer.Forms;

namespace PacketViewer.Network
{
    class PacketTranslator
    {
        public static Dictionary<ushort, string> PacketNames = new Dictionary<ushort, string>();

        public static void Init()
        {
            string path = Directory.GetCurrentDirectory() + "\\opcodefile.txt";
            if (File.Exists(path))
            {
                TextReader reader = new StreamReader(path);

                string line = "";
                while ((line = reader.ReadLine()) != null)
                {
                    //I_TELEPORT = 0
                    string[] tmpString = line.Replace(" ", "").Split('=');
                    PacketNames.Add(Convert.ToUInt16(tmpString[1]), tmpString[0]);
                }

            }
            else
            {
                MessageBox.Show("Opcodefile not found!");
            }

        }

        public static ushort GetOpcode(string name)
        {
            ushort opCode =
                (from val in PacketNames
                 where val.Value.Equals(name)
                 select val.Key).FirstOrDefault();
            return opCode;
        }

        public static string GetOpcodeName(ushort opCode)
        {
            string name;

            if (PacketNames.ContainsKey(opCode))
            {
                name = PacketNames[opCode];
            }
            else
            {
                string opCodeLittleEndianHex = BitConverter.GetBytes(opCode).ToHex();
                name = string.Format("0x{0}{1}", opCodeLittleEndianHex.Substring(2),
                                     opCodeLittleEndianHex.Substring(0, 2));
            }

            return name;
        }
    }
}
