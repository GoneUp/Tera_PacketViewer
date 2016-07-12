using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacketViewer.Classes
{
    public class Configuration
    {
        private readonly List<ServerInfo> servers;

        public Configuration(List<ServerInfo> servers)
        {
            this.servers = servers;
        }

        public List<ServerInfo> getServers()
        {
            return servers;
        }
    }
}
