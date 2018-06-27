using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TowerDefense_Test
{
	public partial class Main : Form
	{
		Path path;
		Van[] van;
		Van[] vanInAction;
		Rectangle[] TowerBuildingPlace;
		Rectangle[] TowerShop;
		Tower[] towerInAction;
		Bitmap b = new Bitmap(@"C:\Users\Marco\Source\Repos\create-your-first-game-suf\TowerDefense Test\TowerDefense Test\bitmap\test.bmp");
		bool Selected;

		public Main()
		{

			InitializeComponent();
			SetStyle(ControlStyles.DoubleBuffer, true);
			SetStyle(ControlStyles.UserPaint, true);
			SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

			path = new Path(new Point[]
			{
				new Point(150, 0),
				new Point(150, 600),
				new Point(350, 600),
				new Point(350, 400),
				new Point(700, 400),
				new Point(700, 100),
				new Point(525, 100),
				new Point(525, 600),
				new Point(900, 600),
				new Point(900, 400),
				new Point(1200, 400)

			});
			//van = new Van[10];
			vanInAction = new Van[0];
			towerInAction = new Tower[1];
			towerInAction[0] = new Tower(new Rectangle(0, 0, 0, 0), 1, 1, 1);
			//Tower building places
			TowerBuildingPlace = new Rectangle[5];
			TowerBuildingPlace[0] = new Rectangle(200, 175, 100, 100);
			TowerBuildingPlace[1] = new Rectangle(200, 450, 100, 100);
			TowerBuildingPlace[2] = new Rectangle(560, 450, 100, 100);
			TowerBuildingPlace[3] = new Rectangle(950, 450, 100, 100);
			TowerBuildingPlace[4] = new Rectangle(560, 155, 100, 100);
			//Tower menu
			TowerShop = new Rectangle[1];
			TowerShop[0] = new Rectangle(775, 50, 100, 100);

			Selected = false;
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			Graphics g = e.Graphics;
			SolidBrush blackBrush = new SolidBrush(Color.Black);
			g.DrawLines(Pens.Black, path.PathPoints);
			foreach (Van van in vanInAction)
			{
				//g.DrawImage(b, van.Body.Location);
				g.FillRectangle(new SolidBrush(Color.LimeGreen), van.Body);
				g.DrawRectangle(new Pen(Color.Black), van.Body);

			}
			foreach (Tower tower in towerInAction)
			{
				if (tower.Target != null)
					g.DrawLine(Pens.ForestGreen, tower.Location, tower.Target.LocationMiddle);
			}

			foreach (Rectangle item in TowerBuildingPlace)
			{
				g.DrawRectangle(new Pen(Color.Black), item);
			}
			foreach (Rectangle item in TowerShop)
			{
				g.DrawRectangle(new Pen(Color.Black), item);
			}

			g.DrawRectangle(new Pen(Color.Black), new Rectangle(725, -1, 500, 200));
			g.DrawString("Laser-\nTower\n50 Candy", new Font("Arial", 16), new SolidBrush(Color.Black), 790, 70);
			g.DrawRectangle(new Pen(Color.Red), towerInAction[0].Body);

		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			foreach (Van van in vanInAction)
			{
				moveVan(van);
			}
			foreach (Tower tower in towerInAction)
			{
				if (tower.Target == null) //Target null
				{
					towerSearchNewTarget(tower);
				}
				else
				{
					if (!tower.Body.IntersectsWith(tower.Target.Body) || tower.Target.HealthPointNow <= 0) //Target wegefahren
					{
						tower.Target = null;
						towerSearchNewTarget(tower);
					}
				}
				if (tower.Target != null)
					tower.Target.Damage(tower.Damage);
			}
			updateCounterLabel();
			Invalidate();
		}

		private void addVan(Size size, Point startPoint, float healthPoint, float childDamage)
		{
			Array.Resize(ref vanInAction, vanInAction.Length + 1);
			vanInAction[vanInAction.Length - 1] = new Van(size, startPoint, healthPoint, childDamage);
		}

		private void delVan(Van obj, bool end)
		{
			for (int i = 0; i < vanInAction.Length; i++)
			{
				if (vanInAction[i] == obj)
				{
					//Van gelöscht
					vanInAction[i] = null;
					for (int j = i + 1; j < vanInAction.Length; j++)
					{
						vanInAction[j - 1] = vanInAction[j];
					}

					Array.Resize(ref vanInAction, vanInAction.Length - 1);

					if (end)
						Resources.LifeCounter -= 1;
					else
						Resources.CandyCounter += 10;
					updateCounterLabel();
					break;
				}
			}
		}

		private void moveVan(Van obj)
		{
			if (obj.LocationMiddle == path.PathPoints[obj.TargetPointNumber])
			{
				if (obj.LocationMiddle != path.EndPath && obj.LocationMiddle != path.StartPath) //Ecke
				{
					obj.TargetPointNumber++;
					obj.Direction = dirVan(obj);
				}
				else if (obj.LocationMiddle == path.StartPath) //Start
				{
					obj.TargetPointNumber = 1;
					obj.Direction = dirVan(obj);
				}
				else //Ende
				{
					delVan(obj, true);
				}
			}
			if (obj.HealthPointNow > 0)
			{
				obj.LocationMiddle = Point.Add(obj.LocationMiddle, obj.Direction);
				obj.StepCounter++;
			}
			else
				delVan(obj, false);
		}

		private Size dirVan(Van obj)
		{
			Point p1 = path.PathPoints[obj.TargetPointNumber - 1];
			Point p2 = path.PathPoints[obj.TargetPointNumber];
			Point p = new Point(p2.X - p1.X, p2.Y - p1.Y);
			if (p.X > 0) { obj.UpdateVan(false); return new Size(1, 0); }
			if (p.Y > 0) { obj.UpdateVan(true); return new Size(0, 1); }
			if (p.X < 0) { obj.UpdateVan(false); return new Size(-1, 0); }
			else { obj.UpdateVan(true); return new Size(0, -1); }
		}

		private void towerSearchNewTarget(Tower t)
		{

			foreach (Van van in vanInAction)
			{
				if (t.Body.IntersectsWith(van.Body))
				{
					if (t.Target == null)
					{
						t.Target = van;
					}
					else if (t.Target.StepCounter < van.StepCounter)
						t.Target = van;
				}
			}
		}

		private void updateCounterLabel()
		{
			label1.Text = "Candy: " + Resources.CandyCounter.ToString();
			label2.Text = "Health: " + Resources.LifeCounter.ToString();
			if (towerInAction[0].Target != null)
				label3.Text = "Tower0TargetPercent: " + towerInAction[0].Target.HealthPercent + "%";
			else
				label3.Text = "Tower0TargetPercent: null";
		}

		private void button1_Click(object sender, EventArgs e)
		{
			addVan(new Size(50, 20), path.StartPath, 100f, 150f);
		}

		private void Main_MouseDown(object sender, MouseEventArgs e)
		{


			for (int i = 0; i < TowerBuildingPlace.Length; i++)
			{

				if (TowerBuildingPlace[i].Contains(e.Location) && Selected)
				{
					TowerBuildingPlace[i] = Rectangle.Empty;
					for (int j = i + 1; j < TowerBuildingPlace.Length; j++)
					{
						TowerBuildingPlace[j - 1] = TowerBuildingPlace[j];
					}

					Array.Resize(ref TowerBuildingPlace, TowerBuildingPlace.Length - 1);

				}

			}
			if (TowerShop[0].Contains(e.Location))
			{
				Selected = true;
				Cursor = Cursors.Help;
			}
			else if (ClientRectangle.Contains(e.Location))
			{
				Selected = false;
				Cursor = Cursors.Default;
			}

		}

	}
}
