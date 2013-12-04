using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using xTile;
using xTile.Display;
using xTile.Tiles;

namespace PizzaGuy
{


    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D PacmanSheet;
        Texture2D PacmanFrames;
        Texture2D breakout;
        PizzaGuy pacman;
        Map map;
        IDisplayDevice mapDisplayDevice;
        Tile tile;
        xTile.Dimensions.Rectangle viewport;
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
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            PacmanSheet = Content.Load<Texture2D>("PacmanSprites");
            
            mapDisplayDevice = new XnaDisplayDevice(Content, GraphicsDevice);
            map = Content.Load<xTile.Map>("PacmanMap");
            map.LoadTileSheets(mapDisplayDevice);
            viewport = new xTile.Dimensions.Rectangle(0, 0, 800, 480);
            breakout = Content.Load<Texture2D>("breakout");
            PacmanFrames = Content.Load<Texture2D>("PacmanFrames");

            pacman = new PizzaGuy(new Vector2(352, 352), PacmanFrames, new Rectangle(70, 4, 28, 28), new Vector2(32, 0), map.GetLayer("untitled layer"));
            pacman.AddFrame(new Rectangle(1, 4, 28, 28));
            pacman.AddFrame(new Rectangle(0, 7, 28, 28));
            pacman.AddFrame(new Rectangle(36, 4, 28, 28));

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
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
        /// 

        //game window is 800 x 480

        

      

        //private void HandleKeyboardInput(KeyboardState keyState)
        //{
        //    if (keyState.IsKeyDown(Keys.Up))
        //    {
        //        // direction
        //        pacman.direction = Direction.UP;
        //    }

        //    else if(keyState.IsKeyDown(Keys.Down))
        //    {
        //        pacman.direction = Direction.DOWN;
        //    }

        //    else if (keyState.IsKeyDown(Keys.Left))
        //    {
        //        pacman.direction = Direction.LEFT;
        //    }

        //    else if (keyState.IsKeyDown(Keys.Right))
        //    {
        //        pacman.direction = Direction.RIGHT;
        //    }





            


        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here
            //HandleKeyboardInput(Keyboard.GetState());
            pacman.Update(gameTime);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            map.Draw(mapDisplayDevice, viewport);
            // TODO: Add your drawing code here
            spriteBatch.Begin();
            pacman.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
            
        }
    }
}
