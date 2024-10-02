using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ZombiesApocalypse
{
    abstract class Entity
    {
        protected Texture2D EntityTexture;
        protected Color TintColor;

        public Vector2 Position;
        public Vector2 Velocity;
        public int Health;

        private SpriteBatch _spriteBatch;


        public void Draw()
        {
            if (EntityTexture != null)
                _spriteBatch.Draw(EntityTexture, Position, null, TintColor);
        }
    }
}
