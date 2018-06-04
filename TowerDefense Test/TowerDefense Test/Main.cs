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
            vanInAction[0] = new Van(new Size(90, 50), path, path.StartPath, 10f);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i <= vanInAction.Length - 1; i++)
            {
                if (vanInAction[i] != null)
                {
                    switch (vanInAction[i].Stage)
                    {
                        case -1:
                            vanInAction[i] = null;
                            break;
                        case 0:
                            vanInAction[i] = null;
                            //Kinderleben abziehen
                            break;
                        case 1:
                            vanInAction[i].Move();
                            Invalidate();
                            break;
                    }
                }
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

        public void delVan(Van obj)
        {
            for (int i = 0; i < vanInAction.Length; i++)
            {
                if (vanInAction[i] == obj)
                    vanInAction[i] = null;
            }
        }
    }
}
