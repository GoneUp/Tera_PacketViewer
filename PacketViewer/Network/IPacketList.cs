using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Interop;

namespace PacketViewer.Network
{
    public interface IPacketList
    {
        void Clear();
        void Enqueue(byte[] data);
        byte[] GetBytes(int length);
        int GetLength();
        bool PacketAvailable();
        int NextPacketLength();
    }

}
