using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using System.Collections.Generic;
using System;

namespace BlackJack {
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Song song;

        public static ContentManager content;
        public static Random random = new Random();
        /**********************************
        Temp Variables 
        ***********************************/



        //Texture2D buttonBox;


        /**********************************
        Temp Variables
        ***********************************/
        public static int screenWidth = 1280;
        public static int screenHeight = 720;
        public static GameState gameState;

        public enum GameState {
            MainMenu,
            Game,
            SubMenu
        }

        public Game1() {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            content = Content;
        }

        protected override void Initialize() {
            graphics.PreferredBackBufferWidth = screenWidth;
            graphics.PreferredBackBufferHeight = screenHeight;
            IsMouseVisible = true;
            gameState = GameState.Game;
            GameManager.Instance.LoadContent();
            ScreenManager.Instance.LoadContent();
            InputManager.Instance.LoadContent();
            base.Initialize();
        }

        protected override void LoadContent() {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            song = Content.Load<Song>("Songs\\BlackJackMusic");
            MediaPlayer.Play(song);
        }

        protected override void UnloadContent() {

        }

        protected override void Update(GameTime gameTime) {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            switch (gameState) {
                case GameState.MainMenu:
                    break;
                case GameState.Game:
                    InputManager.Instance.Update(gameTime);
                    GameManager.Instance.Update(gameTime);
                    ScreenManager.Instance.Update(gameTime);
                    break;
                case GameState.SubMenu:
                    break;
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            ScreenManager.Instance.Draw(spriteBatch); 
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
