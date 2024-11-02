using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ZombiesApocalypse
{
    public static class Text
    {
        private static SpriteFont _font;

        /// <summary>
        /// Methode qui initialise la typographie
        /// </summary>
        /// <param name="game"></param>
        public static void LoadContent(Game game)
        {
            _font = game.Content.Load<SpriteFont>("File");
        }
        /// <summary>
        /// Methode qui affiche le message de mort
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="text"></param>
        /// <param name="position"></param>
        public static void DrawLoseMessage(SpriteBatch spriteBatch, string text, Vector2 position)
        {
            Vector2 textSize = _font.MeasureString(text);
            Vector2 centeredPosition = position - textSize / 2;
            spriteBatch.DrawString(_font, text, centeredPosition, Color.White);
        }
        /// <summary>
        /// MEthode qui permet au niveau de s'afficher
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="text"></param>
        /// <param name="position"></param>
        public static void DrawLevelText(SpriteBatch spriteBatch, string text, Vector2 position)
        {
            Vector2 textSize = _font.MeasureString(text);
            Vector2 centeredPosition = position - textSize / 2;
            spriteBatch.DrawString(_font, text, centeredPosition, Color.Yellow);
        }
    }
}
