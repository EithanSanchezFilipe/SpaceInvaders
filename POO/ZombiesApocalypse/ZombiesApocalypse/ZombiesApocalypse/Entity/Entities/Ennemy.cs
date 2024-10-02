using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace ZombiesApocalypse
{
    class Ennemy : Entity
    {
        private Game _game;
        public Ennemy(Game game, GraphicsDevice graphicsDevice) : base(graphicsDevice)
        {
            _game = game;
        }
        public override void LoadContent()
        {
            EntityTexture = _game.Content.Load<Texture2D>("soldat pistolet");
        }

        public override void Update(GameTime gameTime)
        {
            Console.WriteLine("zombie");

        }
    }
}
