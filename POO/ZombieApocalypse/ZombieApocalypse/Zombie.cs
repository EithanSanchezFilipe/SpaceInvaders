using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using ZombieApocalypse.Helpers;

namespace ZombieApocalypse
{
    public class Zombie : DrawableGameComponent
    {
        public Texture2D texture;
        private Texture2D texture2;
        private SpriteBatch _spriteBatch;
        public Vector2 Position { get; private set; }
        public bool isDespawning = false;
        private float _opacity = 1f;
        private float _opacityRate = 0.5f;
        public bool IsDead { get; private set; } = false;

        public Zombie(Game game, Vector2 position) : base(game)
        {
            Position = position;
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            texture = Game.Content.Load<Texture2D>("zombie");
            texture2 = Game.Content.Load<Texture2D>("bloodSplatter");
        }

        public override void Update(GameTime gameTime)
        {
            
            base.Update(gameTime);
            if (!(Position.Y == (GlobalHelpers.screenHeight - GlobalHelpers.screenHeight / 5)) && !isDespawning)
                Position = new Vector2(Position.X, Position.Y + 1);
            else
                isDespawning = true;

            if(isDespawning == true)
            {
                _opacity -= _opacityRate * (float)gameTime.ElapsedGameTime.TotalSeconds;
                _opacity = MathHelper.Clamp(_opacity, 0f, 1f);
                if (_opacity <= 0)
                    IsDead = true;
            }
        }

        public override void Draw(GameTime gameTime)
        {
            Color colorWithOpacity = new Color(1f, 1f, 1f, _opacity);
            _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);

            if(!isDespawning)
                _spriteBatch.Draw(texture, Position, null, Color.White, 0f, new Vector2(texture.Width / 2, texture.Height / 2), 0.4f, SpriteEffects.None, 0f);
            else
                _spriteBatch.Draw(texture2, Position, null, colorWithOpacity, 0f, new Vector2(texture.Width / 2, texture.Height / 2), 0.4f, SpriteEffects.None, 0f);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}