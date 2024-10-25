using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ZombiesApocalypse
{
    public static class Text
    {
        private static SpriteFont _font;
        public static void LoadContent(Game game)
        {
            _font = game.Content.Load<SpriteFont>("File");
        }
        public static void Draw(SpriteBatch spriteBatch)
        {
            //affichage du niveau (les espaces sont la car sinon le mot level est mal affiché)
            spriteBatch.DrawString(_font, "Lev e l : " + Level.NumberLevel, new Vector2(30, 30), Color.White);
        }
    }
}
