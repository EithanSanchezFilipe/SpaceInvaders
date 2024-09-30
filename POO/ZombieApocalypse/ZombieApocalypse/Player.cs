using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;
using ZombieApocalypse.Helpers;

namespace ZombieApocalypse
{
    public class Player : DrawableGameComponent
    {
        public int Health;
        private Texture2D normalTexture;            //Déclaration d'une variable pour la texture de mon personnage en attaque normale
        private Texture2D specialTexture;            //Déclaration d'une variable pour la texture de mon personnage en attaque normale
        private SpriteBatch _spriteBatch;           //Déclaration d'une variable qui dessine le personnage
        public Vector2 Position { get; private set; } //Déclaration d'une variable qui va stocker la position x et y de mon personnage
        private bool _specialAttack = false;
        private float _attackChangeCooldown = 0.5f; // Durée en secondes avant de pouvoir changer d'attaque
        private float _timeSinceLastChange = 0f;
        private float _pistolBulletCooldown = 0.3f; // Durée en secondes avant de pouvoir changer d'attaque
        private float _timeSinceLastBullet = 0f;
        private Game _mainGame;
        private GameComponentCollection _Components;
        public List<Bullet> Bullets { get; private set; } = new List<Bullet>();

        //Constructeur de la classe Player
        public Player(Game game, GameComponentCollection Components) : base(game)
        {
            Position = new Vector2(GlobalHelpers.screenWidth / 2, GlobalHelpers.screenHeight - 55);
            _Components = Components;
            _mainGame = game;
            Health = GlobalHelpers.RandomNumber(14, 21);
        }

        //Method qui charge les images(ne l'affiche pas)
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            normalTexture = Game.Content.Load<Texture2D>("soldat pistolet");
            specialTexture = Game.Content.Load<Texture2D>("soldat ak");
        }

        //Methode qui se relance chaque frame
        public override void Update(GameTime gameTime)
        {
            float soldatSpeed = 250f * (float)gameTime.ElapsedGameTime.TotalSeconds;
            _timeSinceLastChange += (float)gameTime.ElapsedGameTime.TotalSeconds;
            _timeSinceLastBullet += (float)gameTime.ElapsedGameTime.TotalSeconds;

            KeyboardState keyState = Keyboard.GetState();

            Vector2 direction = InputHelpers.GetPlayerDirection(keyState);

            if (!CollisionHelpers.IsOutOfBounds(Position, direction, normalTexture.Width))
                Position += direction * soldatSpeed;

            InputHelpers.CheckForPlayerAction(keyState, _timeSinceLastBullet, _pistolBulletCooldown, _timeSinceLastChange, _attackChangeCooldown, this);
            
            base.Update(gameTime);
        }

        //Methode qui se dessine chaque frame
        public override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();
            if (_specialAttack)
                _spriteBatch.Draw(specialTexture, Position, null, Color.White, 0f, new Vector2(specialTexture.Width / 2, specialTexture.Height / 2), 0.4f, SpriteEffects.None, 0f);
            else
                _spriteBatch.Draw(normalTexture, Position, null, Color.White, 0f, new Vector2(normalTexture.Width / 2, normalTexture.Height / 2), 0.4f, SpriteEffects.None, 0f);
            _spriteBatch.End();
            base.Draw(gameTime);
        }

        public void NewBullet()
        {
            Bullet bullet = new Bullet(_mainGame, Position, normalTexture.Width, specialTexture.Height);
            Bullets.Add(bullet);
            _Components.Add(bullet);
            _timeSinceLastBullet = 0f;
        }
        public void ChangeAttackType()
        {
            _specialAttack = !_specialAttack;
            _timeSinceLastChange = 0f;
        }
    }
}