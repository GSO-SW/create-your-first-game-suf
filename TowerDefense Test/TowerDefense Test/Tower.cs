using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TowerDefense_Test
{
    class Tower
    {
        private float damage, cost;
        private int timer, ticksPerShot, flagBuilding;
        private Rectangle hitbox;
        private Van target;
        private string type;

        public Tower(string type, Point location, int range, float damage, int ticksPerShot, float cost, int flagBuilding)
        {
            this.type = type;
            this.hitbox = new Rectangle(location.X - range, location.Y - range, range * 2, range * 2);
            this.damage = damage;
            this.ticksPerShot = ticksPerShot;
            this.cost = cost;
            this.flagBuilding = flagBuilding;
        }

        public Rectangle Body
        {
            get { return hitbox; }
            set { hitbox = value; }
        }

        public String Type
        {
            get { return type; }
        }

        public Van Target
        {
            get { return target; }
            set { target = value; }
        }

        /// <summary>
        /// Accesses the position of the tower.
        /// </summary>
        public Point Location
        {
            get
            {
                return new Point(hitbox.X + hitbox.Width / 2, hitbox.Y + hitbox.Height / 2);
            }
        }

        /// <summary>
        /// Accesses the damage of the tower.
        /// </summary>
        public float Damage
        {
            get { return damage; }
            set { damage = value; }
        }

        /// <summary>
        /// Accesses the TicksPerShot of the tower.
        /// </summary>
        public int TicksPerShot
        {
            get { return ticksPerShot; }
            set { ticksPerShot = value; }
        }
        public int Range
        {
            get { return Body.Width / 2; }
        }
        public int Flag
        {
            get { return flagBuilding; }
        }
        public int Timer
        {
            get { return timer; }
            set { timer = value; }
        }

        /// <summary>
        /// Accesses the cost of the tower.
        /// </summary>
        public float Cost
        {
            get { return cost; }
            set { cost = value; }
        }
   
        public void Reload()
        {
            if(timer != 0)
            {
                timer--;
            }
        }

        public float ShotDamage()
        {
            if (timer != 0)
                throw new Exception();
            timer = TicksPerShot;
            return Damage;
        }

        public Tower Copy()
        {
            return (Tower)this.MemberwiseClone();
        }
    }
}