namespace PacketViewer.Network.Lists
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
