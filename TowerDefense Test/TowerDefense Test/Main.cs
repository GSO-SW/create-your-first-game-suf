using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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
		//Bitmap monster = new Bitmap(Image.FromFile(Application.StartupPath + @"\bitmap\Sunny.bmp"), 20, 50);
		Bitmap strasseGerade = new Bitmap(Image.FromFile(Application.StartupPath + @"\bitmap\Straße_Gerade.bmp"), 50, 50);
		Bitmap strasseGeradeQuer = new Bitmap(Image.FromFile(Application.StartupPath + @"\bitmap\Straße_Gerade_Quer.bmp"), 50, 50);
		Bitmap strasseKurveOR = new Bitmap(Image.FromFile(Application.StartupPath + @"\bitmap\Straße_Kurve_OR.bmp"), 50, 50);
		Bitmap strasseKurveRU = new Bitmap(Image.FromFile(Application.StartupPath + @"\bitmap\Straße_Kurve_RU.bmp"), 50, 50);
		Bitmap strasseKurveUL = new Bitmap(Image.FromFile(Application.StartupPath + @"\bitmap\Straße_Kurve_UL.bmp"), 50, 50);
		Bitmap strasseKurveLO = new Bitmap(Image.FromFile(Application.StartupPath + @"\bitmap\Straße_Kurve_LO.bmp"), 50, 50);
		Bitmap strasseKreuzung = new Bitmap(Image.FromFile(Application.StartupPath + @"\bitmap\Straße_Kreuzung.bmp"), 50, 50);
		Bitmap towerBuildingPlaceImage = new Bitmap(Image.FromFile(Application.StartupPath + @"\bitmap\TowerBuildingPlace.bmp"), 100, 100);
		bool Selected, startSpawn;
		int i;

		public Main()
		{

			InitializeComponent();
			SetStyle(ControlStyles.DoubleBuffer, true);
			SetStyle(ControlStyles.UserPaint, true);
			SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

			Resources.SpawnVan = 50;
			Resources.TicksPerVan = 10;
			Resources.CandyCounter = 50;
			Resources.LifeCounter = 500;

			path = new Path(new Point[]
			{
				new Point(150, 0),
				new Point(150, 625),
				new Point(350, 625),
				new Point(350, 375),
				new Point(700, 375),
				new Point(700, 75),
				new Point(500, 75),
				new Point(500, 625),
				new Point(900, 625),
				new Point(900, 375),
				new Point(1200, 375)

			});
			//van = new Van[10];
			vanInAction = new Van[0];
			towerInAction = new Tower[0];
			//Tower building places
			TowerBuildingPlace = new Rectangle[5];
			TowerBuildingPlace[0] = new Rectangle(200, 175, 100, 100);
			TowerBuildingPlace[1] = new Rectangle(200, 475, 100, 100);
			TowerBuildingPlace[2] = new Rectangle(550, 475, 100, 100);
			TowerBuildingPlace[3] = new Rectangle(950, 425, 100, 100);
			TowerBuildingPlace[4] = new Rectangle(550, 125, 100, 100);
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

			for (int i = path.PathPoints[0].Y; i < path.PathPoints[1].Y; i += 50)
			{
				g.DrawImage(strasseGerade, path.PathPoints[1].X - 25, i);
			}
			for (int i = path.PathPoints[1].X - 25; i < path.PathPoints[2].X; i += 50)
			{
				g.DrawImage(strasseGeradeQuer, i, path.PathPoints[2].Y - 25);
			}
			for (int i = path.PathPoints[3].Y; i < path.PathPoints[2].Y; i += 50)
			{
				g.DrawImage(strasseGerade, path.PathPoints[3].X - 25, i - 25);
			}
			for (int i = path.PathPoints[3].X - 25; i < path.PathPoints[4].X; i += 50)
			{
				g.DrawImage(strasseGeradeQuer, i, path.PathPoints[4].Y - 25);
			}
			for (int i = path.PathPoints[5].Y; i < path.PathPoints[4].Y; i += 50)
			{
				g.DrawImage(strasseGerade, path.PathPoints[5].X - 25, i - 25);
			}
			for (int i = path.PathPoints[6].X - 25; i < path.PathPoints[5].X; i += 50)
			{
				g.DrawImage(strasseGeradeQuer, i, path.PathPoints[6].Y - 25);
			}
			for (int i = path.PathPoints[6].Y; i < path.PathPoints[7].Y; i += 50)
			{
				g.DrawImage(strasseGerade, path.PathPoints[7].X - 25, i - 25);
			}
			for (int i = path.PathPoints[7].X - 25; i < path.PathPoints[8].X; i += 50)
			{
				g.DrawImage(strasseGeradeQuer, i, path.PathPoints[8].Y - 25);
			}
			for (int i = path.PathPoints[9].Y; i < path.PathPoints[8].Y; i += 50)
			{
				g.DrawImage(strasseGerade, path.PathPoints[9].X - 25, i - 25);
			}
			for (int i = path.PathPoints[9].X - 25; i < path.PathPoints[10].X; i += 50)
			{
				g.DrawImage(strasseGeradeQuer, i, path.PathPoints[10].Y - 25);
			}
			g.DrawImage(strasseKurveOR, path.PathPoints[1].X - 25, path.PathPoints[1].Y - 25);
			g.DrawImage(strasseKurveLO, path.PathPoints[2].X - 25, path.PathPoints[2].Y - 25);
			g.DrawImage(strasseKurveRU, path.PathPoints[3].X - 25, path.PathPoints[3].Y - 25);
			g.DrawImage(strasseKurveLO, path.PathPoints[4].X - 25, path.PathPoints[4].Y - 25);
			g.DrawImage(strasseKurveUL, path.PathPoints[5].X - 25, path.PathPoints[5].Y - 25);
			g.DrawImage(strasseKurveRU, path.PathPoints[6].X - 25, path.PathPoints[6].Y - 25);
			g.DrawImage(strasseKurveOR, path.PathPoints[7].X - 25, path.PathPoints[7].Y - 25);
			g.DrawImage(strasseKurveLO, path.PathPoints[8].X - 25, path.PathPoints[8].Y - 25);
			g.DrawImage(strasseKurveRU, path.PathPoints[9].X - 25, path.PathPoints[9].Y - 25);
			g.DrawImage(strasseKreuzung, path.PathPoints[7].X - 25, path.PathPoints[4].Y - 25);
			foreach (Rectangle item in TowerBuildingPlace)
			{
				g.DrawImage(towerBuildingPlaceImage, item);
			}

			foreach (Van van in vanInAction)
			{
				g.FillRectangle(new SolidBrush(Color.LimeGreen), van.Body);
				g.DrawRectangle(new Pen(Color.Black), van.Body);
				//g.DrawImage(monster, van.Body.Location);

			}
			foreach (Tower tower in towerInAction)
			{
				g.DrawRectangle(new Pen(Color.Red), tower.Body);
				if (tower.Target != null)
					g.DrawLine(Pens.ForestGreen, tower.Location, tower.Target.LocationMiddle);
			}

			foreach (Rectangle item in TowerBuildingPlace)
			{
				g.DrawRectangle(new Pen(Color.Transparent), item);
			}
			foreach (Rectangle item in TowerShop)
			{
				g.DrawRectangle(new Pen(Color.Black), item);
			}
			g.DrawRectangle(new Pen(Color.Black), new Rectangle(725, -1, 500, 200));
			g.DrawString("Laser-\nTower\n50 Candy", new Font("Arial", 16), new SolidBrush(Color.Black), 790, 70);



		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			foreach (Van van in vanInAction)
			{
				moveVan(van);
			}
			foreach (Tower tower in towerInAction)
			{
				tower.Reload();
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
				if (tower.Target != null && tower.Timer == 0)
					tower.Target.Damage(tower.ShotDamage());
			}
			WaveTimer();
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
			if (towerInAction.Length > 0 && towerInAction[0].Target != null)
				label3.Text = "Tower0TargetPercent: " + towerInAction[0].Target.HealthPercent + "%";
			else
				label3.Text = "Tower0TargetPercent: null";

			waveCountLabel.Text = "Wave:" + Resources.WaveCount.ToString();
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
					Array.Resize(ref towerInAction, towerInAction.Length + 1);
					towerInAction[towerInAction.Length - 1] = new Tower(new Rectangle(TowerBuildingPlace[i].X - 50, TowerBuildingPlace[i].Y - 50, TowerBuildingPlace[i].Width + 100, TowerBuildingPlace[i].Height + 100), 100, 50, 1);
					TowerBuildingPlace[i] = Rectangle.Empty;
					for (int j = i + 1; j < TowerBuildingPlace.Length; j++)
					{
						TowerBuildingPlace[j - 1] = TowerBuildingPlace[j];
					}

					Array.Resize(ref TowerBuildingPlace, TowerBuildingPlace.Length - 1);
					Resources.CandyCounter -= 50;
					updateCounterLabel();

				}

			}
			if (TowerShop[0].Contains(e.Location) && Resources.CandyCounter >= 50)
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

		private void startWaveButton_Click(object sender, EventArgs e)
		{
			startSpawn = !startSpawn;
			////Resources.SpawnVan *= 2;
			//i = Resources.SpawnVan
			//for (i = 0; i < Resources.SpawnVan; i++)
			//{
			//    addVan(new Size(50, 20), path.StartPath, 100f, 150f);
			//}
			//Resources.WaveCount++;
		}

		private void WaveTimer()
		{
			if (!startSpawn)
				return;
			if (i == 0 && Resources.SpawnVan > 0)
			{
				addVan(new Size(50, 20), path.StartPath, 100f, 150f);
				Resources.SpawnVan--;
				i = Resources.TicksPerVan;
			}
			if (Resources.SpawnVan == 0)
			{
				Resources.WaveCount++;
			}
			if (i >= 0)
			{
				i--;
			}
		}
	}
}