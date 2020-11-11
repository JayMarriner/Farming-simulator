using Game1;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Farmer
{
    public class Fence
    {
        //Variables
        private Texture2D fenceTexture;
        private int fenceX;
        private int fenceY;
        private bool isRotate;
        private float fenceRotate;
        private int fenceWidth;
        private int fenceHeight;

        public Fence(int x, int y, bool rotate, GameContent gameContent)
        {
            fenceTexture = gameContent.fenceTexture;
            fenceX = x;
            fenceY = y;
            fenceWidth = fenceTexture.Width;
            fenceHeight = fenceTexture.Height;
            isRotate = rotate;
            if (rotate)
            {
                fenceRotate = 2.00f;
                fenceRotate = (float)Math.PI / fenceRotate;
            }
            else
            {
                fenceRotate = 1.00f;
                fenceRotate = (float)Math.PI / fenceRotate;
            }
        }

        public void Draw(SpriteBatch s)
        {
            s.Draw(fenceTexture, new Vector2(fenceX, fenceY), null, Color.White, fenceRotate, new Vector2(fenceWidth / 2, fenceHeight / 2), 1.0f, SpriteEffects.None, 0);
            s.Draw(Game1.Game1.BlankTexture(s), hitBox, Color.White);
        }

        public Rectangle hitBox
        {
            get
            {
                if (isRotate)
                {
                    return new Rectangle(fenceX - fenceHeight / 2, fenceY - fenceWidth / 2, fenceHeight, fenceWidth);
                }
                else
                {
                    return new Rectangle(fenceX - fenceWidth / 2, fenceY - fenceHeight / 2, fenceWidth, fenceHeight);
                }
            }
        }

    }
}
