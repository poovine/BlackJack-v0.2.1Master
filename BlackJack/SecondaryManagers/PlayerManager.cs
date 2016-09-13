using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace BlackJack {
    class PlayerManager {
        public Player Player { get; private set; }
        public Dealer Dealer { get; private set; }

        private Texture2D playerTexture, dealerTexture;
        private Vector2 playerPosition = new Vector2(600, 650);
        private Vector2 dealerPosition = new Vector2(600, 0);

        private ContentManager content = new ContentManager(Game1.content.ServiceProvider, "Content");


        public void LoadContent() {
            InitializePlayers();
        }

        public void Update(GameTime gameTime) {
            Player.Update(gameTime);
            Dealer.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch) {
            DrawGameCharacters(spriteBatch);
        }

        public void DrawGameCharacters(SpriteBatch spriteBatch) {
            Player.Draw(spriteBatch);
            Dealer.Draw(spriteBatch);
        }

        public void InitializePlayers() {
            playerTexture = content.Load<Texture2D>("Textures\\player");
            dealerTexture = content.Load<Texture2D>("Textures\\dealer");
            Player = new Player(playerTexture, playerPosition, new Rectangle(0, 0, playerTexture.Width, playerTexture.Height));
            Dealer = new Dealer(dealerTexture, dealerPosition, new Rectangle(0, 0, dealerTexture.Width, dealerTexture.Height));
        }

        public void ClearHands() {
            Player.CurrentHand.Clear();
            Dealer.CurrentHand.Clear();
        }

        public void ClearPlayerDealerValues() {
            Player.PlacedBet = false;
            Player.IsStanding = false;
            Dealer.IsStanding = false;
            Player.HasBusted = false;
            Dealer.HasBusted = false;
            Player.HasBlackJack = false;
            Dealer.HasBlackJack = false;
            Player.HasBeenPaid = false;           
        }
  
    }
}
