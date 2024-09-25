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
        private Level _level;
        public static int NumberOfZombie = 0;
        public GameRoot()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = GlobalHelpers.screenWidth;
            _graphics.PreferredBackBufferHeight = GlobalHelpers.screenHeight;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _zombieSpawnTimer = 0;
            _level = new Level(this);
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

            if (_zombieSpawnTimer >= _level.SpawnInterval && NumberOfZombie < _level.ZombiesToSpawn)
            {
                Console.WriteLine(_level.CurrentLevel + " " + NumberOfZombie + " " + _level.ZombiesToSpawn);
                SpawnerHelper.SpawnZombie(this, _zombies, Components);
                _zombieSpawnTimer = 0;
                NumberOfZombie++;
            }

            foreach (Zombie zombie in _zombies.ToArray())
            {
                if (zombie.IsDead)
                {
                    Components.Remove(zombie);
                    _zombies.Remove(zombie);
                    _level.ZombieDefeated();
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
