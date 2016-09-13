using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BlackJack {
    class Dealer : GameCharacter {

        public bool IsStanding { get; set; }
        public bool HasBlackJack { get; set; }
        public bool HasBusted { get; set; }


        public Dealer(Texture2D playerTexture, Vector2 position, Rectangle maskRectangle)
                        : base(playerTexture, position, maskRectangle) {

        }

        public override void Update(GameTime gameTime) {
            Console.WriteLine("DealerStanding? " + this.IsStanding);
            Console.WriteLine("DealerBusted? " + this.HasBusted); 
            Console.WriteLine("DealerHighTotal is: " + this.HighHandValue);
            Console.WriteLine("DealerLowTotal is: " + this.LowHandValue);
            Console.WriteLine("DealerBlackJack? " + this.HasBlackJack);

            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(spriteTexture, position, Color.White);
            DrawCurrentHand(spriteBatch);
            base.Draw(spriteBatch);
        }

        public void DealCards(params Player[] players) {
            Player player = players[0];
            DealCardToPlayer(player);
            RemoveLastCardFromDeck();
            DealCardToDealer(false);
            RemoveLastCardFromDeck();
            DealCardToPlayer(player);
            RemoveLastCardFromDeck();
            DealCardToDealer();
            RemoveLastCardFromDeck();
        }

        public void Hit(GameCharacter gameCharacter) {
            if (gameCharacter is Player) {
                DealCardToPlayer(gameCharacter as Player);
                RemoveLastCardFromDeck();
            }
            else {
                DealCardToDealer();
                RemoveLastCardFromDeck();
            }
        }

        private void RemoveLastCardFromDeck() {
            CardManager.Instance.Deck.RemoveAt(CardManager.Instance.Deck.Count - 1);
        }

        private void DealCardToPlayer(Player player, bool cardShowing = true) {
            var nextCard = CardManager.Instance.Deck[CardManager.Instance.Deck.Count - 1];
            nextCard.IsShowing = cardShowing;
            player.CurrentHand.Add(nextCard);
        }

        private void DealCardToDealer(bool cardShowing = true) {
            var nextCard = CardManager.Instance.Deck[CardManager.Instance.Deck.Count - 1];
            nextCard.IsShowing = cardShowing;
            this.CurrentHand.Add(nextCard);
        }
    }
}

