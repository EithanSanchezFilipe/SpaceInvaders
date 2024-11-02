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
        public const float RIFLECOOLDOWN = 0.4f;
        public const float ZOMBIEATTACKCOOLDOWN = 1.5f;
        public const int ATTACKCHANGECOOLDOWN = 10;
        public const float LEVELDISPLAYTIMER = 2;
        public const int MINSPAWNDISTANCE = 100;
        /// <summary>
        /// Methode qui genere un chiffre aleatoire
        /// </summary>
        /// <param name="Min"></param>
        /// <param name="Max"></param>
        /// <returns>un chiffre aleatoire dans l'intervale donnee</returns>
        public static int RandomNumber(int Min, int Max)
        {
            Random rnd = new Random();
            int NmbrAleatoire = rnd.Next(Min, Max);
            return NmbrAleatoire;
        } 
    }
}
