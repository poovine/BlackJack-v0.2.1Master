using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace BlackJack {
    class ScreenManager {

        private static ScreenManager instance;

        public static ScreenManager Instance {
            get {
                if (instance == null) {
                    instance = new ScreenManager();
                }
                return instance;
            }           
        }

        private ContentManager content;
        private Texture2D tableTexture;
        public Vector2 tablePosition = Vector2.Zero;

        public ScreenManager() {
            this.content = new ContentManager(Game1.content.ServiceProvider, "Content");
        }

        public void LoadContent() {
            tableTexture = content.Load<Texture2D>("Textures\\BJTable");
        }

        public void UnloadContent() {

        }

        public void Update(GameTime gameTime) {

        }

        public void Draw(SpriteBatch spriteBatch) {
            switch (Game1.gameState) {
                case Game1.GameState.MainMenu:
                    break;
                case Game1.GameState.Game:
                    DrawGame(spriteBatch);
                    break;
                case Game1.GameState.SubMenu:
                    break;
            }
        }

        public void DrawMainMenu(SpriteBatch spriteBatch) {

        }

        public void DrawSubMenu(SpriteBatch spriteBatch) {

        }

        public void DrawGame(SpriteBatch spriteBatch) {
            DrawTable(spriteBatch);
            CardManager.Instance.Draw(spriteBatch);
            GameManager.Instance.Draw(spriteBatch);         
        }

        public void DrawTable(SpriteBatch spriteBatch) {
            spriteBatch.Draw(tableTexture, tablePosition, Color.White);
        }
    }

}
