using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TowerDefense_Test
{
    public class Van
    {
        private Size vanSize, vanSizeTurned, vanDirection;
        private Rectangle vanBody;
        private float healthPointNow, healthPointMax, childDamage;
        private int targetPathNumber, stepCounter;

        public Van(Size size, Point startPoint, float healthPoint, float childDamage)
        {
            vanSize = size;
            vanSizeTurned = new Size(size.Height, size.Width);
            vanBody.Size = vanSize;
            LocationMiddle = startPoint;
            healthPointMax = healthPoint;
            healthPointNow = healthPoint;
            this.childDamage = childDamage;
            stepCounter = 0;
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

        private Size SizeHalf
        {
            get { return new Size(vanBody.Width / 2, vanBody.Height / 2); }
        }

        public Size Direction
        {
            get { return vanDirection; }
            set { vanDirection = value; }
        }

        public int TargetPointNumber
        {
            get { return targetPathNumber; }
            set { targetPathNumber = value; }
        }

        public int StepCounter
        {
            get { return stepCounter; }
            set { stepCounter = value; }
        }

        public float HealthPointNow
        {
            get { return healthPointNow; }
            set { healthPointNow = value; }
        }
        public int HealthPercent
        {
            get
            {
                if (HealthPointNow <= 0)
                    return 0;
                return Convert.ToInt32(HealthPointNow / healthPointMax * 100);
            }
        }

        public void UpdateVan(bool turned)
        {
            Point p = LocationMiddle;
            if (turned)
                vanBody.Size = vanSizeTurned;
            else
                vanBody.Size = vanSize;
            LocationMiddle = p;
        }
        public void Damage(float damage)
        {
            HealthPointNow -= damage;
        }
    }
}
