using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Game1
{
    public class GameContent
    {
        public Texture2D playerTexture { get; set; }

        public GameContent(ContentManager Content)
        {
            //load images
            playerTexture = Content.Load<Texture2D>("player");
        }
    }
}