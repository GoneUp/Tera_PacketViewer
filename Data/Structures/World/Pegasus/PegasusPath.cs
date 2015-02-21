namespace Data.Structures.World.Pegasus
{
    [ProtoBuf.ProtoContract]
    public class PegasusPath
    {
        [ProtoBuf.ProtoMember(1)]
        public int Index;

        [ProtoBuf.ProtoMember(10)]
        public PPStage Stage;
    }
}
