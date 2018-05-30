using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TowerDefense_Test
{
    class Van
    {
        Size vanSize;
        Point vanLocation;
        Color vanColor;
        Path path;
        

        public Van(Color vanColor, Path path, Size vanSize, Point vanLocationMiddle)
        {
            this.path = path;
            this.vanColor = vanColor;
            this.vanSize = vanSize;
            this.LocationMiddle = vanLocationMiddle;
        }
        public Point LocationMiddle
        {
            get { return new Point(vanLocation.X + vanSize.Width / 2, vanLocation.Y + vanSize.Height / 2); }
            set { vanLocation = new Point(value.X - vanSize.Width / 2, value.Y - vanSize.Height / 2); }
        }
        public Rectangle NeckOfTheWoods
        {
            get { return new Rectangle(vanLocation, vanSize); }
        }
        public Color VanColor
        {
            get { return vanColor; }
            set { vanColor = value; }
        }
    }
}
