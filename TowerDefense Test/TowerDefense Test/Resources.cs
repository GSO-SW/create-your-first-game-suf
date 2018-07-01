using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense_Test
{
    class Resources//Ressourcenklasse
    {
        static private float candyCounter, lifeCounter;//Candy- und Lebenscounter
        static private int spawnVan, waveCount, ticksPerVan;

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
        static public int SpawnVan
        {
            get { return spawnVan; }
            set { spawnVan = value; }
        }

        static public int WaveCount
        {
            get { return waveCount; }
            set { waveCount = value; }
        }

        static public int TicksPerVan
        {
            get { return ticksPerVan; }
            set { ticksPerVan = value; }
        }
    }
}
