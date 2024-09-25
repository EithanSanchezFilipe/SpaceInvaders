using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieApocalypse.Helpers
{
    public static class Level
    {
        public static int CurrentLevel { get; private set; } = 1;
        public static int ZombiesToSpawn { get; private set; } = 5;
        public static float SpawnInterval { get; private set; } = 3.0f;

        public static void LevelUp()
        {
            CurrentLevel++;
            ZombiesToSpawn += 2;
            SpawnInterval = Math.Max(0.5f, SpawnInterval - 0.2f);
        }
    }

}
