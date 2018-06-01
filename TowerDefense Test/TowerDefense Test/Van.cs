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
        private Size vanSize;
        private Point vanLocation;
        private Color vanColor;
        private Size vanDirection;
        private Path path;
        private float healthPointNow;
        private float healthPointMax;
        private int pathPart;
        private int angle;
        private bool finish;

        public Van(float healthPointMax, float healthPointStart, Color vanColor, Path path, Size vanSize, Point vanLocationMiddle)
        {
            this.healthPointMax = healthPointMax;
            this.healthPointNow = healthPointStart;
            this.path = path;
            this.vanColor = vanColor;
            this.vanSize = vanSize;
            this.LocationMiddle = vanLocationMiddle;
            this.finish = false;
        }
        public Point LocationMiddle
        {
            get { return new Point(vanLocation.X + vanSize.Width / 2, vanLocation.Y + vanSize.Height / 2); }
            set { finish = false; vanLocation = new Point(value.X - vanSize.Width / 2, value.Y - vanSize.Height / 2); }
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
        public int Direction
        {
            get { return angle; }
        }
        public void Move()
        {
            if (LocationMiddle == path.PathPoints[pathPart] && !finish)
            {
                if(LocationMiddle != path.EndPath && LocationMiddle != path.StartPath)
                {
                    pathPart++;
                    vanDirection = GetDirection();
                }
                else if (LocationMiddle == path.StartPath)
                {
                    pathPart = 1;
                    vanDirection = GetDirection();
                }
                else
                {
                    pathPart = 1;
                    vanDirection = GetDirection();
                    finish = true;
                }
            }
            if(!finish)
            LocationMiddle = Point.Add(LocationMiddle, vanDirection);
        }
        private Size GetDirection()
        {
            Point p1 = path.PathPoints[pathPart - 1];
            Point p2 = path.PathPoints[pathPart];
            Point p = new Point(p2.X - p1.X, p2.Y - p1.Y);
            if (p.X < 0) { angle = 180; return new Size(-1, 0); }
            if (p.X > 0) { angle = 0; return new Size(1, 0); }
            if (p.Y < 0) { angle = 270; return new Size(0, -1); }
            if (p.Y > 0) { angle = 90; return new Size(0, 1); }
            return new Size();
        }
        public void Damage(float damage)
        {
            healthPointNow = -damage;
        }
        public bool Death()
        {
            if (healthPointNow < 0)
                return true;
            return false;
        }
    }
}
