using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tera.Game;

namespace PacketViewer.Classes
{
    public class ServerInfo : Server
    {
        public bool Focus;

        public ServerInfo(string name, string ip, bool focus) : base(name, "", ip)
        {
            Focus = focus;
        }

        public override string ToString()
        {
            //Format: 79.110.94.217;EU Akasha
            return String.Format("{0};{1}", Ip, Name);
        }
    }
}
