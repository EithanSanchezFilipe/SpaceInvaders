using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace ZombiesApocalypse
{
    class Player : Entity
    {
        private Game _game;

        public Player(Game game, GraphicsDevice graphicsDevice) : base(graphicsDevice)
        {
            _game = game;
            Health = 100;
            EntityManager.Add(this);
        }

        public override void LoadContent()
        {
            Console.WriteLine("Loading Texture");
            EntityTexture = _game.Content.Load<Texture2D>("soldat pistolet");
        }

        public override void Update(GameTime gameTime)
        {
        }
    }

}
