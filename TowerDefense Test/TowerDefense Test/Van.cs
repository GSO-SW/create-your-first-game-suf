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
        private Size vanSize, vanSizeTurned, vanDirection;
        private Rectangle vanBody;
        private Path path;
        private float healthPointNow, healthPointMax;
        private int pathPart, angle;
        private bool finish;
        public Van(Size size, Path path, Point startPoint, float healthPoint)
        {
            this.vanSize = size;
            this.vanSizeTurned = new Size(size.Height, size.Width);
            this.vanBody.Size = vanSize;
            this.path = path;
            this.LocationMiddle = startPoint;
            this.healthPointMax = healthPoint;
            this.healthPointNow = healthPoint;
            this.finish = false;
        }
        public Rectangle Body
        {
            get { return vanBody; }
        }
        public Point LocationMiddle
        {
            get { return Point.Add(vanBody.Location, SizeHalf); }
            set { vanBody.Location = Point.Subtract(value, SizeHalf); }
        }
        public int Stage
        {
            get
            {
                if (healthPointNow < 0)
                    return -1; //Tod
                if (finish)
                    return 0; //Ende
                return 1; //Driving
            }
        }
        private Size SizeHalf
        {
            get { return new Size(vanBody.Width / 2, vanBody.Height / 2); }
        }
        public void Move()
        {
            if (LocationMiddle == path.PathPoints[pathPart] && !finish)
            {
                if (LocationMiddle != path.EndPath && LocationMiddle != path.StartPath)
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
            if (!finish)
            {
                LocationMiddle = Point.Add(LocationMiddle, vanDirection);
            }
        }
        private Size GetDirection()
        {
            Point p1 = path.PathPoints[pathPart - 1];
            Point p2 = path.PathPoints[pathPart];
            Point p = new Point(p2.X - p1.X, p2.Y - p1.Y);
            if (p.X > 0) { angle = 0; UpdateVan(vanSize); return new Size(1, 0); }
            if (p.Y > 0) { angle = 90; UpdateVan(vanSizeTurned); return new Size(0, 1); }
            if (p.X < 0) { angle = 180; UpdateVan(vanSize); return new Size(-1, 0); }
            else { angle = 270; UpdateVan(vanSizeTurned); return new Size(0, -1); }
        }
        private void UpdateVan(Size vanSize)
        {
            Point p = LocationMiddle;
            vanBody.Size = vanSize;
            LocationMiddle = p;
        }
        public void Damage(float damage)
        {
            healthPointNow = -damage;
        }
    }
}
