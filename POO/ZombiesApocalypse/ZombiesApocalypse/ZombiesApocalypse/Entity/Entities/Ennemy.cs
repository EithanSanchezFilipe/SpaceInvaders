using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace ZombiesApocalypse
{
    class Ennemy : Entity
    {
        private Game _game;
        public static int Damage;
        public bool isColliding;
        public float _attackCooldown;
        public Ennemy(Game game, Vector2 StartPosition) : base()
        {
            Position = StartPosition;

            _game = game;
            TintColor = Color.White;
            Speed = 1;
            Health = 20;
            EntityManager.Add(this);
            Damage = 5;
            isColliding = false;
        }

        public override void LoadContent()
        {
            EntityTexture = _game.Content.Load<Texture2D>("zombie");

            //lahitbox se place ou le zombie est
            Hitbox = new Rectangle((int)Position.X, (int)Position.Y, EntityTexture.Width, EntityTexture.Height);
        }

        public override void Update(GameTime gameTime)
        {
            _attackCooldown -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            
            //Verifie si le zombie est pas en collision
            if (!isColliding)
            {
                //Mouvement
                Velocity = new Vector2(0, 1);

                Velocity = Speed * Velocity;
                Position += Velocity;

                //Bouge la hitbox au même temps que le zombie
                Hitbox = new Rectangle((int)Position.X, (int)Position.Y, EntityTexture.Width, EntityTexture.Height);
            }
            else
                Velocity = Vector2.Zero;
        }
        public void TakeDamage(int Damage)
        {
            Health -=Damage;
        }
    }
}
