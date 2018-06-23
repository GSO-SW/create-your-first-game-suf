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
		private float damage, sps, cost;
		private Rectangle hitbox;
		private Van target;

		public Tower(Rectangle hitbox, float damage, float sps, float cost)
		{
			this.hitbox = hitbox;
			this.damage = damage;
			this.sps = sps;
			this.cost = cost;
		}
		public Rectangle Body
		{
			get { return hitbox; }
			set { hitbox = value; }
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
		/// Accesses the sps of the tower.
		/// </summary>
		public float Sps
		{
			get { return sps; }
			set { sps = value; }
		}

		/// <summary>
		/// Accesses the cost of the tower.
		/// </summary>
		public float Cost
		{
			get { return cost; }
			set { cost = value; }
		}


	}
}