using Game1;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Farmer
{
    public class Player
    {
        //Variables
        private int playerX { get; set; }
        private int playerY { get; set; }
        private int playerSpeed { get; set; }
        private int playerLevel { get; set; }
        private int playerCash { get; set; }
        private int playerHeight { get; set; }
        private int playerWidth { get; set; }
        private SpriteBatch playerSpriteBatch;
        private Texture2D playerTexture;
        private int newPosX = 250;
        private int newPosY = 250;

        public Player(int x, int y, SpriteBatch spriteBatch, GameContent gameContent, int speed, int level, int cash)
        {
            playerX = x;
            playerY = y;
            playerSpeed = speed;
            playerLevel = level;
            playerCash = cash;
            playerSpriteBatch = spriteBatch;
            playerTexture = gameContent.playerTexture;
            playerHeight = playerTexture.Height;
            playerWidth = playerTexture.Width;
        }

        public void Draw()
        {
            playerSpriteBatch.Draw(playerTexture, new Vector2(playerX, playerY), null, Color.White, 0, new Vector2(playerWidth, playerHeight), 1.0f, SpriteEffects.None, 0);
            playerSpriteBatch.Draw(Game1.Game1.BlankTexture(playerSpriteBatch), hitBox, Color.White);
            playerSpriteBatch.Draw(Game1.Game1.BlankTexture(playerSpriteBatch), newMove, Color.White);
        }

        public Rectangle hitBox => new Rectangle(playerX - playerWidth, playerY - playerHeight, playerWidth, playerHeight);
        public Rectangle newMove => new Rectangle(newPosX - playerWidth, newPosY - playerHeight, playerWidth, playerHeight);

        public void Update()
        {
            KeyboardState keyInput = Keyboard.GetState();
            if (keyInput.IsKeyDown(Keys.S))
            {
                newPosY = playerY + playerSpeed;
            }
            if (keyInput.IsKeyDown(Keys.W))
            {
                newPosY = playerY - playerSpeed;
            }
            if (keyInput.IsKeyDown(Keys.A))
            {
                newPosX = playerX - playerSpeed;
            }
            if (keyInput.IsKeyDown(Keys.D))
            {
                newPosX = playerX + playerSpeed;
            }
            if (newPosX >= 1920 || newPosX <= 0 + playerWidth || newPosY >= 1080 || newPosY <= 0 + playerHeight)
            {
                return;
            }
            else
            {
                playerY = newPosY;
                playerX = newPosX;
            }

        }
    }
}
