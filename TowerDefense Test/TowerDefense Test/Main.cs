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
        Van[] vanInAction;
        Tower[] towerInAction;
        Bitmap b = new Bitmap(@"C:\Users\René\Source\Repos\create-your-first-game-suf\TowerDefense Test\TowerDefense Test\bitmap\test.bmp");

        public Main()
        {
            
            InitializeComponent();
            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            path = new Path(new Point[]
            {
                new Point(100 ,300),
                new Point(500, 300),
                new Point(500, 100),
                new Point(300, 100),
                new Point(300, 500)
                
            });
            //van = new Van[10];
            vanInAction = new Van[0];
            towerInAction = new Tower[1];
            towerInAction[0] = new Tower(new Rectangle(275, 75, 250, 250), 1, 1, 1);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            SolidBrush blackBrush = new SolidBrush(Color.Black);
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
            g.DrawRectangle(new Pen(Color.Red), towerInAction[0].Body);
            g.DrawLines(Pens.Black, path.PathPoints);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (Van van in vanInAction)
            {
                moveVan(van);
            }
            foreach (Tower tower in towerInAction)
            {
                if(tower.Target == null) //Target null
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
                        Resources.LifeCounter -= 500;
                    else
                        Resources.CandyCounter += 500;
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
    }
}
