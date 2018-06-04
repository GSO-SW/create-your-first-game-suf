using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense_Test
{
    static class Resources
    {
        static private float candy, live;

        static public float Candy
        {
            get { return candy; }
            set { candy = value; }
        }

        static public float Live
        {
            get { return live; }
            set { live = value; }
        }
    }
}
