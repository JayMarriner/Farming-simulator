using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Farmer;
using System;
using System.Collections.Generic;

namespace Game1
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        SpriteBatch spriteBatch;
        GraphicsDeviceManager graphics;
        GameContent gameContent;
        private int screenWidth;
        private int screenHeight;
        //Objects
        public Player player;
        public mainMenu mainmenu;
        public List<Images> images = new List<Images>();
        public List<menuOption> options = new List<menuOption>();
        public List<Fence> fences = new List<Fence>();
        public List<Shop> shops = new List<Shop>();
        //Game states to switch between menus and playing.
        public enum GameStates
        {
            Menu,
            Playing,
            Paused,
        }
        public GameStates activeState;
        public bool isPlaying;
        private static Texture2D _blankTexture;
        public static Texture2D BlankTexture(SpriteBatch s)
        {
            if (_blankTexture == null)
            {
                _blankTexture = new Texture2D(s.GraphicsDevice, 1, 1);
                //_blankTexture.SetData(new[] { Color.Red });
            }
            return _blankTexture;
        }

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
            activeState = GameStates.Menu;
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            gameContent = new GameContent(Content);
            screenWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            screenHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            if(screenWidth >= 1920)
            {
                screenWidth = 1920;
            }
            if(screenHeight >= 1080)
            {
                screenHeight = 1080;
            }
            graphics.PreferredBackBufferWidth = screenWidth;
            graphics.PreferredBackBufferHeight = screenHeight;
            //graphics.IsFullScreen = true;
            graphics.ApplyChanges();

            if (activeState == GameStates.Menu)
            {
                mainmenu = new mainMenu(spriteBatch, gameContent);
                options.Add(new menuOption(spriteBatch, gameContent, true, 400, 400, 1));
                options.Add(new menuOption(spriteBatch, gameContent, false, 1110, 400, 2));
            }
            if (activeState == GameStates.Playing)
            {
                //Fences
                fences.Add(new Fence(125, 50, false, gameContent));
                fences.Add(new Fence(350, 50, false, gameContent));
                fences.Add(new Fence(575, 50, false, gameContent));
                fences.Add(new Fence(688, 163, true, gameContent));
                fences.Add(new Fence(688, 390, true, gameContent));
                fences.Add(new Fence(688, 390, true, gameContent));
                fences.Add(new Fence(688, 617, true, gameContent));

                fences.Add(new Fence(125, 300, false, gameContent));
                fences.Add(new Fence(343, 300, false, gameContent));
                fences.Add(new Fence(457, 413, true, gameContent));
                fences.Add(new Fence(457, 620, true, gameContent));
                player = new Player(200, 200, spriteBatch, gameContent, 3, 1, 0);
                images.Add(new Images(gameContent,0,0,1));
                images.Add(new Images(gameContent,2,315,2));
                images.Add(new Images(gameContent, 710, 925, 3));
                images.Add(new Images(gameContent, 510, 190, 4));
                shops.Add(new Shop(95, 315, gameContent));
            }
            if (activeState == GameStates.Paused)
            {
                //Stuff
            }
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            if (activeState == GameStates.Menu)
            {
                options.ForEach(x => x.Update());
                foreach(menuOption option in options)
                {
                    if (option.clicked)
                    {
                        activeState = GameStates.Playing;
                        LoadContent();
                    }
                    if (option.clicked2)
                    {
                        Exit();
                    }
                }
            }
            if (activeState == GameStates.Playing)
            {
                player.Update();
                player.fenceUpdate(fences);
                player.shopUpdate(shops);
                player.move(); //keep this at bottom of player updates to ensure collision.

                images.ForEach(x => x.interactUpdate(player));
                images.ForEach(x => x.shopOpen(shops));

                shops.ForEach(x => x.interactUpdate(player));

                //if(shops.ForEach(x=> x.shopState == true){}
            }
            if (activeState == GameStates.Paused)
            {
                //Stuff
            }
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            // TODO: Add your drawing code here
            spriteBatch.Begin();
            if (activeState == GameStates.Menu)
            {
                mainmenu.Draw();
                options.ForEach(x => x.Draw());
            }
            if(activeState == GameStates.Playing)
            {
                images.ForEach(x => x.Draw(spriteBatch));
                player.Draw();
                fences.ForEach(x => x.Draw(spriteBatch));
                shops.ForEach(x => x.Draw(spriteBatch));
                images.ForEach(x => x.overlayDraw(spriteBatch));
            }
            if(activeState == GameStates.Paused)
            {
                //Stuff
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
