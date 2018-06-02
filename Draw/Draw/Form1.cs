using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Draw
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            Font font = new Font("Comic Sans MS", 11);
            Pen stift = Pens.Black;
            Pen stift2 = Pens.White;
            SolidBrush Schwarz = new SolidBrush(Color.Black);
            SolidBrush Weiß = new SolidBrush(Color.White);
            Point[] dreieck = new Point[3] { new Point(100, 100), new Point(100, 125), new Point(120, 100) };
            Point[] dreieck2 = new Point[3] { new Point(120, 125), new Point(104, 125), new Point(120, 104) };
            g.FillRectangle(Schwarz, 100, 100, 90, 50);
            g.FillPolygon(Weiß, dreieck);
            g.FillPolygon(Weiß, dreieck2);
            g.FillEllipse(Schwarz, 110, 140, 22, 22);
            g.DrawEllipse(stift2, 110, 140, 22, 22);
            g.FillEllipse(Schwarz, 155, 140, 22, 22);
            g.DrawEllipse(stift2, 155, 140, 22, 22);
            //g.FillRectangle(Weiß, 100, 100, 10, 10);
            //g.FillEllipse(Schwarz, 100, 100, 20, 20);
            //g.FillRectangle(Weiß, 190, 100, 10, 10);
            //g.FillEllipse(Schwarz, 180, 100, 20, 20);



        }
    }
}
