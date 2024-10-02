using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using ZombiesApocalypse.Helpers;

namespace ZombiesApocalypse
{
    public class Level
    {
        private Game _game;
        private int _numberOfZombiesToSpawn;
        public int NumberLevel{get; private set;}
        public int NumberOfZombies { get; private set; }

        public Level(Game game)
        {
            _game = game;
            NumberLevel = 0;
            NumberOfZombies = 0;
            _numberOfZombiesToSpawn = 5;
        }

        public void SpawnZombie()
        {
            Vector2 SpawnPosition = Vector2.Zero;

            //Boucle qui créer des zombies jusqu'a sa limite
            for (int i = 0; i < _numberOfZombiesToSpawn; i++)
            {
                //Boucle infinie tant que la position du zombie n'est pas bonne
                while (true)
                {
                    int spawnX = GlobalHelpers.RandomNumber(100, GlobalHelpers.SCREENWIDTH - 100);
                    int spawnY = GlobalHelpers.RandomNumber(-800, -100);
                    SpawnPosition = new Vector2(spawnX, spawnY);

                    if (PositionOK(SpawnPosition))
                    {
                        new Ennemy(_game, SpawnPosition);
                        NumberOfZombies++;
                        break;
                    }
                }
            }
        }

        private bool PositionOK(Vector2 SpawnPosition)
        {
            foreach(Entity entity in EntityManager.Entities)
            {
                //Prends que les entités qui sont des zombies
                if(entity is Ennemy)
                {
                    //Calcule la distance entre zombies
                    float distance = Vector2.Distance(SpawnPosition, entity.Position);

                    if (distance < GlobalHelpers.MINSPAWNDISTANCE)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
