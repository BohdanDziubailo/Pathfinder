using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PathFinderApp.Classes;

namespace PathFinderApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            List<Point2D> points = new List<Point2D>();
            points.Add(new Point2D(2, 1));
            points.Add(new Point2D(5, 1));
            points.Add(new Point2D(2, 4));
            points.Add(new Point2D(4, 2));
            points.Add(new Point2D(5, 4));

            double angle = Point2D.Angle(new Point2D(5, 4), new Point2D(5, 1));

            var shell = JarvisAlgorithm.FindShell(points);
        }
    }
}
