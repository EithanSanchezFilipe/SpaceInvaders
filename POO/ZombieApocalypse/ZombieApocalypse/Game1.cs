using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;

namespace ZombieApocalypse
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Player _soldat;
        private List<Zombie> _zombies = new List<Zombie>();
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = GlobalHelpers.screenWidth;
            _graphics.PreferredBackBufferHeight = GlobalHelpers.screenHeight;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _soldat = new Player(this, Components);
            Components.Add(_soldat);
            for (int i = 0; i < 6; i++)
                _zombies.Add(new Zombie(this));
            foreach (var zombie in _zombies)
                Components.Add(zombie);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            List<Zombie> zombiesToRemove = new List<Zombie>();
            List<Bullet> BulletsToRemove = new List<Bullet>();
            foreach (var zombie in _zombies)
            {
                if (zombie.IsDead)
                {
                    zombiesToRemove.Add(zombie);
                }
                foreach(var bullet in _soldat.Bullets)
                {
                    if(!zombie.isDespawning == true && bullet._position.Y < zombie._position.Y && bullet._position.X > zombie._position.X - (zombie._position.X / 9) - 8 && bullet._position.X < zombie._position.X + (zombie._position.X / 5) + 8)
                    {
                        Console.Write("Collision balle zombie");
                        zombie.isDespawning = true;
                        BulletsToRemove.Add(bullet);
                    }
                }
            }
            foreach (Bullet Bullet in BulletsToRemove)
            {
                _soldat.Bullets.Remove(Bullet);
                Components.Remove(Bullet);
            }
            foreach (var zombie in zombiesToRemove)
            {
                _zombies.Remove(zombie);
                Components.Remove(zombie);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}