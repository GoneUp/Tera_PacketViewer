using System;

namespace Data.Structures.Template
{
    public class GatherSpawnTemplate
    {
        public GatherSpawnTemplate(byte[] datas, int mapId)
        {
            Datas = datas;
            MapId = mapId;
        }

        public byte[] Datas;

        public int MapId;

        public int GetId()
        {
            return BitConverter.ToInt32(Datas, 0);
        }

        public int GetGatherType()
        {
            return BitConverter.ToInt32(Datas, 4);
        }

        public float GetX()
        {
            return BitConverter.ToSingle(Datas, 8);
        }

        public float GetY()
        {
            return BitConverter.ToSingle(Datas, 12);
        }

        public float GetZ()
        {
            return BitConverter.ToSingle(Datas, 16);
        }
    }
}