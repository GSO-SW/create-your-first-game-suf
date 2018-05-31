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
        Path p;
        Van v;
        public Main()
        {
            InitializeComponent();
            p = new Path(new Point[]
            {
                new Point(0, 50),
                new Point(100, 50),
                new Point(100, 100)
            });
            v = new Van(10f, 10f, Color.Aqua, p, new Size(10, 10), p.StartPath);

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            v.Move();
            label_Info.Text = v.LocationMiddle.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            v.Move();
            label_Info.Text = v.LocationMiddle.ToString();
        }
    }
}
