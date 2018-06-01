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
                new Point(0, 50),
                new Point(100, 50),
                new Point(100, 100),
                new Point(100, 150),
                new Point(0, 150)
            });
            van = new Van[10];
            vanInAction = new Van[0];
            for (int i = 0; i < van.Length - 1; i++)
            {
                van[i] = new Van(10f, 10f, Color.Aqua, path, new Size(10, 10), path.StartPath);
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < vanInAction.Length - 1; i++)
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
                        break;
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
    }
}
