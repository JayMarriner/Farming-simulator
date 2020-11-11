using Game1;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Threading;

namespace Farmer
{
    public class Shop
    {
        //Variables
        private Texture2D shopTexture;
        private int shopX;
        private int shopY;
        KeyboardState oldState;
        private bool openShop;

        public Shop(int x, int y, GameContent gameContent)
        {
            shopTexture = gameContent.shop;
            shopX = x;
            shopY = y;
        }

        public bool shopState
        {
            get
            {
                return openShop;
            }
        }

        public void Draw(SpriteBatch s)
        {
            s.Draw(shopTexture, new Vector2(shopX, shopY), null, Color.White, 0, new Vector2(0, 0), 1.0f, SpriteEffects.None, 0);
            s.Draw(Game1.Game1.BlankTexture(s), hitBox, Color.White);
            s.Draw(Game1.Game1.BlankTexture(s), interactionZone, Color.White);
        }

        public Rectangle hitBox => new Rectangle(shopX, shopY, shopTexture.Width, shopTexture.Height);
        public Rectangle interactionZone => new Rectangle(shopX, shopY, shopTexture.Width, shopTexture.Height + 50);

        public void interactUpdate(Player player)
        {
            if (player.interactZone)
            {
                KeyboardState newState = Keyboard.GetState();
                if (newState.IsKeyDown(Keys.E) && oldState.IsKeyUp(Keys.E) && openShop == true)
                {
                    openShop = false;
                }
                else if (newState.IsKeyDown(Keys.E) && oldState.IsKeyUp(Keys.E) && openShop == false)
                {
                    openShop = true;
                }
                oldState = newState;  
            }
        }

    }
}
