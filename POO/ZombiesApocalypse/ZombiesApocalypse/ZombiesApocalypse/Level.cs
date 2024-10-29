using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Windows.Forms;
using ZombiesApocalypse.Helpers;

namespace ZombiesApocalypse
{
    public class Level
    {
        private Game _game;
        private int _numberOfZombiesToSpawn;
        public static int NumberLevel{get; private set;}
        public int NumberOfZombies { get; set; }
        private float _levelDisplayTimer;

        public Level(Game game)
        {
            _game = game;
            NumberLevel = 0;
            NumberOfZombies = 0;
            _numberOfZombiesToSpawn = 5;
            _levelDisplayTimer = 0f;
        }
        public void AddLevel()
        {
            NumberLevel++;

            //Calcul pour que le nombre de zombie augemente vite
            _numberOfZombiesToSpawn = 5 + 4 * NumberLevel;

            //timer qui sert a afficher le texte de chaque nouveau niveau
            _levelDisplayTimer = GlobalHelpers.LEVELDISPLAYTIMER;

            EntityManager.DestroyAllFences();
            Player.NumberOfFences = 0;
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
        public void Update(GameTime gameTime)
        {
            if (_levelDisplayTimer > 0)
            {
                _levelDisplayTimer -= (float)gameTime.ElapsedGameTime.TotalSeconds;
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
        public void Draw(SpriteBatch spriteBatch)
        {
            
            if (_levelDisplayTimer > 0)
            {
                Text.DrawLevelText(spriteBatch, "Lev e l " + NumberLevel, new Vector2(GlobalHelpers.SCREENWIDTH / 2, GlobalHelpers.SCREENHEIGHT / 2));
            }
        }
    }
}
