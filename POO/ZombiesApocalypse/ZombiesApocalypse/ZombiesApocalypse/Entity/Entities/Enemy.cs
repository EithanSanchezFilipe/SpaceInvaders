using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace ZombiesApocalypse
{
    class Enemy : Entity
    {
        private Game _game;
        public static int Damage;
        public bool isColliding;
        public float _attackCooldown;
        /// <summary>
        /// Constructeur de la classe Enemy
        /// </summary>
        /// <param name="game"></param>
        /// <param name="StartPosition"></param>
        public Enemy(Game game, Vector2 StartPosition) : base()
        {
            Position = StartPosition;

            _game = game;
            TintColor = Color.White;
            Speed = 1;
            Health = 20;
            EntityManager.Add(this);
            Damage = 1;
            isColliding = false;
        }

        /// <summary>
        /// Methode qui initialise les textures et la hitbox
        /// </summary>
        public override void LoadContent()
        {
            EntityTexture = _game.Content.Load<Texture2D>("zombie");

            //la hitbox se place ou le zombie est
            Hitbox = new Rectangle((int)Position.X, (int)Position.Y, EntityTexture.Width, EntityTexture.Height);
        }

        /// <summary>
        /// Methode qui permet au zombie de se deplacer et de mettre a jour la hitbox
        /// </summary>
        /// <param name="gameTime"></param>
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
        /// <summary>
        /// Methode qui permet au zombie de prendre des degats
        /// </summary>
        /// <param name="Damage"></param>
        public void TakeDamage(int Damage)
        {
            Health -=Damage;
        }
    }
}
