using System.Collections.Generic;
using System.IO;
using Data.Structures.World;

namespace Network.Server
{
    public class SpFlightPoints : ASendPacket
    {
        protected List<FlyTeleport> FlyTeleports;

        public SpFlightPoints(List<FlyTeleport> flyTeleports)
        {
            FlyTeleports = flyTeleports;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteH(writer, (short) FlyTeleports.Count);
            WriteH(writer, 8);

            for (int i = 0; i < FlyTeleports.Count; i++)
            {
                WriteH(writer, (short)writer.BaseStream.Length);

                short shift = (short) writer.BaseStream.Length;
                WriteH(writer, 0);

                WriteD(writer, FlyTeleports[i].Id);
                WriteD(writer, FlyTeleports[i].Cost);
                WriteD(writer, FlyTeleports[i].FromNameId);
                WriteD(writer, FlyTeleports[i].ToNameId);
                WriteD(writer, FlyTeleports[i].Level);

                if(FlyTeleports.Count >= i+1)
                {
                    writer.Seek(shift, SeekOrigin.Begin);
                    WriteH(writer, (short) writer.BaseStream.Length);
                    writer.Seek(0, SeekOrigin.End);
                }
            }
        }
    }
}