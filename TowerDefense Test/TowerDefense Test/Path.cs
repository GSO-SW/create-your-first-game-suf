using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TowerDefense_Test
{
    public class Path //Wegklasse
    {
        private Point[] pathPoints;//Punktearray
        public Path(Point[] pathPoints)
        {
            this.pathPoints = pathPoints;
        }
        public Point[] PathPoints
        {
            get { return pathPoints; }
        }
        public Point StartPath
        {
            get { return pathPoints[0]; }
        }
        public Point EndPath
        {
            get { return pathPoints[pathPoints.Length - 1]; }
        }
    }
}
