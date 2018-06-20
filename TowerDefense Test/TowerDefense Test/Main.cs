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
        Form newForm;


        public Main()
        {
            InitializeComponent();
            Van.parentForm = this;

            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            path = new Path(new Point[]
            {
                new Point(100, 100),
                new Point(100, 300),
                new Point(300, 300),
                new Point(300, 100)
            });
            //van = new Van[10];
            vanInAction = new Van[1];
            vanInAction[0] = new Van(new Size(90, 50), path, path.StartPath, 10f, 150f);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (Van van in vanInAction)
            {
                if (van != null)
                    van.Move();
                Invalidate();
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            SolidBrush blackBrush = new SolidBrush(Color.Black);
            foreach (Van van in vanInAction)
            {
                if (van != null)
                    g.FillRectangle(blackBrush, van.Body);
            }
            g.DrawLines(Pens.Black, path.PathPoints);
        }

        public void delVan(Van obj, bool end)
        {
            for (int i = 0; i < vanInAction.Length; i++)
            {
                if (vanInAction[i] == obj)
                {
                    //Van gelöscht
                    vanInAction[i] = null;
                    if (end)
                        Resources.LifeCounter -= 500;
                    else
                        Resources.CandyCounter += 500;
                    updateCounterLabel();
                }
            }
        }
        private void updateCounterLabel()
        {
            candyCounterLabel.Text = Resources.CandyCounter.ToString();
            healthPointCounterLabel.Text = Resources.LifeCounter.ToString();
        }
    }
}
