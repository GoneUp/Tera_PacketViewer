using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PacketViewer.Forms;
using PacketViewer.Network;

namespace PacketViewer.Classes
{
    class WireshackReader : IPacketInput
    {
        private FileStream fs;
        private TextReader reader;
        private PacketProcessor processor;

        public WireshackReader(string file)
        {
            if (!File.Exists(file)) throw new Exception("File not found!");

            fs = new FileStream(file, FileMode.Open);
            reader = new StreamReader(fs);
        }

        public void SetProcessor(PacketProcessor pp)
        {
            processor = pp;
        }

        public void Process()
        {

            while (true)
            {
                string line = reader.ReadLine();
                if (line == null)
                    break;
                if (line.Length == 0)
                    continue;

                bool isServer = line[0] == ' ';

                string hex = line.Substring(isServer ? 14 : 10, 49).Replace(" ", "");
                byte[] data = hex.ToBytes();

                if (isServer)
                {
                    processor.AppendServerData(data);
                }
                else
                {
                    processor.AppendClientData(data);
                }

                if (!processor.Initialized) processor.TryInit();
                processor.ProcessAllClientData();
                processor.ProcessAllServerData();
            }

            reader.Close();
        }

    }
}
