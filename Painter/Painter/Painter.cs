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

namespace Painter
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Painter : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        InputHelper inputHelper;
        static Random random;
        static Point screen;

        static public GameWorld gameWorld;

        static public GameWorld GameWorld { get { return gameWorld; } }
        static public Random Random { get { return random; } }
        static public Point Screen { get { return screen; } }

        public Painter() 
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            inputHelper = new InputHelper();
            IsMouseVisible = true;
            random = new Random();
        }

        /// <summary>
        /// ------------------------------------------------------------------------------INIT--------------------------------------------------------------------------
        /// </summary>
        protected override void Initialize()
        {
            

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
            gameWorld = new GameWorld(this.Content);
            inputHelper = new InputHelper();
            screen = new Point(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Play(Content.Load<Song>("snd_music"));
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }




        /// ------------------------------------------------------------------------------UPDATE--------------------------------------------------------------------------
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            inputHelper.Update();
            gameWorld.HandleInput(inputHelper);
            gameWorld.Update(gameTime); 

            base.Update(gameTime);
        }





        /// -------------------------------------------------------------------------------DRAW--------------------------------------------------------------------------
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            gameWorld.Draw(gameTime, spriteBatch);

            base.Draw(gameTime);
        }
    }
}
