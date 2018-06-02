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
            vanInAction[0] = new Van(10f, 10f, Color.Aqua, path, new Size(100, 50), 20, path.StartPath);
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
                label1.Text = a.ToString();
                a++;
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics graphics = e.Graphics;
            Font font = new Font("Comic Sans MS", 11);
            Pen stift = Pens.Black;
            SolidBrush Ausfüller = new SolidBrush(Color.Black);
            SolidBrush Text = new SolidBrush(Color.White);
            Rectangle Van = new Rectangle(10, 20, 50, 100);
            Rectangle Fenster = new Rectangle(50, 100, 50, 75);
            graphics.DrawRectangle(stift, vanInAction[0].Body);
            graphics.FillRectangle(Ausfüller, vanInAction[0].Window);
            graphics.FillEllipse(Ausfüller, 3, 30, 20, 20);
            graphics.FillEllipse(Ausfüller, 8, 30, 20, 20);
            graphics.FillEllipse(Ausfüller, 3, 50, 20, 20);
            graphics.FillEllipse(Ausfüller, 8, 50, 20, 20);
            graphics.RotateTransform(90);
            graphics.DrawString(" Free \nCandy", font, Text, 38, -60);
            graphics.RotateTransform(270);

            label1.Text = "TopLeft: " + vanInAction[0].LocationTopLeft.ToString();
            label_Info.Text = "Middle: " + vanInAction[0].LocationMiddle.ToString();

        }
    }
}
