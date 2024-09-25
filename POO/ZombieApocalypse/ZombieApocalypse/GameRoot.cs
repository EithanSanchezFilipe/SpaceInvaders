using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using ZombieApocalypse.Helpers;

namespace ZombieApocalypse
{
    public class GameRoot : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Player _soldat;
        private List<Zombie> _zombies = new List<Zombie>();
        private float _zombieSpawnTimer;
        private float _zombieSpawnInterval;
        private int _maxZombies = 10;
        private int _level;

        public GameRoot()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = GlobalHelpers.screenWidth;
            _graphics.PreferredBackBufferHeight = GlobalHelpers.screenHeight;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;


            _zombieSpawnInterval = 0.3f;
            _zombieSpawnTimer = 0;
        }

        protected override void Initialize()
        {
            // Initialize player and add to components
            _soldat = new Player(this, Components);
            Components.Add(_soldat);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();


            _zombieSpawnTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;


            if (_zombieSpawnTimer >= _zombieSpawnInterval && _zombies.Count < _maxZombies)
            {
                SpawnerHelper.SpawnZombie(this, _zombies, Components);
                _zombieSpawnTimer = 0;
            }

            foreach (Zombie zombie in _zombies.ToArray())
            {
                if (zombie.IsDead)
                {
                    Components.Remove(zombie);
                    _zombies.Remove(zombie);
                }
                else
                {
                    CheckCollisions(zombie);
                }
            }

            foreach (Bullet bullet in _soldat.Bullets.ToArray())
            {
                if (bullet.IsRemoved)
                {
                    Components.Remove(bullet);
                    _soldat.Bullets.Remove(bullet);
                }
            }

            base.Update(gameTime);
        }

        private void CheckCollisions(Zombie zombie)
        {
            foreach (Bullet bullet in _soldat.Bullets)
            {
                if (CollisionHelpers.CollidesWith(zombie, bullet))
                {
                    zombie.isDespawning = true;
                    bullet.IsRemoved = true; 
                }
            }
        }




        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            base.Draw(gameTime);
        }
    }
}
