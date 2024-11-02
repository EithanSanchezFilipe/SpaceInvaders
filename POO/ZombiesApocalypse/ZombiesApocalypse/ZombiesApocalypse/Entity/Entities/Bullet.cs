using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using ZombiesApocalypse.Helpers;

namespace ZombiesApocalypse
{
    class Bullet : Entity
    {
        private Game _game;

        public int BulletDamage;
        /// <summary>
        /// Constructeur de la classe bullet
        /// </summary>
        /// <param name="game"></param>
        /// <param name="StartPosition"></param>
        /// <param name="bulletDamage"></param>
        public Bullet(Game game, Vector2 StartPosition, int bulletDamage) : base()
        {
            //position pour que la balle soit juste au dessus du pistolet et non en haut a gauche du personnage
            Position = StartPosition + new Vector2(48, -20);

            _game = game;
            TintColor = Color.White;
            Speed = 10;
            EntityManager.Add(this);
            Health = 1;
            BulletDamage = bulletDamage;
        }

        /// <summary>
        /// Methode qui initialise les textures et la hitbox de bullet
        /// </summary>
        public override void LoadContent()
        {
            EntityTexture = _game.Content.Load<Texture2D>("pistolBullet");
            Hitbox = new Rectangle((int)Position.X, (int)Position.Y, EntityTexture.Width, EntityTexture.Height);
        }

        /// <summary>
        /// Methode qui permet a la balle de se deplacer ainsi que la hitbox
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            //Mouvement
            Velocity = new Vector2(0, -1);
            Velocity = Speed * Velocity;
            Position += Velocity;

            //Bouge la Hitbox en même temps que la balle
            Hitbox = new Rectangle((int)Position.X, (int)Position.Y, EntityTexture.Width, EntityTexture.Height);

            if (Position.Y < 0)
                Destroyed = true;
        }
    }

}
