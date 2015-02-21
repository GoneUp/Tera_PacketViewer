using Data.Enums;

namespace Data.Structures.Player
{
    [ProtoBuf.ProtoContract]
    public class RaceGenderClass
    {
        [ProtoBuf.ProtoMember(1)]
        public Gender Gender;

        [ProtoBuf.ProtoMember(2)]
        public Race Race;

        [ProtoBuf.ProtoMember(3)]
        public PlayerClass Class;

        private int _hash;

        public int Hash
        {
            get
            {
                if (_hash == 0)
                    _hash = 10101
                            + 200*Race.GetHashCode()
                            + 100*Gender.GetHashCode() +
                            Class.GetHashCode();

                return _hash;
            }
        }
    }
}
