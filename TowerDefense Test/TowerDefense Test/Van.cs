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
        private Size vanSizeNow;
        private Point vanLocation;
        private Color vanColor;
        private Path path;
        private float healthPointNow;
        private float healthPointMax;
        private int turn;

        public Van(float healthPointMax, float healthPointStart, Color vanColor, Path path, Size vanSize, Point vanLocationMiddle)
        {
            this.healthPointMax = healthPointMax;
            this.healthPointNow = healthPointStart;
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
        public void MoveTimer()
        {

        }
        private void CheckForRotation() // Drüber hinaus
        {

        }
        public void Damage(float damage)
        {
            healthPointNow =- damage;
        }
        public bool Death()
        {
            if (healthPointNow < 0)
                return true;
            return false;
        }
    }
}
