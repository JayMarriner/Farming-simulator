using Game1;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Farmer
{
    public class menuOption
    {
        //Variables
        private SpriteBatch optionSpriteBatch;
        private Color optionColor;
        int optionX;
        int optionY;
        int optionHeight;
        int optionWidth;
        int optionSelector;
        Texture2D optionTexture;
        bool optionActive { get; set; }
        KeyboardState oldState;
        public bool clicked;
        public bool clicked2;

        public menuOption(SpriteBatch spriteBatch, GameContent gameContent, bool isActive, int x, int y, int selector)
        {
            optionSpriteBatch = spriteBatch;
            optionX = x;
            optionY = y;
            optionTexture = gameContent.optionTexture;
            optionHeight = optionTexture.Height;
            optionWidth = optionTexture.Width;
            optionActive = isActive;
            optionSelector = selector;
            if(selector == 2)
            {
                optionTexture = gameContent.optionTexture2;
            }
        }

        public void Draw()
        {
            if (optionActive)
            {
                optionColor = Color.White;
            }
            else
            {
                optionColor = Color.LightGreen;
            }

            optionSpriteBatch.Draw(optionTexture, new Vector2(optionX, optionY), null, optionColor, 0, new Vector2(0, 0), 1.0f, SpriteEffects.None, 0);
        }

        public void Update()
        {
            if (optionActive)
            {
                KeyboardState newState = Keyboard.GetState();
                if (optionSelector == 1 && oldState.IsKeyDown(Keys.Space) && newState.IsKeyUp(Keys.Space) || optionSelector == 1 && oldState.IsKeyDown(Keys.Enter) && newState.IsKeyUp(Keys.Enter))
                {
                    clicked = true;
                }
                if (optionSelector == 2 && oldState.IsKeyDown(Keys.Space) && newState.IsKeyUp(Keys.Space) || optionSelector == 2 && oldState.IsKeyDown(Keys.Enter) && newState.IsKeyUp(Keys.Enter))
                {
                    clicked2 = true;
                }
                if (oldState.IsKeyDown(Keys.D) && newState.IsKeyUp(Keys.D) || oldState.IsKeyDown(Keys.A) && newState.IsKeyUp(Keys.A))
                {
                    optionActive = false;
                }
                oldState = Keyboard.GetState();
            }
            else if (!optionActive)
            {
                KeyboardState newState = Keyboard.GetState();  // get the newest state
                if (oldState.IsKeyDown(Keys.D) && newState.IsKeyUp(Keys.D) || oldState.IsKeyDown(Keys.A) && newState.IsKeyUp(Keys.A))
                {
                    optionActive = true;
                }
                oldState = Keyboard.GetState();
            }
        }
    }
}
