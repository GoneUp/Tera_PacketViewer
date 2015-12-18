using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PacketViewer.Network;

namespace PacketViewer.Classes
{
    internal class PacketFilter
    {
        public List<ushort> ignoreOpcodes = new List<ushort>();
        public List<ushort> showOnlyOpcodes = new List<ushort>();

        public bool showCS = true;
        public bool showSC = true;
        public bool showAny = true;

        public bool ShowPacket(Packet_old packet)
        {
            if (!showAny) return false;
            if (packet.Dir == Direction.CS && !showCS) return false;
            if (packet.Dir == Direction.SC && !showSC) return false;

            if (showOnlyOpcodes.Count > 0)
            {
                return showOnlyOpcodes.Contains(packet.OpCode);
            }
            else
            {
                return !ignoreOpcodes.Contains(packet.OpCode);
            }
        }
    }
}

