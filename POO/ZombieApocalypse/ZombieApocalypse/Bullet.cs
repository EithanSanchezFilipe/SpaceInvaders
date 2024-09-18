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
        public Vector2 _position;
        private int _screenHeight;
        private int _screenWidth;
        private int _characterTextureWidth;
        private int _characterTextureHeight;
        public Bullet(Game game, Vector2 Position, int characterTextureWidth, int characterTextureHeight) : base(game)
        {
            _position.X = Position.X;
            _position.Y = Position.Y;
            _characterTextureWidth = characterTextureWidth;
            _characterTextureHeight = characterTextureHeight;
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            texture = Game.Content.Load<Texture2D>("pistolBullet");
            _position.X += (_characterTextureWidth * 0.4f)/ 4 -3;
            _position.Y -= (_characterTextureHeight * 0.4f) / 2 + 15;
        }

        public override void Update(GameTime gameTime)
        {
            _position.Y -= 10;
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();
            _spriteBatch.Draw(texture, _position, null, Color.White, 0f, new Vector2(texture.Width / 2, texture.Height / 2), 1f, SpriteEffects.None, 0f);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
