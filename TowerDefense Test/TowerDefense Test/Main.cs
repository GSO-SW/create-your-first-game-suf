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
        Van[] vanInAction;
        Rectangle[] towerBuildingPlace;
        Rectangle[] towerShopItemRec;
        Rectangle towerShop, startRec;
        Tower selectedTower;
        Tower[] towerShopItem;
        Tower[] towerPlaced;
        Bitmap strasseGerade;
        Bitmap strasseGeradeQuer;
        Bitmap strasseKurveOR;
        Bitmap strasseKurveRU;
        Bitmap strasseKurveUL;
        Bitmap strasseKurveLO;
        Bitmap strasseKreuzung;
        Bitmap towerBuildingPlaceImage;
		Bitmap towerPoison;
		bool startSpawn;
        int waveCounter, shotCounter;

        public Main()
        {
            strasseGerade = new Bitmap(Image.FromFile(pathCutter(Application.StartupPath, 2) + @"bitmap\Straße_Gerade.bmp"), 50, 50);
            strasseGeradeQuer = new Bitmap(Image.FromFile(pathCutter(Application.StartupPath, 2) + @"bitmap\Straße_Gerade_Quer.bmp"), 50, 50);
            strasseKurveOR = new Bitmap(Image.FromFile(pathCutter(Application.StartupPath, 2) + @"bitmap\Straße_Kurve_OR.bmp"), 50, 50);
            strasseKurveRU = new Bitmap(Image.FromFile(pathCutter(Application.StartupPath, 2) + @"bitmap\Straße_Kurve_RU.bmp"), 50, 50);
            strasseKurveUL = new Bitmap(Image.FromFile(pathCutter(Application.StartupPath, 2) + @"bitmap\Straße_Kurve_UL.bmp"), 50, 50);
            strasseKurveLO = new Bitmap(Image.FromFile(pathCutter(Application.StartupPath, 2) + @"bitmap\Straße_Kurve_LO.bmp"), 50, 50);
            strasseKreuzung = new Bitmap(Image.FromFile(pathCutter(Application.StartupPath, 2) + @"bitmap\Straße_Kreuzung.bmp"), 50, 50);
            towerBuildingPlaceImage = new Bitmap(Image.FromFile(pathCutter(Application.StartupPath, 2) + @"bitmap\TowerBuildingPlace.bmp"), 100, 100);
			towerPoison = new Bitmap(Image.FromFile(pathCutter(Application.StartupPath, 2) + @"bitmap\Tower_Poison.bmp"), 200, 200);

			InitializeComponent();
            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;

            Resources.SpawnVan = 50;
            Resources.TicksPerVan = 100;
            Resources.CandyCounter = 50;
            Resources.LifeCounter = 500;

            path = new Path(new Point[]
            {
                new Point(150, -50),
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
            towerPlaced = new Tower[0];
            //Tower building places
            towerBuildingPlace = new Rectangle[5];
            towerBuildingPlace[0] = new Rectangle(200, 175, 100, 100);
            towerBuildingPlace[1] = new Rectangle(200, 450, 100, 100);
            towerBuildingPlace[2] = new Rectangle(550, 450, 100, 100);
            towerBuildingPlace[3] = new Rectangle(950, 425, 100, 100);
            towerBuildingPlace[4] = new Rectangle(550, 125, 100, 100);
            //Tower menu
            towerShopItemRec = new Rectangle[2];
            towerShopItem = new Tower[towerShopItemRec.Length];
            towerShopItemRec[0] = new Rectangle(775, 50, 100, 100);
            towerShopItem[0] = new Tower(Point.Empty, 150, 20, 20, 50, 0);
            towerShopItemRec[1] = new Rectangle(925, 50, 100, 100);
            towerShopItem[1] = new Tower(Point.Empty, 200, 300, 200, 100, 0);
            towerShop = new Rectangle(725, -1, 500, 200);
            //Start
            startRec = new Rectangle(5, 5, 100, 40);
        }

        public string pathCutter(string path, int cut)
        {
            string[] ss = path.Split('\\');
            string s = "";
            for (int i = 0; i < ss.Length - cut; i++)
            {
                s += ss[i] + "\\";
            }
            return s;
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
            foreach (Rectangle item in towerBuildingPlace)
            {
                g.DrawImage(towerBuildingPlaceImage, item);
            }
            foreach (Tower tower in towerPlaced)
            {
				Color backColor = towerPoison.GetPixel(1, 1);
				towerPoison.MakeTransparent(backColor);
				g.DrawImage(towerPoison, tower.Location.X - 100, tower.Location.Y - 100);
                if (checkBox1.Checked)
                    g.DrawRectangle(new Pen(Color.Red), tower.Body);
                if (tower.Target != null)
                {
                    g.DrawLine(new Pen(Color.DarkGoldenrod, 1f), tower.Location, tower.Target.LocationMiddle);
                    if (tower.Timer < 10)
                        g.DrawLine(new Pen(Color.DarkGoldenrod, tower.Damage / 100 + 10), tower.Location, tower.Target.LocationMiddle);
                }
            }
            foreach (Van van in vanInAction)
            {
                g.FillRectangle(new SolidBrush(getVanColor(van.HealthPercent)), van.Body);
                g.DrawRectangle(new Pen(Color.Black), van.Body);
            }
            g.DrawRectangle(new Pen(Color.Black), towerShop);
            g.DrawRectangles(new Pen(Color.Black, 5f), towerShopItemRec);
            g.DrawRectangles(new Pen(Color.Transparent, 5f), towerBuildingPlace);
            if (!startSpawn)
                g.DrawString("Start", new Font("Arial", 26, FontStyle.Bold), Brushes.Black, startRec);
            g.DrawString("  Laser-\n  Tower\n" + towerShopItem[0].Cost + " Candy", new Font("Arial", 14, FontStyle.Bold), new SolidBrush(Color.Black), 780, 68);
            g.DrawString("   Boom-\n   Tower\n" + towerShopItem[1].Cost + " Candy", new Font("Arial", 14, FontStyle.Bold), new SolidBrush(Color.Black), 925, 68);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (Van van in vanInAction)
            {
                moveVan(van);
            }
            foreach (Tower tower in towerPlaced)
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
            waveTimer();
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

        private Color getVanColor(int vanPercentHP)
        {
            double red = 0.0;
            double green = 0.0;
            if (vanPercentHP >= 66)
            {
                green = 255.0;
                red = (100 - vanPercentHP) * (255 / 34);
            }
            else if (vanPercentHP >= 33)
            {
                vanPercentHP -= 33;
                green = vanPercentHP * (255 / 34);
                red = 255.0;
            }
            else
            {
                green = 0;
                red = vanPercentHP * (255 / 34);
            }
            return Color.FromArgb((int)red, (int)green, 0);
        }

        private void addTower(Point location, int range, float damage, int ticksPerShot, float cost, int i)
        {
            Array.Resize(ref towerPlaced, towerPlaced.Length + 1);
            towerPlaced[towerPlaced.Length - 1] = new Tower(location, range, damage, ticksPerShot, cost, i);
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

        }

        private void button1_Click(object sender, EventArgs e)
        {
            addVan(new Size(50, 20), path.StartPath, 100f, 150f);
        }

        private void Main_MouseDown(object sender, MouseEventArgs e)
        {
            Point p = e.Location;
            if (selectedTower == null) //Nix ausgewählt
            {
                if (towerShop.Contains(p)) //Wenn oben im Shop
                {
                    for (int i = 0; i < towerShopItemRec.Length; i++)
                    {
                        if (towerShopItemRec[i].Contains(p))
                        {
                            if (Resources.CandyCounter >= towerShopItem[i].Cost)
                            {
                                selectedTower = towerShopItem[i];
                                Cursor = Cursors.Help;
                            }
                        }
                    }
                }
                else //Wenn auf dem Spielfeld
                {
                    if (startRec.Contains(p))
                        startSpawn = true;
                    //UPGRADE
                }
            }
            else //Ausgewählt
            {
                for (int i = 0; i < towerBuildingPlace.Length; i++)
                {
                    if (towerBuildingPlace[i].Contains(p) && towerPlaced.Length < towerBuildingPlace.Length)
                    {
                        foreach (Tower item in towerPlaced)
                        {
                            if (item.Flag == i)
                            {
                                selectedTower = null;
                                Cursor = Cursors.Default;
                                return;
                            }
                        }
                        Resources.CandyCounter -= selectedTower.Cost;
                        Rectangle r = towerBuildingPlace[i];
                        addTower(new Point(r.Left + r.Width / 2, r.Top + r.Height / 2), selectedTower.Range, selectedTower.Damage, selectedTower.TicksPerShot, selectedTower.Cost, i);
                        towerBuildingPlace[i] = Rectangle.Empty;
                    }
                }
                selectedTower = null;
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

        private void waveTimer()
        {
            if (!startSpawn)
                return;
            if (waveCounter == 0 && Resources.SpawnVan > 0)
            {
                addVan(new Size(50, 20), path.StartPath, 200f, 150f);
                Resources.SpawnVan--;
                waveCounter = Resources.TicksPerVan;
            }
            if (Resources.SpawnVan == 0)
            {
                Resources.WaveCount++;
            }
            if (waveCounter >= 0)
            {
                waveCounter--;
            }
        }
    }
}