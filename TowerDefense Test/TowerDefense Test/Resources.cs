using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense_Test
{
    class Resources
    {
        static private float candyCounter, lifeCounter;

        static public float CandyCounter
        {
            get { return candyCounter; }
            set { candyCounter = value; }
        }
        static public float LifeCounter
        {
            get { return lifeCounter; }
            set { lifeCounter = value; }
        }
    }
}
