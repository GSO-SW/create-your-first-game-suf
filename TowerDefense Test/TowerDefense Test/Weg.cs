using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TowerDefense_Test
{
    class Weg
    {
        private Point[] wegPunkte;
        public Weg(Point[] wegPunkte)
        {
            this.wegPunkte = wegPunkte;
        }
        public Point[] WegPunkte {
            get { return wegPunkte; }
        }
        public Point StartPunkt
        {
            get { return WegPunkte[0]; }
        }
        public Point EndPunkt
        {
            get { return wegPunkte[wegPunkte.Length - 1]; }
        }
    }
}
