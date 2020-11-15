using Game1;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Farmer
{
    public class Images
    {
        //Variables
        private Texture2D bgTexture;
        private Texture2D shopTexture;
        private Texture2D interactTexture;
        private Texture2D shopMenuTexture;
        private int imageX;
        private int imageY;
        private int imageType;
        private bool interactShow;
        private bool shopMenuShow;

        public Images(GameContent gameContent, int X, int Y, int type)
        {
            bgTexture = gameContent.levelTexture;
            shopTexture = gameContent.shopBackground;
            interactTexture = gameContent.interact;
            shopMenuTexture = gameContent.shopMenu;
            imageX = X;
            imageY = Y;
            imageType = type;
        }

        public void Draw(SpriteBatch s)
        {
            if(imageType == 1)
            {
                s.Draw(bgTexture, new Vector2(imageX, imageY), null, Color.White, 0, new Vector2(0, 0), 1.0f, SpriteEffects.None, 0);
            }
            else if(imageType == 2)
            {
                s.Draw(shopTexture, new Vector2(imageX, imageY), null, Color.White, 0, new Vector2(0, 0), 1.00f, SpriteEffects.None, 0);
            }
        }

        public void overlayDraw(SpriteBatch s)
        {
            if (imageType == 3)
            {
                if (interactShow)
                {
                    s.Draw(interactTexture, new Vector2(imageX, imageY), null, Color.White, 0, new Vector2(0, 0), 1.0f, SpriteEffects.None, 0);
                }
            }
            else if (imageType == 4)
            {
                if (shopMenuShow)
                {
                    s.Draw(shopMenuTexture, new Vector2(imageX, imageY), null, Color.White, 0, new Vector2(0, 0), 1.0f, SpriteEffects.None, 0);
                }
            }
        }

        public void shopOpen(List<Shop> shops)
        {
            foreach (Shop shop in shops)
            {
                Console.WriteLine("shop found.");
                if (shop.shopPlayerInteract)
                {
                    interactShow = true;
                }
                else
                {
                    interactShow = false;
                }
                if (shop.shopState)
                {
                    shopMenuShow = true;
                }
                else
                {
                    shopMenuShow = false;
                }
            }
            Console.WriteLine("End");
        }
    }
}
