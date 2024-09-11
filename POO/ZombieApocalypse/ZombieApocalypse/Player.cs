﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace ZombieApocalypse
{
    public class Player : DrawableGameComponent
    {
        private Texture2D normalTexture;            //Déclaration d'une variable pour la texture de mon personnage en attaque normale
        private Texture2D specialTexture;            //Déclaration d'une variable pour la texture de mon personnage en attaque normale
        private float _playerSpeed;                 //Déclaration d'une variable pour la vitesse de mon personnage
        private SpriteBatch _spriteBatch;           //Déclaration d'une variable qui dessine le personnage
        private Vector2 _position;                  //Déclaration d'une variable qui va stocker la position x et y de mon personnage
        private int _screenHeight;                  //Déclaration d'une variable qui va stocker la hauteur de l'ecran
        private int _screenWidth;                   //Déclaration d'une variable qui va stocker l'epaisseur de l'ecran
        private bool _specialAttack = false;
        private float _attackChangeDelay = 0.5f; // Durée en secondes avant de pouvoir changer d'attaque
        private float _timeSinceLastChange = 0f;
        public Vector2 Position { get => _position; set => _position = value; }

        //Constructeur de la classe Player
        public Player(Game game, int screenWidth, int screenHeight) : base(game)
        {
            _screenWidth = screenWidth;
            _screenHeight = screenHeight;
            _position = new Vector2(screenWidth / 2, screenHeight - 55);
            _playerSpeed = 250f;
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
            float updated_soldatSpeed = _playerSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            var kstate = Keyboard.GetState();
            _timeSinceLastChange += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (kstate.IsKeyDown(Keys.D))
            {
                if ((_position.X + normalTexture.Width / 5) < _screenWidth)
                    _position.X += updated_soldatSpeed;
            }

            if (kstate.IsKeyDown(Keys.A))
            {
                if ((_position.X - normalTexture.Width / 5) > 0)
                    _position.X -= updated_soldatSpeed;
            }
            if (kstate.IsKeyDown(Keys.X) && _timeSinceLastChange >= _attackChangeDelay)
            {
                _specialAttack = !_specialAttack;
                _timeSinceLastChange = 0f;
            }
            base.Update(gameTime);
        }

        //Methode qui se dessine chaque frame
        public override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();
            if(_specialAttack)
                _spriteBatch.Draw(specialTexture, _position, null, Color.White, 0f, new Vector2(specialTexture.Width / 2, specialTexture.Height / 2), 0.4f, SpriteEffects.None, 0f);
            else
                _spriteBatch.Draw(normalTexture, _position, null, Color.White, 0f, new Vector2(normalTexture.Width / 2, normalTexture.Height / 2), 0.4f, SpriteEffects.None, 0f);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}