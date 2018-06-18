using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense_Test
{
    class Resources
    {
        static private string stringCandy,stringLive,stringTower;
        static private int intCandy,intLive,intTower;
        

        public Resources(string candyShowLabel,string towerShowLabel,string towerCountLabel)
        {         
            stringCandy = candyShowLabel;
            stringLive = towerShowLabel;
            stringTower = towerCountLabel;
        }
        
        static public string StringCandy
        {
            get { return stringCandy; }
            set { stringCandy = value; }
        }
        static public int IntCandy
        {
            get { return intCandy; }
            set { intCandy = value; }
        }


        static public string StringLive
        {
            get { return stringLive; }
            set { stringLive = value; }
        }
        static public int IntLive
        {
            get { return intLive; }
            set { intLive = value; }
        }

        static public string StringTower
        {
            get { return stringTower; }
            set { stringTower = value; }
        }
        static public int IntTower
        {
            get { return intTower; }
            set { intTower = value; }
        }
    }
}
