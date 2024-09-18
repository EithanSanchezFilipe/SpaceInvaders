using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace ZombieApocalypse
{
    public class Zombie : DrawableGameComponent
    {
        private Texture2D texture;
        private Texture2D texture2;
        private SpriteBatch _spriteBatch;
        public Vector2 _position;
        private int[] _spawnX = { 95, 220, 330, 440, 550 };
        private int[] _spawnY = { -100, -260, -300, -350, -170, -420 };
        public bool isDespawning = false;
        private float _opacity = 1f;
        private float _opacityRate = 0.5f;
        public bool IsDead { get; private set; } = false;

        public Zombie(Game game) : base(game)
        {
            int spawnXIndex = GlobalHelpers.RandomNumber(0, _spawnX.Length);
            int spawnYIndex = GlobalHelpers.RandomNumber(0, _spawnY.Length);
            _position = new Vector2(_spawnX[spawnXIndex], _spawnY[spawnYIndex]);
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
            if (!(_position.Y == (GlobalHelpers.screenHeight - GlobalHelpers.screenHeight / 5)) && !isDespawning)
                _position.Y += 1;
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
                _spriteBatch.Draw(texture, _position, null, Color.White, 0f, new Vector2(texture.Width / 2, texture.Height / 2), 0.4f, SpriteEffects.None, 0f);
            else
                _spriteBatch.Draw(texture2, _position, null, colorWithOpacity, 0f, new Vector2(texture.Width / 2, texture.Height / 2), 0.4f, SpriteEffects.None, 0f);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}