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
        private Size vanSize, vanSizeTurned;
        private Size vanWindowSize, vanWindowSizeTurned;
        private Color vanColor;
        private Size vanDirection;
        private Path path;
        private Point location;
        private Point[] bodyTriangle, windowTriangle;
        private Rectangle vanBody, vanWheel1, vanWheel2;
        private float healthPointNow;
        private float healthPointMax;
        private int pathPart;
        private int angle;
        private bool finish;

        public Van(float healthPointMax, float healthPointStart, Color vanColor, Path path, Size vanSize, Size vanWindowSize, Point vanLocationMiddle, int wheelWidth)
        {
            this.healthPointMax = healthPointMax;
            this.healthPointNow = healthPointStart;
            this.path = path;
            this.vanColor = vanColor;
            this.vanSize = vanSize;
            this.vanSizeTurned = new Size(vanSize.Height, vanSize.Width);
            this.bodyTriangle = new Point[3];
            this.windowTriangle = new Point[3];
            this.vanWindowSize = vanWindowSize;
            this.vanWindowSizeTurned = new Size(vanWindowSize.Height, vanWindowSize.Width);
            this.vanWheel1 = new Rectangle(new Point(), new Size(wheelWidth, wheelWidth));
            this.vanWheel2 = new Rectangle(new Point(), new Size(wheelWidth, wheelWidth));
            this.vanBody.Size = vanSize;
            this.LocationMiddle = vanLocationMiddle;
            this.finish = false;
        }
        public Point LocationTopLeft
        {
            get { return Point.Subtract(location, SizeLeftTopToMiddle); }
            set
            {
                location = Point.Add(value, SizeLeftTopToMiddle);
                vanBody.Location = value;
            }
        }
        public Point LocationMiddle
        {
            get { return location; }
            set
            {
                vanBody.Location = Point.Subtract(value, SizeLeftTopToMiddle);
                location = value;
            }
        }
        public Rectangle Body
        {
            get { return vanBody; }
        }
        public Point[] BodyTriangle
        {
            get { return bodyTriangle; }
        }
        public Point[] WindowTriangle
        {
            get { return windowTriangle; }
        }
        public Rectangle Wheel1
        {
            get { return vanWheel1; }
            set { vanWheel1 = value; }
        }
        public Rectangle Wheel2
        {
            get { return vanWheel2; }
            set { vanWheel2 = value; }
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
        public Size SizeLeftTopToMiddle
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
                for (int i = 0; i <= bodyTriangle.Length - 1; i++)
                {
                    bodyTriangle[i] = Point.Add(bodyTriangle[i], vanDirection);
                }
                for (int i = 0; i <= bodyTriangle.Length - 1; i++)
                {
                    windowTriangle[i] = Point.Add(windowTriangle[i], vanDirection);
                }
                vanWheel1.Location = Point.Add(vanWheel1.Location, vanDirection);
                vanWheel2.Location = Point.Add(vanWheel2.Location, vanDirection);
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
        private void Turn(int angle)
        {
            this.angle = angle;
            switch (angle)
            {
                case 0:
                    UpdateVan(vanSize);
                    //UpdateWheels(new Point(vanBody.Left + 10, vanBody.Bottom - vanWheel1.Width / 3), new Point(vanBody.Right - 30 - vanWheel2.Width, vanBody.Bottom - vanWheel2.Width / 3));
                    break;
                case 90:
                    UpdateVan(vanSizeTurned);
                    break;
                case 180:
                    UpdateVan(vanSize);
                    break;
                case 270:
                    UpdateVan(vanSizeTurned);
                    break;
            }
        }
        private void UpdateVan(Size vanSize)
        {
            vanBody.Size = vanSize;
            vanBody.Location = LocationTopLeft;
        }
        private void UpdateBodyTriangle(Point bodyLocation, int Width, int Height)
        {
            this.bodyTriangle[0] = bodyLocation;
            this.bodyTriangle[1] = new Point(Width, bodyLocation.Y);
            this.bodyTriangle[2] = new Point(bodyLocation.X, Height);
        }
        private void UpdateWindowTriangle(Point windowLocation, int Width, int Height)
        {
            this.windowTriangle[0] = windowLocation;
            this.windowTriangle[1] = new Point(Width, windowLocation.Y);
            this.windowTriangle[2] = new Point(windowLocation.X, Height);
        }
        private void UpdateWheels(Point vanWheel1Point, Point vanWheel2Point)
        {
            vanWheel1.Location = vanWheel1Point;
            vanWheel2.Location = vanWheel2Point;
        }
        public void Damage(float damage)
        {
            healthPointNow = -damage;
        }
    }
}
