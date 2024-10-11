using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using ZombiesApocalypse.Helpers;
namespace ZombiesApocalypse
{
    class Limit : Entity
    {
        private Game _game;
        public Limit(Game game) : base()
        {
            _game = game;
            TintColor = Color.White;
            Health = 25;
            EntityManager.Add(this);
        }
        public override void LoadContent()
        {
            EntityTexture = _game.Content.Load<Texture2D>("LimitWire");

            //Position et hitbox définies après car sinon la texture n'est pas définie
            Position = new Vector2(0, GlobalHelpers.SCREENHEIGHT / (float)1.3);
            Hitbox = new Rectangle((int)Position.X, (int)Position.Y, EntityTexture.Width, EntityTexture.Height);
        }

        public override void Update(GameTime gameTime)
        {

        }
        public void takeDamage(int Damage)
        {
            Health -= Damage;
        }
    }
}
