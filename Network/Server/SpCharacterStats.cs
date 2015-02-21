using System.IO;
using Data.Structures.Player;

namespace Network.Server
{
    public class SpCharacterStats : ASendPacket
    {
        protected Player Player;

        public SpCharacterStats(Player player)
        {
            Player = player;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteD(writer, Player.LifeStats.Hp); // current hp
            WriteD(writer, Player.LifeStats.Mp); // current mp
            WriteD(writer, 0); //unk
            WriteD(writer, Player.MaxHp);
            WriteD(writer, Player.MaxMp);

            WriteStats(writer, Player);

            WriteC(writer, (byte) Player.GetLevel()); //Level
            WriteC(writer, 0x00);
            WriteC(writer, (byte) Player.PlayerMode.GetHashCode());

            WriteC(writer, 0);
            if(Player.LifeStats.Stamina > 100)
                WriteC(writer, 4); // Adundunt stamina
            else if(Player.LifeStats.Stamina > 20)
                WriteC(writer, 3); // Normal stamina
            else
                WriteC(writer, 2); // Poor stamina
            WriteB(writer, "0001");
            WriteD(writer, (int)(Player.GameStats.HpStamina * (Player.LifeStats.Stamina / 120.0))); //Player.GameStats.MaxHp - Player.GameStats.MaxHp); //TODO: WTF?
            WriteD(writer, (int)(Player.GameStats.MpStamina * (Player.LifeStats.Stamina / 120.0))); //Player.GameStats.MaxMp - Player.GameStats.MaxMp); //TODO: WTF?
            WriteD(writer, Player.LifeStats.Stamina);
            WriteD(writer, 120); //stamina max val
            WriteB(writer, "0000000000000000000000000000000002000000020000000000000000000000401F000005000000");
        }

        //EBF0 8B0500002B010000000000008B0500002B01000032000000230000002800460069006400000048420000964200000040B4000000B40000003200000006000B00000034420000344200003442CFFFFFFFDEFFFFFFD8FFBBFF97FF9DFF000048C27DFF95C2000080BFC6FFFFFFC6FFFFFFECFFFFFFFAFFF5FFFAFE33C2FAFE33C2FAFE33C2140000000400018B0500002B01000078000000780000000000000000000000000000000000000002000000020000000000000000000000401F000005000000
    }
}