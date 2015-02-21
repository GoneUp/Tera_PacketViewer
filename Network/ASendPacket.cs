using System;
using System.IO;
using System.Text;
using Data.Enums.Gather;
using Data.Interfaces;
using Data.Structures;
using Data.Structures.Creature;
using Data.Structures.Player;
using Utils;

namespace Network
{
    public abstract class ASendPacket : ISendPacket
    {
        protected byte[] Data;
        protected object WriteLock = new object();

        public void Send(Player player)
        {
            Send(player.Connection);
        }

        public void Send(params Player[] players)
        {
            for (int i = 0; i < players.Length; i++)
                Send(players[i].Connection);
        }

        public void Send(params IConnection[] states)
        {
            for (int i = 0; i < states.Length; i++)
                Send(states[i]);
        }

        public void Send(IConnection state)
        {
            if (state == null || !state.IsValid)
                return;

            if (!OpCodes.Send.ContainsKey(GetType()))
            {
                Log.Warn("UNKNOWN packet opcode: {0}", GetType().Name);
                return;
            }


            lock (WriteLock)
            {
                if (Data == null)
                {
                    try
                    {
                        using (MemoryStream stream = new MemoryStream())
                        {
                            using (BinaryWriter writer = new BinaryWriter(stream, new UTF8Encoding()))
                            {
                                WriteH(writer, 0); //Reserved for length
                                WriteH(writer, OpCodes.Send[GetType()]);
                                Write(writer);
                            }

                            Data = stream.ToArray();
                            BitConverter.GetBytes((short) Data.Length).CopyTo(Data, 0);
                        }
                    }
                    catch (Exception ex)
                    {
                        Log.Warn("Can't write packet: {0}", GetType().Name);
                        Log.WarnException("ASendPacket", ex);
                        return;
                    }
                }
            }

            state.PushPacket(Data);
        }

        public abstract void Write(BinaryWriter writer);

        protected void WriteD(BinaryWriter writer, int val)
        {
            writer.Write(val);
        }

        protected void WriteH(BinaryWriter writer, short val)
        {
            writer.Write(val);
        }

        protected void WriteC(BinaryWriter writer, byte val)
        {
            writer.Write(val);
        }

        protected void WriteDf(BinaryWriter writer, double val)
        {
            writer.Write(val);
        }

        protected void WriteF(BinaryWriter writer, float val)
        {
            writer.Write(val);
        }

        protected void WriteQ(BinaryWriter writer, long val)
        {
            writer.Write(val);
        }

        protected void WriteS(BinaryWriter writer, String text)
        {
            if (text == null)
            {
                writer.Write((short) 0);
            }
            else
            {
                Encoding encoding = Encoding.Unicode;
                writer.Write(encoding.GetBytes(text));
                writer.Write((short) 0);
            }
        }

        protected void WriteB(BinaryWriter writer, string hex)
        {
            writer.Write(hex.ToBytes());
        }

        protected void WriteB(BinaryWriter writer, byte[] data)
        {
            writer.Write(data);
        }

        protected void WriteUid(BinaryWriter writer, Uid uid)
        {
            if (uid == null)
            {
                writer.Write(0L);
                return;
            }

            writer.Write(uid.UID);
            writer.Write(UidFactory.GetFamily(uid).GetHashCode());
        }

        protected void WriteStats(BinaryWriter writer, Player player)
        {
            CreatureBaseStats baseStats = player.GameStats; // Communication.Global.StatsService.InitStats(Player)

            #region Base stats
            WriteD(writer, baseStats.Power - player.EffectsImpact.ChangeOfPower);
            WriteD(writer, baseStats.Endurance - player.EffectsImpact.ChangeOfEndurance);
            WriteH(writer, (short) (baseStats.ImpactFactor - player.EffectsImpact.ChangeOfImpactFactor));
            WriteH(writer, (short) (baseStats.BalanceFactor - player.EffectsImpact.ChangeOfBalanceFactor));
            WriteH(writer, (short) (baseStats.Movement - player.EffectsImpact.ChangeOfMovement));
            WriteH(writer, (short) (baseStats.AttackSpeed - player.EffectsImpact.ChangeOfAttackSpeed));

            // Crit. stats
            WriteF(writer, baseStats.CritChanse);
            WriteF(writer, baseStats.CritResist);
            WriteH(writer, 0);
            WriteC(writer, 0);
            WriteC(writer, 0x40); // Crit how much times?

            WriteD(writer, baseStats.Attack); //min attack
            WriteD(writer, baseStats.Attack); //max attack
            WriteD(writer, baseStats.Defense);
            WriteH(writer, (short)baseStats.Impact);
            WriteH(writer, (short)baseStats.Balance);

            WriteF(writer, baseStats.WeakeningResist); // Weakening
            WriteF(writer, baseStats.PeriodicResist); // Periodic
            WriteF(writer, baseStats.StunResist); // Stun
            #endregion

            #region Additional stats
            WriteD(writer, player.EffectsImpact.ChangeOfPower);
            WriteD(writer, player.EffectsImpact.ChangeOfEndurance);
            WriteH(writer, player.EffectsImpact.ChangeOfImpactFactor);
            WriteH(writer, player.EffectsImpact.ChangeOfBalanceFactor);

            WriteH(writer, player.EffectsImpact.ChangeOfMovement);
            WriteH(writer, player.EffectsImpact.ChangeOfAttackSpeed);

            WriteF(writer, player.GameStats.CritChanse - baseStats.CritChanse);
            WriteF(writer, player.GameStats.CritResist - baseStats.CritResist);
            WriteD(writer, 0);

            WriteD(writer, player.GameStats.Attack - baseStats.Attack); //min attack
            WriteD(writer, player.GameStats.Attack - baseStats.Attack); //max attack
            WriteD(writer, player.GameStats.Defense - baseStats.Defense);

            WriteH(writer, (short)(player.GameStats.Impact - baseStats.Impact));
            WriteH(writer, (short)(player.GameStats.Balance - baseStats.Balance));

            WriteF(writer, player.GameStats.WeakeningResist - baseStats.WeakeningResist); // Weakening
            WriteF(writer, player.GameStats.PeriodicResist - baseStats.PeriodicResist); // Periodic
            WriteF(writer, player.GameStats.StunResist - baseStats.StunResist); // Stun
            #endregion
        }

        protected void WriteGatherStats(BinaryWriter writer, Player player)
        {
            WriteH(writer, player.PlayerCraftStats.GetGatherStat(TypeName.Energy));
            WriteH(writer, player.PlayerCraftStats.GetGatherStat(TypeName.Herb));
            WriteH(writer, 0); //unk, mb bughunting
            WriteH(writer, player.PlayerCraftStats.GetGatherStat(TypeName.Mine));
        }
    }
}