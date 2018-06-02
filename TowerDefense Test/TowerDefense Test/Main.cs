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
        int a;
        public Main()
        {
            InitializeComponent();

            path = new Path(new Point[]
            {
                new Point(100, 100),
                new Point(100, 300),
                new Point(300, 300),
                new Point(300, 100),
                new Point(100, 100)
            });
            van = new Van[10];
            vanInAction = new Van[1];
            vanInAction[0] = new Van(10f, 10f, Color.Aqua, path, new Size(90, 50), new Size(20,25), path.StartPath, 20);
            //for (int i = 0; i < van.Length - 1; i++)
            //{
            //    van[i] = new Van(10f, 10f, Color.Aqua, path, new Size(10, 10), 20, path.StartPath);
            //}
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
        private void button1_Click(object sender, EventArgs e)
        {
            if (a < van.Length)
            {
                Array.Resize(ref vanInAction, vanInAction.Length + 1);
                vanInAction[vanInAction.Length - 1] = van[a];
                a++;
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            Font font = new Font("Comic Sans MS", 11);
            Pen stift = Pens.Black;
            Pen stift2 = Pens.White;
            SolidBrush Ausfüller = new SolidBrush(Color.Black);
            SolidBrush Text = new SolidBrush(Color.White);
            Rectangle Van = new Rectangle(10, 20, 50, 100);
            Rectangle Fenster = new Rectangle(50, 100, 50, 75);

            //Pen linePen = Pens.Black;
            //graphics.DrawLine(linePen, 800, 0, 800, 600);
            //graphics.DrawLine(linePen, 800, 150, 916, 150);
            //graphics.DrawLine(linePen, 800, 300, 916, 300);
            foreach (Van van in vanInAction)
            {
                
                g.FillRectangle(Ausfüller, van.Body);
                g.FillRectangle(Text, van.WindowBox);
                g.FillPolygon(Ausfüller, van.WindowTriangle);
                g.FillEllipse(Ausfüller, van.Wheel1);
                g.DrawEllipse(stift2, van.Wheel1);
                g.FillEllipse(Ausfüller, van.Wheel2);
                g.DrawEllipse(stift2, van.Wheel2);
            }



            //g.FillEllipse(Ausfüller, 3, 30, 20, 20);
            //g.FillEllipse(Ausfüller, 8, 30, 20, 20);
            //g.FillEllipse(Ausfüller, 3, 50, 20, 20);
            //g.FillEllipse(Ausfüller, 8, 50, 20, 20);
            //graphics.RotateTransform(90);
            //graphics.DrawString(" Free \nCandy", font, Text, 38, -60);
            //graphics.RotateTransform(270);
        }
    }
}
