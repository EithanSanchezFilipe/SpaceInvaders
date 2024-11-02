using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using ZombiesApocalypse.Helpers;
namespace ZombiesApocalypse
{
    class Limit : Entity
    {
        private Game _game;
        /// <summary>
        /// Constructeur de la classe Limit
        /// </summary>
        /// <param name="game"></param>
        public Limit(Game game) : base()
        {
            _game = game;
            TintColor = Color.White;
            Health = 5;
            EntityManager.Add(this);
        }
        /// <summary>
        /// Methode qui initialise les textures et la hitbox de limit
        /// </summary>
        public override void LoadContent()
        {
            EntityTexture = _game.Content.Load<Texture2D>("LimitWire");

            //Position et hitbox définies après car sinon la texture n'est pas définie
            Position = new Vector2(0, GlobalHelpers.SCREENHEIGHT / (float)1.3);

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
