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
        Rectangle towerShop, startRec, hitboxRec;
        Rectangle[] towerBuildingPlace, towerShopItemRec;
        Tower selectedTower;
        Tower[] towerShopItem, towerPlaced;
        Bitmap strasseGerade, strasseGeradeQuer, strasseKurveOR, strasseKurveRU, strasseKurveUL, strasseKurveLO, strasseKreuzung, towerBuildingPlaceImage, towerPoison, towerInferno;
        bool startSpawn, showHitbox;
        int waveCounter;

        public Main()
        {
            InitializeComponent();

            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            FormBorderStyle = FormBorderStyle.FixedSingle;

            Resources.SpawnVan = 50;
            Resources.TicksPerVan = 100;
            Resources.CandyCounter = 50;
            Resources.LifeCounter = 10;

            strasseGerade = new Bitmap(Image.FromFile(pathCutter(Application.StartupPath, 2) + @"bitmap\Straße_Gerade.bmp"), 50, 50);
            strasseGeradeQuer = new Bitmap(Image.FromFile(pathCutter(Application.StartupPath, 2) + @"bitmap\Straße_Gerade_Quer.bmp"), 50, 50);
            strasseKurveOR = new Bitmap(Image.FromFile(pathCutter(Application.StartupPath, 2) + @"bitmap\Straße_Kurve_OR.bmp"), 50, 50);
            strasseKurveRU = new Bitmap(Image.FromFile(pathCutter(Application.StartupPath, 2) + @"bitmap\Straße_Kurve_RU.bmp"), 50, 50);
            strasseKurveUL = new Bitmap(Image.FromFile(pathCutter(Application.StartupPath, 2) + @"bitmap\Straße_Kurve_UL.bmp"), 50, 50);
            strasseKurveLO = new Bitmap(Image.FromFile(pathCutter(Application.StartupPath, 2) + @"bitmap\Straße_Kurve_LO.bmp"), 50, 50);
            strasseKreuzung = new Bitmap(Image.FromFile(pathCutter(Application.StartupPath, 2) + @"bitmap\Straße_Kreuzung.bmp"), 50, 50);
            towerBuildingPlaceImage = new Bitmap(Image.FromFile(pathCutter(Application.StartupPath, 2) + @"bitmap\TowerBuildingPlace.bmp"), 100, 100);
			towerPoison = new Bitmap(Image.FromFile(pathCutter(Application.StartupPath, 2) + @"bitmap\Tower_Poison.bmp"), 200, 200);
            towerInferno = new Bitmap(Image.FromFile(pathCutter(Application.StartupPath, 2) + @"bitmap\Tower_Inferno.bmp"), 200, 200);

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

            towerBuildingPlace = new Rectangle[]
            {
                new Rectangle(200, 175, 100, 100),
                new Rectangle(200, 450, 100, 100),
                new Rectangle(550, 450, 100, 100),
                new Rectangle(950, 425, 100, 100),
                new Rectangle(550, 125, 100, 100)
            };

            towerShopItemRec = new Rectangle[]
            {
                new Rectangle(775, 50, 100, 100),
                new Rectangle(925, 50, 100, 100)
            };

            towerShopItem = new Tower[]
            {
                new Tower("La001", Point.Empty, 150, 20, 20, 50, 0),
                new Tower("La002", Point.Empty, 200, 300, 200, 100, 0)
            };

            vanInAction = new Van[0];
            towerPlaced = new Tower[0];

            towerShop = new Rectangle(725, -1, 500, 200);
            startRec = new Rectangle(5, 5, 100, 40);
            hitboxRec = new Rectangle(0, Size.Height - 70, 32, 32);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;

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
                if (showHitbox)
                    g.DrawRectangle(new Pen(Color.Red), tower.Body);
                if (tower.Target != null)
                {
                    g.DrawLine(new Pen(Color.DarkGoldenrod, 1f), tower.Location, tower.Target.LocationMiddle);
                    if (tower.Timer < 10)
                        g.DrawLine(new Pen(Color.DarkGoldenrod, tower.Damage / 100 + 10), tower.Location, tower.Target.LocationMiddle);
                }
                if (tower.Type == towerShopItem[0].Type)
                {
                    Color backColorPoison = towerPoison.GetPixel(1, 1);
                    towerPoison.MakeTransparent(backColorPoison);
                    g.DrawImage(towerPoison, tower.Location.X - 100, tower.Location.Y - 100);
                }
                else if (tower.Type == towerShopItem[1].Type)
                {
                    Color backColorInferno = towerInferno.GetPixel(1, 1);
                    towerInferno.MakeTransparent(backColorInferno);
                    g.DrawImage(towerInferno, tower.Location.X - 100, tower.Location.Y - 100);
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
			g.DrawString(Resources.LifeCounter + " Leben", new Font("Arial", 18, FontStyle.Bold), new SolidBrush(Color.Black), 3, 60);
			g.DrawString(Resources.CandyCounter + " Candy", new Font("Arial", 18, FontStyle.Bold), new SolidBrush(Color.Black), 3, 80);
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
                    if (hitboxRec.Contains(p))
                        showHitbox = !showHitbox;
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
                        addTower(selectedTower.Type, new Point(r.Left + r.Width / 2, r.Top + r.Height / 2), selectedTower.Range, selectedTower.Damage, selectedTower.TicksPerShot, selectedTower.Cost, i);
                        towerBuildingPlace[i] = Rectangle.Empty;
                    }
                }
                selectedTower = null;
                Cursor = Cursors.Default;
            }
        }

        private void gameTick(object sender, EventArgs e)
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
            Invalidate();
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

        private void addTower(string type, Point location, int range, float damage, int ticksPerShot, float cost, int i)
        {
            Array.Resize(ref towerPlaced, towerPlaced.Length + 1);
            towerPlaced[towerPlaced.Length - 1] = new Tower(type, location, range, damage, ticksPerShot, cost, i);
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