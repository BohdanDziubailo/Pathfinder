using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathFinderApp.Classes
{ 
    public class Polygon
    {
        private static int LastId;
        public readonly int Id;
        public readonly List<Point2D> Points;

        public Polygon(List<Point2D> points)
        {
            Points = points;
        }

        public Result IsConvex()
        {
            if (Points.Count < 3)
                return new Result(false, "Not a polygon");
            else
            {
                if (JarvisAlgorithm.FindShell(Points).Count != Points.Count)
                    return new Result(false, "Polygon is not convex");
                else
                    return new Result(true, "All right");
            }
        }

        public override string ToString()
        {
            string res = Id.ToString() + ":[";
            foreach (var point in Points)
                res += point.ToString() + ", ";
            res += "]";
            return res;
        }
    }
}
