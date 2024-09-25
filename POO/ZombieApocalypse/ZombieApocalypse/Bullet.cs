using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
namespace ZombieApocalypse
{
    public class Bullet : DrawableGameComponent
    {
        private Texture2D texture;
        private Texture2D texture2;
        private SpriteBatch _spriteBatch;
        private int _characterTextureWidth;
        private int _characterTextureHeight;
        public bool IsRemoved;
        public Vector2 Position { get; private set; }
        public Bullet(Game game, Vector2 position, int characterTextureWidth, int characterTextureHeight) : base(game)
        {
            Position = position;
            _characterTextureWidth = characterTextureWidth;
            _characterTextureHeight = characterTextureHeight;
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            texture = Game.Content.Load<Texture2D>("pistolBullet");
            Position = new Vector2(Position.X + (_characterTextureWidth * 0.4f) / 2 - 20, Position.Y - (_characterTextureHeight * 0.4f) / 2 - 10);
        }

        public override void Update(GameTime gameTime)
        {
            Position = new Vector2(Position.X, Position.Y - 10);
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();
            _spriteBatch.Draw(texture, Position, null, Color.White, 0f, new Vector2(texture.Width / 2, texture.Height / 2), 1f, SpriteEffects.None, 0f);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
