using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct2D1;
using System;
using System.Reflection.Metadata;
using ZombiesApocalypse.Helpers;
using SpriteBatch = Microsoft.Xna.Framework.Graphics.SpriteBatch;

namespace ZombiesApocalypse
{
    class Player : Entity
    {
        private Game _game;
        private float _bulletCooldown;
        private bool _specialAttack;
        private float _specialAttackCooldown;
        private float _fenceCooldown;
        private int _damage;
        private Texture2D[] Lifes = new Texture2D[5];

        public static int NumberOfFences;
        public Player(Game game) : base()
        {
            _game = game;
            TintColor = Color.White;
            Speed = 5;
            Health = 25;
            EntityManager.Add(this);
            _damage = 7;
            NumberOfFences = 0;
        }

        public override void LoadContent()
        {
            EntityTexture = _game.Content.Load<Texture2D>("soldat pistolet");
            for (int i = 0; i < Lifes.Length; i++)
            {
                Lifes[i] = _game.Content.Load<Texture2D>($"Life{i + 1}");
            }

            //Position du joueur declarer ici car la taille de la texture est defini juste au dessus
            Position = new Vector2(GlobalHelpers.SCREENWIDTH / 2 - EntityTexture.Width / 2, 800);
        }

        public override void Update(GameTime gameTime)
        {
            //Mouvement
            Velocity = Vector2.Zero;

            if (InputHelper.GetKeyStatus().IsKeyDown(Keys.A))
                Velocity = new Vector2(-1, 0);
            if (InputHelper.GetKeyStatus().IsKeyDown(Keys.D))
                Velocity = new Vector2(1, 0);

            Velocity = Speed * Velocity;
            Position += Velocity;

            Position = Vector2.Clamp(Position, new Vector2(0, Position.Y), new Vector2(GlobalHelpers.SCREENWIDTH - EntityTexture.Width, Position.Y));

            //Attaque
            _bulletCooldown -= (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (InputHelper.GetKeyStatus().IsKeyDown(Keys.Space) && _bulletCooldown <= 0)
            {
                new Bullet(_game, Position, _damage);
                if (!_specialAttack)
                {
                    _bulletCooldown = GlobalHelpers.PISTOLCOOLDOWN;
                    _damage = 7;
                }
                else
                {
                    _bulletCooldown = GlobalHelpers.RIFLECOOLDOWN;
                    _damage = 10;
                }
            }

            //Changement de type d'attaque
            _specialAttackCooldown -= (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (InputHelper.GetKeyStatus().IsKeyDown(Keys.X) && _specialAttackCooldown <= 0)
            {
                _specialAttack = !_specialAttack;
                if(_specialAttack)
                    EntityTexture = _game.Content.Load<Texture2D>("soldat ak");
                else
                    EntityTexture = _game.Content.Load<Texture2D>("soldat pistolet");
                _specialAttackCooldown = GlobalHelpers.ATTACKCHANGECOOLDOWN;
            }

            _fenceCooldown -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (InputHelper.GetKeyStatus().IsKeyDown(Keys.F) && NumberOfFences != 2 && _fenceCooldown <= 0)
            {
                NumberOfFences++;
                new Fence(_game, Position);
                _fenceCooldown = GlobalHelpers.FENCECOOLDOWN;
            }

        }
        public new void Draw(SpriteBatch spriteBatch)
        {
            if (!Destroyed)
            {
                Console.WriteLine(Health);
                if (Health == 25)
                    spriteBatch.Draw(Lifes[4], new Vector2(GlobalHelpers.SCREENWIDTH / 2 - Lifes[0].Width / 2 , 50), null, TintColor);
                if (Health == 20)
                    spriteBatch.Draw(Lifes[0], new Vector2(GlobalHelpers.SCREENWIDTH / 2 - Lifes[0].Width / 2, 50), null, TintColor);
                if (Health == 15)
                    spriteBatch.Draw(Lifes[1], new Vector2(GlobalHelpers.SCREENWIDTH / 2 - Lifes[0].Width / 2, 50), null, TintColor);
                if (Health == 10)
                    spriteBatch.Draw(Lifes[2], new Vector2(GlobalHelpers.SCREENWIDTH / 2 - Lifes[0].Width / 2, 50), null, TintColor);
                if (Health == 5)
                    spriteBatch.Draw(Lifes[3], new Vector2(GlobalHelpers.SCREENWIDTH / 2 - Lifes[0].Width / 2, 50), null, TintColor);
            }
        }
    }
}
