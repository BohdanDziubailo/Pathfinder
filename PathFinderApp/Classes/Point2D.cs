using System;

namespace PathFinderApp.Classes
{
    public struct Point2D
    {
        private static int lastId = 0;
        public readonly int Id;
        public readonly int X;
        public readonly int Y;
        public Point2D(int x, int y)
        {
            X = x;
            Y = y;
            Id = lastId++;
        }

        public static double Distance(Point2D a, Point2D b)
        {
            return Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2));
        }

        public static double Angle(Point2D a, Point2D b)
        {
            double length = Distance(a, b);
            double deltaX = (b.X - a.X);
            double cos = deltaX / length;
            double deltaY = (b.Y - a.Y);
            double sin = deltaY / length;
            double offset = 0;

            if (deltaY == 0)
            {
                if (deltaX > 0)
                    return 0;
                else if (deltaX < 0)
                    return Math.PI;
            }
            if (deltaX == 0)
            {
                if (deltaY > 0)
                    return Math.PI * 0.5;
                else if (deltaY < 0)
                    return Math.PI * 1.5;
            }

            if (sin > 0 && cos > 0)
                offset = 0;
            else if (sin > 0 && cos < 0)
                offset = Math.PI * 0.5;
            else if (sin < 0 && cos < 0)
                offset = Math.PI;
            else if (sin < 0 && cos > 0)
                offset = Math.PI * 1.5;

           
            double angle = Math.Atan(Math.Abs(deltaY / deltaX));
            angle += offset;
            return angle;
        }

        public override string ToString()
        {
            return "(" + X + ", " + Y + ")";
        }
    }
}