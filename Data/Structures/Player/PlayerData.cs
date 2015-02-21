using Data.Enums;

namespace Data.Structures.Player
{
    [ProtoBuf.ProtoContract]
    public class PlayerData
    {
        public Gender Gender;

        public Race Race;

        public PlayerClass Class;

        [ProtoBuf.ProtoMember(4)]
        public string Name = "Error!";

        [ProtoBuf.ProtoMember(5)]
        public byte[] Data;

        [ProtoBuf.ProtoMember(6)]
        public byte[] Details;

        private int _sexRaceClass;

        [ProtoBuf.ProtoMember(7)]
        public int SexRaceClass
        {
            get
            {
                if (_sexRaceClass == 0)
                    _sexRaceClass = 10101
                                    + 200*Race.GetHashCode()
                                    + 100*Gender.GetHashCode() +
                                    Class.GetHashCode();

                return _sexRaceClass;
            }

            //For ProtoBuf load
            // ReSharper disable UnusedMember.Local
            private set
            // ReSharper restore UnusedMember.Local
            {
                value -= 10101;

                Race = (Race) (value/200);
                value -= 200 * Race.GetHashCode();

                Gender = (Gender) (value/100);
                value -= 100 * Gender.GetHashCode();

                Class = (PlayerClass) value;
            }
        }
    }
}