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
        public const int PISTOLCOOLDOWN = 1;
        public const int FENCECOOLDOWN = 2;
        public const float RIFLECOOLDOWN = (float)0.4;
        public const float ZOMBIEATTACKCOOLDOWN = (float)1.5;
        public const float ATTACKCHANGECOOLDOWN = (float)10;
        public const float LEVELDISPLAYTIMER = 2;
        public const int MINSPAWNDISTANCE = 100;
        public static int RandomNumber(int Min, int Max)
        {
            Random rnd = new Random();
            int NmbrAleatoire = rnd.Next(Min, Max);
            return NmbrAleatoire;
        }

    }
}
