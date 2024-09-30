using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieApocalypse.Helpers
{
    public class GlobalHelpers
    {
        public static int screenHeight = 900;
        public static int screenWidth = 700;
        public static int RandomNumber(int Min, int Max)
        {
            Random rnd = new Random();
            int NmbrAleatoire = rnd.Next(Min, Max);
            return NmbrAleatoire;
        }
    }
}
