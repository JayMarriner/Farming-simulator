using Game1;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

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
            playerSpriteBatch.Begin();
            playerSpriteBatch.Draw(playerTexture, new Vector2(playerX, playerY), null, Color.White, 0, new Vector2(playerWidth, playerHeight), 1.0f, SpriteEffects.None, 0);
            playerSpriteBatch.End();
        }
    }
}
