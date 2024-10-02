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

        public Vector2 Position;
        public int Health;

        private SpriteBatch _spriteBatch;

        public Entity(GraphicsDevice graphicsDevice)
        {
            Position = new Vector2(50, 100);
            TintColor = Color.White;
            _spriteBatch = new SpriteBatch(graphicsDevice);
        }

        public abstract void LoadContent();
        public abstract void Update(GameTime time);

        public void Draw()
        {
            if (EntityTexture != null)
            {
                _spriteBatch.Begin();
                _spriteBatch.Draw(EntityTexture, Position, null, TintColor);
                _spriteBatch.End();
                Console.WriteLine("Entity drawn");
            }
            else
            {
                Console.WriteLine("Entity texture is null!");
            }
        }
    }


}