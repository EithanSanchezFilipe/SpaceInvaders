using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombiesApocalypse.Helpers
{
    static class GlobalHelpers
    {
        public static int SCREENHEIGHT = 900;
        public static int SCREENWIDTH = 700;
        public const float BULLETCOOLDOWN = (float)0.5;
        public const float ATTACKCHANGECOOLDOWN = (float)10;
        public const int MINSPAWNDISTANCE = 100;
        public static int RandomNumber(int Min, int Max)
        {
            Random rnd = new Random();
            int NmbrAleatoire = rnd.Next(Min, Max);
            return NmbrAleatoire;
        }

    }
}
