using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ZombiesApocalypse.Helpers;
using System.Collections.Generic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace ZombiesApocalypse
{
    public enum GameState
    {
        Playing,
        GameOver
    }

    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Player _player;
        private Level _level;
        private Limit _limit;
        public static GameState _gameState;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = GlobalHelpers.SCREENWIDTH;
            _graphics.PreferredBackBufferHeight = GlobalHelpers.SCREENHEIGHT;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _player = new Player(this);
            _level = new Level(this);
            _limit = new Limit(this);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            EntityManager.LoadContent();
            Text.LoadContent(this);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            switch (_gameState)
            {
                case GameState.Playing:
                    EntityManager.Update(gameTime, _level);
                    _level.Update(gameTime);
                    if (_player.Health <= 0)
                    {
                        _gameState = GameState.GameOver;
                    }
                    break;

                case GameState.GameOver:
                    if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                    {
                        RestartGame();
                    }
                    break;
            }
            base.Update(gameTime);
        }
        private void RestartGame()
        {
            // Reset game state and objects
            _player = new Player(this);
            _level = new Level(this);
            _limit = new Limit(this);
            _gameState = GameState.Playing; // Back to playing state
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();

            if (_gameState == GameState.Playing)
            {
                _level.Draw(_spriteBatch);
                EntityManager.Draw(_spriteBatch);
            }
            else if (_gameState == GameState.GameOver)
            {
                // Show a game over message
                string gameOverMessage = "Game Over! Press Enter to Restart";
                Text.DrawLoseMessage(_spriteBatch, gameOverMessage, new Vector2(GlobalHelpers.SCREENWIDTH / 2, GlobalHelpers.SCREENHEIGHT / 2));
            }

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }

}