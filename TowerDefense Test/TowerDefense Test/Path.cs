using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TowerDefense_Test
{
    class Path
    {
        private Point[] pathPoints;
        public Path(Point[] pathPoints)
        {
            this.pathPoints = pathPoints;
        }
        public Point[] PathPoints {
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
