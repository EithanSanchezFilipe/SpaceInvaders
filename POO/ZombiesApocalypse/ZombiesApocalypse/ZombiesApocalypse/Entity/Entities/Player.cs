using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using ZombiesApocalypse.Helpers;

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
            Velocity = Speed * Velocity;
            if (InputHelper.GetKeyStatus().IsKeyDown(Keys.A))
                Velocity = new Vector2(-1, 0);
            if (InputHelper.GetKeyStatus().IsKeyDown(Keys.D))
                Velocity = new Vector2(1, 0);
            Position += Velocity;
            Position = Vector2.Clamp(Position, new Vector2 (0 , Position.Y), new Vector2(GlobalHelpers.SCREENWIDTH - EntityTexture.Width, Position.Y));
        }
    }

}
