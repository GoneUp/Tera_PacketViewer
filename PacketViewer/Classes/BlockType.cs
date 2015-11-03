namespace PacketViewer.Classes
{
    //wrote by gothos @ https://github.com/gothos-folly/TeraDamageMeter
    enum BlockType : byte
    {
        MagicBytes = 1,
        Start = 2,
        Timestamp = 3,
        Client = 4,
        Server = 5,
        Region = 6
    }
}
