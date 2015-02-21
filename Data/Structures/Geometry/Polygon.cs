using System.Collections.Generic;

namespace Data.Structures.Geometry
{
    [ProtoBuf.ProtoContract]
    public class Polygon
    {
        [ProtoBuf.ProtoMember(1)]
        public List<Point3D> PointList;

        public bool Contains(Point3D point)
        {
            if (PointList.Count <= 2)
                return false;

            bool res = false;

            Point3D lastPoint = PointList[PointList.Count - 1];

            foreach (Point3D curPoint in PointList)
            {
                if ((((curPoint.Y <= point.Y) && (point.Y < lastPoint.Y)) ||
                     ((lastPoint.Y <= point.Y) && (point.Y < curPoint.Y))) &&
                    (point.X > (lastPoint.X - curPoint.X)*(point.Y - curPoint.Y)/(lastPoint.Y - curPoint.Y) + curPoint.X))
                    res = !res;

                lastPoint = curPoint;
            }
            return res;
        }
    }
}
