using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace ZombieApocalypse
{
    public class Zombie : DrawableGameComponent
    {
        private Texture2D texture;
        private float _zombieSpeed;
        private SpriteBatch _spriteBatch;
        private Vector2 _position;
        private int _screenHeight;
        private int _screenWidth;
        private int[] _spawnX = { 95, 220, 330, 440, 550 };
        private int[] _spawnY = { -100, -260, -300,-350,-170, -420};
        private Player _player;
        public Zombie(Game game, int screenWidth, int screenHeight, Player player) : base(game)
        {
            Random rnd1 = new Random();
            Random rnd2 = new Random();
            int spawnXIndex = rnd1.Next(0, _spawnX.Length);
            int spawnYIndex = rnd2.Next(0, _spawnY.Length);
            _screenWidth = screenWidth;
            _screenHeight = screenHeight;
            _position = new Vector2(_spawnX[spawnXIndex], _spawnY[spawnYIndex]);
            _zombieSpeed = 250f;
            _player = player;
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            texture = Game.Content.Load<Texture2D>("zombie");
        }

        public override void Update(GameTime gameTime)
        {
            float updated_zombieSpeed = _zombieSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            base.Update(gameTime);
            
            if (!(((_position.Y + texture.Height / 2) - 10) == _player.Position.Y) && !(_position.X))
            {
                _position.Y += 1;
            }
        }

        public override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();
            _spriteBatch.Draw(texture, _position, null, Color.White, 0f, new Vector2(texture.Width / 2, texture.Height / 2), 0.4f, SpriteEffects.None, 0f);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}