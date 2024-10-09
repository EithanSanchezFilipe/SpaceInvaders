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
        public Bullet(Game game, Vector2 StartPosition, int bulletDamage) : base()
        {
            //position pour que la balle soit juste au dessus du pistolet et non en haut a gauche du personnage
            Position = StartPosition + new Vector2(48, -20); ;
            _game = game;
            TintColor = Color.White;
            Speed = 5;
            EntityManager.Add(this);
            Health = 1;
            BulletDamage = bulletDamage;
        }

        public override void LoadContent()
        {
            EntityTexture = _game.Content.Load<Texture2D>("pistolBullet");
            Hitbox = new Rectangle((int)Position.X, (int)Position.Y, EntityTexture.Width, EntityTexture.Height);
        }

        public override void Update(GameTime gameTime)
        {
            //Mouvement
            Velocity = new Vector2(0, -1);

            Velocity = Speed * Velocity;
            Position += Velocity;
            //Bouge la Hitbox en même temps que la balle
            Hitbox = new Rectangle((int)Position.X, (int)Position.Y, EntityTexture.Width, EntityTexture.Height);
        }
    }

}
