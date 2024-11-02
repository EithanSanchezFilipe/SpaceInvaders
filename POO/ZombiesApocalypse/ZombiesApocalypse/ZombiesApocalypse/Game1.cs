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
        /// <summary>
        /// Constructeur de la classe Game
        /// </summary>
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = GlobalHelpers.SCREENWIDTH;
            _graphics.PreferredBackBufferHeight = GlobalHelpers.SCREENHEIGHT;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }
        /// <summary>
        /// Methode qui instancie les objets
        /// </summary>
        protected override void Initialize()
        {
            _player = new Player(this);
            _level = new Level(this);
            _limit = new Limit(this);

            base.Initialize();
        }
        /// <summary>
        /// Methode qui initialise les textures et typographies
        /// </summary>
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            EntityManager.LoadContent();
            Text.LoadContent(this);
        }
        /// <summary>
        /// Methode qui verifie si le jeu est en cours et actualise toutes les entites a chaque frame
        /// </summary>
        /// <param name="gameTime"></param>
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
        /// <summary>
        /// Methode qui mets tous les objets instanices a 0
        /// </summary>
        private void RestartGame()
        {
            // Remets les Variables a 0
            _player = new Player(this);
            _level = new Level(this);
            _limit = new Limit(this);
            _gameState = GameState.Playing;
        }
        /// <summary>
        /// Methode qui dessine tous ce qui est visuel en appelant les methodes draw de chaque entite
        /// </summary>
        /// <param name="gameTime"></param>
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
                // affiche le Message de mort
                string gameOverMessage = "Game Over! Press Enter to Restart";
                Text.DrawLoseMessage(_spriteBatch, gameOverMessage, new Vector2(GlobalHelpers.SCREENWIDTH / 2, GlobalHelpers.SCREENHEIGHT / 2));
            }

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }

}