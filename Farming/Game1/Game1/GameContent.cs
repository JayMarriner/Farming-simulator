using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Game1
{
    public class GameContent
    {
        public Texture2D playerTexture { get; set; }
        public Texture2D mainMenuTexture { get; set; }
        public Texture2D optionTexture { get; set; }
        public Texture2D optionTexture2 { get; set; }

        public GameContent(ContentManager Content)
        {
            //load images
            playerTexture = Content.Load<Texture2D>("player");
            mainMenuTexture = Content.Load<Texture2D>("mainMenu");
            optionTexture = Content.Load<Texture2D>("option");
            optionTexture2 = Content.Load<Texture2D>("option2");
        }
    }
}