using System;
using Data.Structures.World;

namespace Data.Structures.Geometry
{
    [ProtoBuf.ProtoContract]
    public class Point3D
    {
        [ProtoBuf.ProtoMember(1)]
        public float X;

        [ProtoBuf.ProtoMember(2)]
        public float Y;

        [ProtoBuf.ProtoMember(3)]
        public float Z;

        public Point3D(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Point3D(float x, float y)
            : this(x, y, 0)
        {
        }

        public Point3D()
            : this(0, 0, 0)
        {
        }

        public Point3D SetX(float x)
        {
            X = x;

            return this;
        }

        public Point3D SetY(float y)
        {
            Y = y;

            return this;
        }

        public Point3D SetZ(float z)
        {
            Z = z;

            return this;
        }

        public Point3D Add(float n)
        {
            X += n;
            Y += n;
            Z += n;

            return this;
        }

        public Point3D Add(Point3D point3D)
        {
            X += point3D.X;
            Y += point3D.Y;
            Z += point3D.Z;

            return this;
        }

        public Point3D Add(WorldPosition worldPosition)
        {
            X += worldPosition.X;
            Y += worldPosition.Y;
            Z += worldPosition.Z;

            return this;
        }

        public Point3D Multiple(float n)
        {
            X *= n;
            Y *= n;
            Z *= n;

            return this;
        }

        public double GetLength()
        {
            return Math.Sqrt(X*X + Y*Y + Z*Z);
        }

        public double DistanceTo(Point3D point3D)
        {
            double a = point3D.X - X;
            double b = point3D.Y - Y;
            double c = point3D.Z - Z;

            return Math.Sqrt(a*a + b*b + c*c);
        }

        public double DistanceTo(WorldPosition position)
        {
            double a = position.X - X;
            double b = position.Y - Y;
            double c = position.Z - Z;

            return Math.Sqrt(a*a + b*b + c*c);
        }

        public double DistanceTo2D(WorldPosition position)
        {
            double a = position.X - X;
            double b = position.Y - Y;

            return Math.Sqrt(a * a + b * b);
        }

        public Point3D GetNormal()
        {
            float len = (float) GetLength();
            return len.Equals(0)
                       ? new Point3D()
                       : new Point3D(X/len, Y/len, Z/len);
        }

        public WorldPosition ToWorldPosition()
        {
            return new WorldPosition {X = X, Y = Y, Z = Z, Heading = Geom.GetHeading(this)};
        }

        public void CopyTo(WorldPosition worldPosition)
        {
            worldPosition.X = X;
            worldPosition.Y = Y;
            worldPosition.Z = Z;
        }

        public void CopyTo(Point3D p)
        {
            p.X = X;
            p.Y = Y;
            p.Z = Z;
        }

        public Point3D Clone()
        {
            return new Point3D(X, Y, Z);
        }

        public Point3D Revert()
        {
            X *= -1;
            Y *= -1;

            return this;
        }

        public bool Equals(Point3D p)
        {
            if (ReferenceEquals(null, p))
                return false;

            if (ReferenceEquals(this, p))
                return true;

            return p.X.Equals(X) && p.Y.Equals(Y) && p.Z.Equals(Z);
        }

        public bool Equals(WorldPosition p)
        {
            if (ReferenceEquals(null, p))
                return false;

            return p.X.Equals(X) && p.Y.Equals(Y) && p.Z.Equals(Z);
        }

        public Point3D Rotate(short angle)
        {
            float a = (float) ((angle/180f)*Math.PI);

            double r = Math.Sqrt(X*X + Y*Y);

            X = (float) (r*Math.Cos(a));
            Y = (float) (r*Math.Sin(a));

            return this;
        }

        public Point3D RotateRight90()
        {
            float x = X;

            X = Y;
            Y = -x;

            return this;
        }

        public Point3D RotateLeft90()
        {
            float x = X;

            X = -Y;
            Y = x;

            return this;
        }
    }
}