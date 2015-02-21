using System;
using Data.Structures.World;
using Utils;

namespace Data.Structures.Geometry
{
    public abstract class Geom
    {
        public static short GetHeading(float x, float y)
        {
            return (short) (Math.Atan2(y, x)*32768/Math.PI);
        }

        public static short GetHeading(WorldPosition worldPosition)
        {
            return (short) (Math.Atan2(worldPosition.Y, worldPosition.X)*32768/Math.PI);
        }

        public static short GetHeading(Point3D point3D)
        {
            return (short) (Math.Atan2(point3D.Y, point3D.X)*32768/Math.PI);
        }

        public static short GetHeading(WorldPosition fromWorldPosition, WorldPosition toWorldPosition)
        {
            return
                (short)
                (Math.Atan2(toWorldPosition.Y - fromWorldPosition.Y, toWorldPosition.X - fromWorldPosition.X)*32768/
                 Math.PI);
        }

        public static short GetHeading(WorldPosition fromWorldPosition, Point3D toPoint3D)
        {
            return
                (short)
                (Math.Atan2(toPoint3D.Y - fromWorldPosition.Y, toPoint3D.X - fromWorldPosition.X) * 32768 /
                 Math.PI);
        }

        public static short GetHeading(Point3D fromPoint3D, Point3D toPoint3D)
        {
            return (short) (Math.Atan2(toPoint3D.Y - fromPoint3D.Y, toPoint3D.X - fromPoint3D.X)*32768/Math.PI);
        }

        public static short GetHeading(Point3D fromPoint3D, WorldPosition toWorldPosition)
        {
            return (short)(Math.Atan2(toWorldPosition.Y - fromPoint3D.Y, toWorldPosition.X - fromPoint3D.X) * 32768 / Math.PI);
        }

        public static Point3D GetNormal(short heading)
        {
            double angle = heading*Math.PI/32768;
            return new Point3D((float) Math.Cos(angle), (float) Math.Sin(angle));
        }

        public static double DistanceToLine(WorldPosition point, WorldPosition p0, WorldPosition p1)
        {
            double dx = p1.X - p0.X;
            double dy = p1.Y - p0.Y;

            return
                Math.Abs(((p0.Y - p1.Y)*point.X + (p1.X - p0.X)*point.Y + (p0.X*p1.Y - p1.X*p0.Y))/
                         (Math.Sqrt(dx*dx + dy*dy)));
        }

        /// <summary>
        /// Return angle different from 0 to 180
        /// </summary>
        /// <param name="heading1">First heading (client)</param>
        /// <param name="heading2">Second heading (client)</param>
        /// <returns></returns>
        public static short GetAngleDiff(short heading1, short heading2)
        {
            return (short) ((180*Math.Abs(heading1 - heading2)/short.MaxValue)%360);
        }

        public static double DistanceToLine(WorldPosition point, WorldPosition p0, WorldPosition p1, double lineHeight)
        {
            return Math.Abs(((p0.Y - p1.Y)*point.X + (p1.X - p0.X)*point.Y + (p0.X*p1.Y - p1.X*p0.Y))/lineHeight);
        }

        public static double GetAngle(WorldPosition center, WorldPosition point1, WorldPosition point2)
        {
            double x1 = point1.X - center.X;
            double x2 = point2.X - center.X;

            double y1 = point1.Y - center.Y;
            double y2 = point2.Y - center.Y;

            return Math.Acos((x1*x2 + y1*y2)/Math.Sqrt((x1*x1 + y1*y1)*(x2*x2 + y2*y2)));
        }

        public static WorldPosition RandomCirclePosition(WorldPosition position, int distance)
        {
            short heading = (short) Funcs.Random().Next(short.MinValue, short.MaxValue);

            return GetNormal(heading).Multiple(distance).Add(position).ToWorldPosition();
        }

        public static WorldPosition ForwardPosition(WorldPosition position, int distance)
        {
            var result = position.Clone();

            double angle = position.Heading * Math.PI / 32768;
            result.X += (float) Math.Cos(angle)*distance;
            result.Y += (float) Math.Sin(angle)*distance;

            return result;
        }
    }
}