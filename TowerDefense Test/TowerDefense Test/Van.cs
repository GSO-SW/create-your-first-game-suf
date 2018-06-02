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
        private Size vanSizeTurned;
        private Size vanWindowSize;
        private Size vanWindowSizeTurned;
        private Color vanColor;
        private Size vanDirection;
        private Path path;
        private Point location;
        private Rectangle vanBody, vanWindow;
        private float healthPointNow;
        private float healthPointMax;
        private int pathPart;
        private int angle;
        private bool finish;

        public Van(float healthPointMax, float healthPointStart, Color vanColor, Path path, Size vanSize, int windowWidth, Point vanLocationMiddle)
        {
            this.healthPointMax = healthPointMax;
            this.healthPointNow = healthPointStart;
            this.path = path;
            this.vanColor = vanColor;
            this.vanSize = vanSize;
            this.vanSizeTurned = new Size(vanSize.Height, vanSize.Width);
            this.vanWindowSize = Size.Subtract(this.vanSize, new Size(windowWidth, 0));
            this.vanWindowSizeTurned = Size.Subtract(this.vanSizeTurned, new Size(0, windowWidth));
            this.vanBody.Size = vanSize;
            this.LocationMiddle = vanLocationMiddle;
            this.finish = false;
        }
        public Point LocationTopLeft
        {
            get { return new Point(location.X - vanBody.Size.Width / 2, location.Y - vanBody.Size.Height); }
        }
        public Point LocationMiddle
        {
            get { return location; }
            set
            {
                vanBody.Location = new Point(value.X - vanBody.Width / 2, value.Y - vanBody.Height / 2);
                location = value;
            }
        }
        public Rectangle Body
        {
            get { return vanBody; }
        }
        public Rectangle Window
        {
            get { return vanWindow; }
        }
        public PointF Text
        {
            get { return new PointF(); }
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
                vanWindow.Location = Point.Add(vanWindow.Location, vanDirection);
            }

        }
        private Size GetDirection()
        {
            Point p1 = path.PathPoints[pathPart - 1];
            Point p2 = path.PathPoints[pathPart];
            Point p = new Point(p2.X - p1.X, p2.Y - p1.Y);
            if (p.X < 0) { Turn(180); return new Size(-1, 0); }
            if (p.X > 0) { Turn(0); return new Size(1, 0); }
            if (p.Y < 0) { Turn(270); return new Size(0, -1); }
            if (p.Y > 0) { Turn(90); return new Size(0, 1); }
            return new Size();
        }
        public void Turn(int angle)
        {
            this.angle = angle;
            switch (angle)
            {
                case 0:
                    UpdateVan(vanSize);
                    UpdateWindow(vanWindowSize, LocationTopLeft);
                    break;
                case 90:
                    UpdateVan(vanSizeTurned);
                    UpdateWindow(vanWindowSizeTurned, LocationTopLeft);
                    break;
                case 180:
                    UpdateVan(vanSize);
                    UpdateWindow(vanWindowSize, new Point(LocationTopLeft.X + vanSize.Width - vanWindowSize.Width, 0));
                    break;
                case 270:
                    UpdateVan(vanSizeTurned);
                    UpdateWindow(vanWindowSizeTurned, new Point(0, LocationTopLeft.Y + vanSize.Height - vanWindowSize.Height));
                    break;
            }
        }
        public void UpdateVan(Size vanSize)
        {
            vanBody.Size = vanSize;
            vanBody.Location = LocationTopLeft;
        }
        public void UpdateWindow(Size vanWindowSize, Point vanWindowPoint)
        {
            vanWindow.Size = vanWindowSize;
            vanWindow.Location = vanWindowPoint;
        }
        public void Damage(float damage)
        {
            healthPointNow = -damage;
        }
    }
}
