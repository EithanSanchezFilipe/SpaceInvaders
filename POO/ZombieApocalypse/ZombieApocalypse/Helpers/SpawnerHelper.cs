using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;


namespace ZombieApocalypse.Helpers
{
    static class SpawnerHelper
    {
        private const int MINSPAWNDISTANCE = 100;
        public static void SpawnZombie(Game GameRoot, List<Zombie> zombies, GameComponentCollection Components)
        {
            Vector2 spawnPosition = Vector2.Zero;
            bool isValidPosition = false;

            while (!isValidPosition)
            {
                int spawnX = GlobalHelpers.RandomNumber(100, GlobalHelpers.screenWidth - 100);
                int spawnY = GlobalHelpers.RandomNumber(-500, -100);
                spawnPosition = new Vector2(spawnX, spawnY);


                isValidPosition = CheckIfZombiesAreFarEnough(spawnPosition, zombies);
            }


            Zombie newZombie = new Zombie(GameRoot, spawnPosition);
            zombies.Add(newZombie);
            Components.Add(newZombie);
        }

        private static bool CheckIfZombiesAreFarEnough(Vector2 spawnPosition, List<Zombie> zombies)
        {
            foreach (Zombie zombie in zombies)
            {
                float distance = Vector2.Distance(spawnPosition, zombie.Position);

                if (distance < MINSPAWNDISTANCE)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
