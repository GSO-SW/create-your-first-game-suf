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
            Resources.IntLive = 50;
            Resources.IntCandy = 1000;

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

        public void delVan(Van obj)
        {
            for (int i = 0; i < vanInAction.Length; i++)
            {
                if (vanInAction[i] == obj)
                    vanInAction[i] = null;
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void candyShowLabel_Click(object sender, EventArgs e)
        {            
        }

        private void VanKaputtbutton_Click(object sender, EventArgs e)
        {
            Resources.IntCandy = Resources.IntCandy + 500;
            Resources.StringCandy = Convert.ToString(Resources.IntCandy);
            candyShowLabel.Text = Resources.StringCandy ;

        }

        private void minusLebenButton_Click(object sender, EventArgs e)
        {
            if(Resources.IntLive==0)
            {
                childrenShowLabel.Text = "Keine Leben mehr";
            }


            else
            {
                Resources.IntLive = Resources.IntLive - 5;
                Resources.StringLive = Convert.ToString(Resources.IntLive);
                childrenShowLabel.Text = Resources.StringLive;
            }                 

        }

        private void towerLabel_Click(object sender, EventArgs e)
        {

        }

        private void towerCountLabel_Click(object sender, EventArgs e)
        {

        }

        private void byTowerButton_Click(object sender, EventArgs e)
        {
            if (Resources.IntCandy <= 249)
            {
                towerCountLabel.Text = "du hast zu wenig Candy";
            }
            else
            {
                Resources.IntCandy = Resources.IntCandy - 250;
                Resources.IntTower = Resources.IntTower + 1;
                Resources.StringTower = Convert.ToString(Resources.IntTower);
                towerCountLabel.Text = Resources.StringTower;
                Resources.StringCandy = Convert.ToString(Resources.IntCandy);
                candyShowLabel.Text = Resources.StringCandy;

            }
        }
    }
}
