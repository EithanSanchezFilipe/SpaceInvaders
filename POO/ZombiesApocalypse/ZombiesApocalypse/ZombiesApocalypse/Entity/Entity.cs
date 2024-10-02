using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ZombiesApocalypse
{
    abstract class Entity
    {
        protected Texture EntityTexture;
        protected Color TintColor;

        public Vector2 Position;
        public Vector2 Velocity;
        public int Health;
    }
}
