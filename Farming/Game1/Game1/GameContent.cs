using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Game1
{
    public class GameContent
    {
        public Texture2D playerTexture { get; set; }
        public Texture2D playerLeft { get; set; }
        public Texture2D playerRight { get; set; }
        public Texture2D playerUp { get; set; }
        public Texture2D mainMenuTexture { get; set; }
        public Texture2D optionTexture { get; set; }
        public Texture2D optionTexture2 { get; set; }
        public Texture2D levelTexture { get; set; }
        public Texture2D fenceTexture { get; set; }
        public Texture2D shopBackground { get; set; }
        public Texture2D shop { get; set; }
        public Texture2D interact { get; set; }
        public Texture2D shopMenu { get; set; }

        public GameContent(ContentManager Content)
        {
            //load images
            playerTexture = Content.Load<Texture2D>("player");
            playerLeft = Content.Load<Texture2D>("playerLeft");
            playerRight = Content.Load<Texture2D>("playerRight");
            playerUp = Content.Load<Texture2D>("playerUp");
            mainMenuTexture = Content.Load<Texture2D>("mainMenu");
            optionTexture = Content.Load<Texture2D>("option");
            optionTexture2 = Content.Load<Texture2D>("option2");
            levelTexture = Content.Load<Texture2D>("level1");
            fenceTexture = Content.Load<Texture2D>("fence");
            shopBackground = Content.Load<Texture2D>("shopBackground");
            shop = Content.Load<Texture2D>("shop");
            interact = Content.Load<Texture2D>("interact");
            shopMenu = Content.Load<Texture2D>("shopMenu");
        }
    }
}