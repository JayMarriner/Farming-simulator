using Game1;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

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
        private Texture2D playerUp;
        private Texture2D playerLeft;
        private Texture2D playerRight;
        private int playerFacing = 3;
        private int newPosX = 250;
        private int newPosY = 250;
        private bool objHit;
        public bool interactZone;

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
            playerUp = gameContent.playerUp;
            playerLeft = gameContent.playerLeft;
            playerRight = gameContent.playerRight;
        }

        public void Draw()
        {
            switch (playerFacing)
            {
                case 1:
                    playerSpriteBatch.Draw(playerTexture, new Vector2(playerX, playerY), null, Color.White, 0, new Vector2(playerWidth, playerHeight), 1.0f, SpriteEffects.None, 0);
                    break;
                case 2:
                    playerSpriteBatch.Draw(playerUp, new Vector2(playerX, playerY), null, Color.White, 0, new Vector2(playerWidth, playerHeight), 1.0f, SpriteEffects.None, 0);
                    break;
                case 3:
                    playerSpriteBatch.Draw(playerLeft, new Vector2(playerX, playerY), null, Color.White, 0, new Vector2(playerWidth, playerHeight), 1.0f, SpriteEffects.None, 0);
                    break;
                case 4:
                    playerSpriteBatch.Draw(playerRight, new Vector2(playerX, playerY), null, Color.White, 0, new Vector2(playerWidth, playerHeight), 1.0f, SpriteEffects.None, 0);
                    break;
            }
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
                playerFacing = 1;
            }
            if (keyInput.IsKeyDown(Keys.W))
            {
                newPosY = playerY - playerSpeed;
                playerFacing = 2;
            }
            if (keyInput.IsKeyDown(Keys.A))
            {
                newPosX = playerX - playerSpeed;
                playerFacing = 3;
            }
            if (keyInput.IsKeyDown(Keys.D))
            {
                newPosX = playerX + playerSpeed;
                playerFacing = 4;
            }
            if(newPosX > playerX && keyInput.IsKeyDown(Keys.RightShift) || newPosX > playerX && keyInput.IsKeyDown(Keys.LeftShift))
            {
                newPosX += 3;
            }
            if (newPosX < playerX && keyInput.IsKeyDown(Keys.RightShift) || newPosX < playerX && keyInput.IsKeyDown(Keys.LeftShift))
            {
                newPosX -= 3;
            }
            if (newPosY > playerY && keyInput.IsKeyDown(Keys.RightShift) || newPosY > playerY && keyInput.IsKeyDown(Keys.LeftShift))
            {
                newPosY += 3;
            }
            if (newPosY < playerY && keyInput.IsKeyDown(Keys.RightShift) || newPosY < playerY && keyInput.IsKeyDown(Keys.LeftShift))
            {
                newPosY -= 3;
            }
            if (newPosX >= 1920 || newPosX <= 0 + playerWidth || newPosY >= 1080 || newPosY <= 0 + playerHeight)
            {
                objHit = true;
            }
        }

        public void fenceUpdate(List<Fence> fences)
        {
            foreach (Fence fence in fences)
            {
                if (this.newMove.Intersects(fence.hitBox))
                {
                    objHit = true;
                }
            }
        }

        public void shopUpdate(List<Shop> shops)
        {
            foreach (Shop shop in shops)
            {
                if (this.newMove.Intersects(shop.hitBox))
                {
                    objHit = true;
                }

                if (this.hitBox.Intersects(shop.interactionZone))
                {
                    interactZone = true;
                }
                else
                {
                    interactZone = false;
                }
            }
        }

        public void move()
        {
            if (objHit)
            {
                newPosY = playerY;
                newPosX = playerX;
                objHit = false;
            }
            else
            {
                playerY = newPosY;
                playerX = newPosX;
            }
        }
    }
}
