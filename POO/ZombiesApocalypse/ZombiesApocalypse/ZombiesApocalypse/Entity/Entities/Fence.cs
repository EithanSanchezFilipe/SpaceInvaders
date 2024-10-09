using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using ZombiesApocalypse.Helpers;
namespace ZombiesApocalypse
{
    class Fence : Entity
    {
        private Game _game;
        public Fence(Game game , Vector2 PlayerPosition) : base()
        {
            _game = game;
            TintColor = Color.White;
            Health = 10;
            Position = new Vector2(PlayerPosition.X, GlobalHelpers.SCREENHEIGHT/2);
            EntityManager.Add(this);
        }
        public override void LoadContent()
        {
            EntityTexture = _game.Content.Load<Texture2D>("Fence");
            Hitbox = new Rectangle((int)Position.X, (int)Position.Y, EntityTexture.Width, EntityTexture.Height);
        }

        public override void Update(GameTime gameTime)
        {

        }
    }
}
