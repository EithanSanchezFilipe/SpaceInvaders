using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using ZombiesApocalypse.Helpers;
namespace ZombiesApocalypse
{
    class Fence : Entity
    {
        private Game _game;
        /// <summary>
        /// Constructeur de la classe Fence
        /// </summary>
        /// <param name="game"></param>
        /// <param name="PlayerPosition"></param>
        public Fence(Game game , Vector2 PlayerPosition) : base()
        {
            _game = game;
            TintColor = Color.White;
            Health = 10;
            Position = new Vector2(PlayerPosition.X, GlobalHelpers.SCREENHEIGHT/2);
            EntityManager.Add(this);
        }

        /// <summary>
        /// Methode qui initialise les textures et la hitbox de Fence
        /// </summary>
        public override void LoadContent()
        {
            EntityTexture = _game.Content.Load<Texture2D>("Fence");
            Hitbox = new Rectangle((int)Position.X, (int)Position.Y, EntityTexture.Width, EntityTexture.Height);
        }

        public override void Update(GameTime gameTime)
        {

        }
        /// <summary>
        /// Methode qui permet au zombie de prendre des degats
        /// </summary>
        /// <param name="Damage"></param>
        public void takeDamage(int Damage)
        {
            Health -= Damage;
        }
    }
}
