using Game1;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Farmer
{
    public class mainMenu
    {
        //Variables
        private SpriteBatch menuSpriteBatch;
        private Texture2D menuTexture;

        public mainMenu(SpriteBatch spriteBatch, GameContent gameContent)
        {
            menuSpriteBatch = spriteBatch;
            menuTexture = gameContent.mainMenuTexture;
        }

        public void Draw()
        {
            menuSpriteBatch.Draw(menuTexture, new Vector2(0, 0), null, Color.White, 0, new Vector2(0, 0), 1.0f, SpriteEffects.None, 0);
        }
    }
}
