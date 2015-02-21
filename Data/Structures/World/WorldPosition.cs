using System;
using Data.Structures.Geometry;

namespace Data.Structures.World
{
    [ProtoBuf.ProtoContract]
    public class WorldPosition
    {
        [ProtoBuf.ProtoMember(1)]
        public int MapId;

        [ProtoBuf.ProtoMember(2)]
        public float X;
        [ProtoBuf.ProtoMember(3)]
        public float Y;
        [ProtoBuf.ProtoMember(4)]
        public float Z;

        [ProtoBuf.ProtoMember(5)]
        public short Heading;

        public double DistanceTo(float x, float y)
        {
            double a = x - X;
            double b = y - Y;

            return Math.Sqrt(a * a + b * b);
        }

        public double DistanceTo(float x, float y, float z)
        {
            double a = x - X;
            double b = y - Y;
            double c = z - Z;

            return Math.Sqrt(a * a + b * b + c * c);
        }

        public double DistanceTo(WorldPosition p2)
        {
            if (p2 == null)
                return double.MaxValue;

            double a = p2.X - X;
            double b = p2.Y - Y;
            double c = p2.Z - Z;

            return Math.Sqrt(a*a + b*b + c*c);
        }

        public double FastDistanceTo(WorldPosition p2)
        {
            double a = p2.X - X;
            double b = p2.Y - Y;

            return Math.Sqrt(a*a + b*b);
        }

        public double DistanceTo(Climb climb)
        {
            double a = climb.X1 - X;
            double b = climb.Y1 - Y;
            double c = climb.Z1 - Z;

            return Math.Sqrt(a*a + b*b + c*c);
        }

        public WorldPosition Clone()
        {
            WorldPosition clone = (WorldPosition) MemberwiseClone();
            return clone;
        }

        public short GetHeadingToTarget(WorldPosition worldPosition)
        {
            return Geom.GetHeading(((float) ((worldPosition.X - X)/DistanceTo(worldPosition))*45),
                                   ((float) ((worldPosition.Y - Y)/DistanceTo(worldPosition))*45));
        }

        public Point3D ToPoint3D()
        {
            return new Point3D(X, Y, Z);
        }

        public void CopyTo(WorldPosition position)
        {
            position.X = X;
            position.Y = Y;
            position.Z = Z;
            position.Heading = Heading;
        }

        public void CopyTo(Point3D point)
        {
            point.X = X;
            point.Y = Y;
            point.Z = Z;
        }

        public bool IsNull()
        {
            // ReSharper disable CompareOfFloatsByEqualityOperator
            return X == 0f && Y == 0f && Z == 0f;
            // ReSharper restore CompareOfFloatsByEqualityOperator
        }
    }
}