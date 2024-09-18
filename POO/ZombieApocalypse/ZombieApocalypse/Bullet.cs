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
        public Bullet(Game game, Vector2 Position) : base(game)
        {
            _position.X = Position.X + 18;
            _position.Y = Position.Y - Position.Y /15;
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            texture = Game.Content.Load<Texture2D>("pistolBullet");
            texture2 = Game.Content.Load<Texture2D>("bloodSplatter");
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
