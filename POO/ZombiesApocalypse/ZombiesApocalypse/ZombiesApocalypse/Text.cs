using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

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
            spriteBatch.DrawString(_font, "Lev e l : " + Level.NumberLevel, new Vector2(30, 30), Color.White);
        }

        public static void DrawLevelText(SpriteBatch spriteBatch, string text, Vector2 position)
        {
            Vector2 textSize = _font.MeasureString(text);
            Vector2 centeredPosition = position - textSize / 2;
            spriteBatch.DrawString(_font, text, centeredPosition, Color.Yellow);
        }

        public static void DrawLoseMessage(SpriteBatch spriteBatch, string text, Vector2 position)
        {
            Vector2 textSize = _font.MeasureString(text);
            Vector2 centeredPosition = position - textSize / 2;
            spriteBatch.DrawString(_font, text, centeredPosition, Color.White);
        }
    }
}
