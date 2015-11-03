using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PacketViewer.Network;

namespace PacketViewer.Classes
{
    interface IPacketInput
    {
        void SetProcessor(PacketProcessor pp);
        void Process();
    }
}
