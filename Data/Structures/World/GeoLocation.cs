using System;
using System.Collections.Generic;

namespace Data.Structures.World
{
    [ProtoBuf.ProtoContract]
    public class GeoLocation
    {
        public static readonly float Fix = 1.017f;

        [ProtoBuf.ProtoMember(1)]
        public int StartX;
        [ProtoBuf.ProtoMember(2)]
        public int StartY;

        public int EndX
        {
            get { return StartX + 15616; }
        }

        public int EndY
        {
            get { return StartY + 15616; }
        }

        [ProtoBuf.ProtoMember(3)]
        public float OffsetZ = float.MinValue;

        public List<KeyValuePair<float,int>> OffsetFixes = new List<KeyValuePair<float, int>>();
        public int FixesCount = 0;

        [ProtoBuf.ProtoMember(4)]
        public List<GeoPoint> Points = new List<GeoPoint>();

        public bool CheckIntersect(float x, float y)
        {
            x *= Fix;
            y *= Fix;

            return (x >= StartX && x < EndX && y >= StartY && y < EndY);
        }

        public float GetZ(float x, float y, float defaultZ = float.MinValue)
        {
            x *= Fix;
            y *= Fix;

            if (Points.Count == 3721)
            {
                int xo = ((int) x - StartX)/256;
                int yo = ((int) y - StartY)/256;

                if (xo == 61)
                    xo = 60;

                if (yo == 61)
                    yo = 60;

                int index = xo*61 + yo;

                if (!OffsetZ.Equals(float.MinValue))
                    return Points[index].Z + OffsetZ;

                return Points[index].Z;
            }

            float z = defaultZ;
            double minD = double.MaxValue;

            for (int i = 0; i < Points.Count; i++)
            {
                double zx = Points[i].X - x;
                double zy = Points[i].Y - y;
                double d = Math.Sqrt(zx*zx + zy*zy);

                if (d < minD)
                {
                    z = Points[i].Z;
                    minD = d;
                }
            }

            if (!OffsetZ.Equals(float.MinValue))
                z += OffsetZ;

            return z;
        }
    }
}
