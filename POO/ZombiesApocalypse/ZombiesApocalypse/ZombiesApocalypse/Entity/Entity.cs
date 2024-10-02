using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace ZombiesApocalypse
{
    abstract class Entity
    {
        protected Texture2D EntityTexture;
        protected Color TintColor;
        protected Vector2 Velocity;
        protected int Speed;

        public bool Destroyed;
        public Rectangle Hitbox;
        public Vector2 Position;
        public int Health;

        private SpriteBatch _spriteBatch;

        public Entity()
        {
        }

        public abstract void LoadContent();
        public abstract void Update(GameTime time);

        public void Draw(SpriteBatch spriteBatch)
        {
            if (EntityTexture != null)
            {
                spriteBatch.Draw(EntityTexture, Position, null, TintColor);
            }
            else
            {
                Console.WriteLine("Entity texture is null!" + this.GetType());
            }
        }
    }


}