using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathFinderApp.Classes
{
    public static class JarvisAlgorithm
    {
        private static int GetFirstPoint(List<Point2D> points)
        {
            int minY = Int32.MaxValue;
            foreach (var point in points)
                if (point.Y < minY)
                    minY = point.Y;

            int maxX = Int32.MinValue;
            int point0Id = 0;
            foreach (var point in points)
                if (point.Y == minY)
                {
                    if (point.X > maxX)
                        point0Id = point.Id;
                }
            return point0Id;
        }

        public static List<Point2D> FindShell(List<Point2D> points)
        {
            Point2D point0 = points.FirstOrDefault(x => x.Id == GetFirstPoint(points));

            List<Point2D> undefinedPoints = points;

            List<Point2D> shellPoints = new List<Point2D>();
            shellPoints.Add(point0);
            Point2D lastPoint = point0;
            do
            {
                double minAngle = Double.MaxValue;
                Point2D next = new Point2D();
                for(int i = 0; i < undefinedPoints.Count; i++)
                {
                    double angle = Point2D.Angle(lastPoint, undefinedPoints[i]);
                    if (angle < minAngle)
                    {
                        next = undefinedPoints[i];
                        minAngle = angle;
                    }
                }
                if (next.Id != point0.Id)
                {
                    shellPoints.Add(next);
                    undefinedPoints.Remove(next);
                    lastPoint = next;
                }
                else
                    break;

            } while (lastPoint.Id != point0.Id);

            return shellPoints;
        }
    }
}
