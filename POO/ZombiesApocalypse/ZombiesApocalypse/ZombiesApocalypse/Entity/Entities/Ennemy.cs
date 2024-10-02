using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace ZombiesApocalypse
{
    class Ennemy : Entity
    {
        private Game _game;
        public Ennemy(Game game, Vector2 StartPosition) : base()
        {
            Position = StartPosition;

            _game = game;
            TintColor = Color.White;
            Speed = 1;
            Health = 20;
            EntityManager.Add(this);
        }

        public override void LoadContent()
        {
            EntityTexture = _game.Content.Load<Texture2D>("zombie");

            //lahitbox se place ou le zombie est
            Hitbox = new Rectangle((int)Position.X, (int)Position.Y, EntityTexture.Width, EntityTexture.Height);
        }

        public override void Update(GameTime gameTime)
        {
            //Mouvement
            Velocity = new Vector2(0, 1);

            Velocity = Speed * Velocity;
            Position += Velocity;
            //Bouge la hitbox au même temps que le zombie
            Hitbox = new Rectangle((int)Position.X, (int)Position.Y, EntityTexture.Width, EntityTexture.Height);
        }
        public void TakeDamage()
        {
            Health -=10;
        }
    }
}
