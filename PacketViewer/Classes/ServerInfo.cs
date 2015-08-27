using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacketViewer.Classes
{
    public class ServerInfo
    {
        public string Title;
        public string Ip;
        public bool Focus;

        public ServerInfo() { }

        public ServerInfo(string name, string ip, bool focus)
        {
            Title = name;
            Ip = ip;
            Focus = focus;
        }

        public string GetDisplayString()
        {
            //Format: 79.110.94.217;EU Akasha
            return String.Format("{0};{1}", Ip, Title);
        }
    }
}
