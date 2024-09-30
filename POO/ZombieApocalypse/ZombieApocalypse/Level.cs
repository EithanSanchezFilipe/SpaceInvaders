using Microsoft.Xna.Framework;

using System;

namespace ZombieApocalypse
{
    public class Level
    {
        public int CurrentLevel { get; private set; }
        public int ZombiesToSpawn { get; private set; }
        private int zombiesDefeated;
        public float SpawnInterval { get; private set; }
        private Game _gameRoot;
        public Level(Game gameRoot)
        {
            _gameRoot = gameRoot;
            CurrentLevel = 1;
            ZombiesToSpawn = 5;
            SpawnInterval = 3.0f;
            zombiesDefeated = 0;
        }

        public void ZombieDefeated()
        {
            zombiesDefeated++;
            if (zombiesDefeated >= ZombiesToSpawn)
            {
                LevelUp();
            }
        }

        public void LevelUp()
        {
            CurrentLevel++;
            ZombiesToSpawn += 2;
            SpawnInterval = Math.Max(0.5f, SpawnInterval - 0.2f);
            zombiesDefeated = 0;
            GameRoot.NumberOfZombie = 0;
        }
    }
}
