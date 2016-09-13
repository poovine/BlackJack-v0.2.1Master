using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace BlackJack {
    class CardManager {

        private static CardManager instance;

        public static CardManager Instance {
            get {
                if (instance == null) {
                    instance = new CardManager();
                }
                return instance;
            }
        }

        private static Vector2 startingDeckPosition = new Vector2(1150, 150);

        private Texture2D cardSpriteSheet;        
        private ContentManager content;

        public List<Card> Deck { get; private set; }            

        public CardManager() {
            this.content = new ContentManager(Game1.content.ServiceProvider, "Content");
        }

        public void LoadContent() {
            cardSpriteSheet = content.Load<Texture2D>("Textures\\playingCards");
            Deck = CreateDeck(cardSpriteSheet);
        }

        public void UnLoadContent() {

        }

        public void Update(GameTime gameTime) {

        }

        public void Draw(SpriteBatch spriteBatch) {
            DrawDeck(spriteBatch);
        }

        public void DrawDeck(SpriteBatch spriteBatch) {
            foreach (Card c in Deck) {                
                c.Draw(spriteBatch);
            }
        }
        #region Create/Shuffle/Arrage Deck
        public static List<Card> CreateDeck(Texture2D playingCardTexture) {
            var unshuffled = new List<Card>();
            for (int i = 0; i < 6; i++) {
                unshuffled.Add(new Card(playingCardTexture, startingDeckPosition, new Rectangle(0, 0, 71, 100), 1, 11, "AS", "Ace of Spades", Card.Suits.Spades, Color.Black));
                unshuffled.Add(new Card(playingCardTexture, startingDeckPosition, new Rectangle(76, 0, 71, 100), 2, 2, "2S", "Two of Spades", Card.Suits.Spades, Color.Black));
                unshuffled.Add(new Card(playingCardTexture, startingDeckPosition, new Rectangle(76 * 2, 0, 71, 100), 3, 3, "3S", "Three of Spades", Card.Suits.Spades, Color.Black));
                unshuffled.Add(new Card(playingCardTexture, startingDeckPosition, new Rectangle(76 * 3, 0, 71, 100), 4, 4, "4S", "Four of Spades", Card.Suits.Spades, Color.Black));
                unshuffled.Add(new Card(playingCardTexture, startingDeckPosition, new Rectangle(76 * 4, 0, 71, 100), 5, 5, "5S", "Five of Spades", Card.Suits.Spades, Color.Black));
                unshuffled.Add(new Card(playingCardTexture, startingDeckPosition, new Rectangle(76 * 5, 0, 71, 100), 6, 6, "6S", "Six of Spades", Card.Suits.Spades, Color.Black));
                unshuffled.Add(new Card(playingCardTexture, startingDeckPosition, new Rectangle(76 * 6, 0, 71, 100), 7, 7, "7S", "Seven of Spades", Card.Suits.Spades, Color.Black));
                unshuffled.Add(new Card(playingCardTexture, startingDeckPosition, new Rectangle(76 * 7, 0, 71, 100), 8, 8, "8S", "Eight of Spades", Card.Suits.Spades, Color.Black));
                unshuffled.Add(new Card(playingCardTexture, startingDeckPosition, new Rectangle(76 * 8, 0, 71, 100), 9, 9, "9S", "Nine of Spades", Card.Suits.Spades, Color.Black));
                unshuffled.Add(new Card(playingCardTexture, startingDeckPosition, new Rectangle(76 * 9, 0, 71, 100), 10, 10, "10S", "Ten of Spades", Card.Suits.Spades, Color.Black));
                unshuffled.Add(new Card(playingCardTexture, startingDeckPosition, new Rectangle(76 * 10, 0, 71, 100), 10, 10, "JS", "Jack of Spades", Card.Suits.Spades, Color.Black));
                unshuffled.Add(new Card(playingCardTexture, startingDeckPosition, new Rectangle(76 * 11, 0, 71, 100), 10, 10, "QS", "Queen of Spades", Card.Suits.Spades, Color.Black));
                unshuffled.Add(new Card(playingCardTexture, startingDeckPosition, new Rectangle(76 * 12, 0, 71, 100), 10, 10, "KS", "King of Spades", Card.Suits.Spades, Color.Black));
                unshuffled.Add(new Card(playingCardTexture, startingDeckPosition, new Rectangle(0, 105, 71, 100), 1, 11, "AC", "Ace of Clubs", Card.Suits.Clubs, Color.Black));
                unshuffled.Add(new Card(playingCardTexture, startingDeckPosition, new Rectangle(76, 105, 71, 100), 2, 2, "2C", "Two of Clubs", Card.Suits.Clubs, Color.Black));
                unshuffled.Add(new Card(playingCardTexture, startingDeckPosition, new Rectangle(76 * 2, 105, 71, 100), 3, 3, "3C", "Three of Clubs", Card.Suits.Clubs, Color.Black));
                unshuffled.Add(new Card(playingCardTexture, startingDeckPosition, new Rectangle(76 * 3, 105, 71, 100), 4, 4, "4C", "Four of Clubs", Card.Suits.Clubs, Color.Black));
                unshuffled.Add(new Card(playingCardTexture, startingDeckPosition, new Rectangle(76 * 4, 105, 71, 100), 5, 5, "5C", "Five of Clubs", Card.Suits.Clubs, Color.Black));
                unshuffled.Add(new Card(playingCardTexture, startingDeckPosition, new Rectangle(76 * 5, 105, 71, 100), 6, 6, "6C", "Six of Clubs", Card.Suits.Clubs, Color.Black));
                unshuffled.Add(new Card(playingCardTexture, startingDeckPosition, new Rectangle(76 * 6, 105, 71, 100), 7, 7, "7C", "Seven of Clubs", Card.Suits.Clubs, Color.Black));
                unshuffled.Add(new Card(playingCardTexture, startingDeckPosition, new Rectangle(76 * 7, 105, 71, 100), 8, 8, "8C", "Eight of Clubs", Card.Suits.Clubs, Color.Black));
                unshuffled.Add(new Card(playingCardTexture, startingDeckPosition, new Rectangle(76 * 8, 105, 71, 100), 9, 9, "9C", "Nine of Clubs", Card.Suits.Clubs, Color.Black));
                unshuffled.Add(new Card(playingCardTexture, startingDeckPosition, new Rectangle(76 * 9, 105, 71, 100), 10, 10, "10C", "Ten of Clubs", Card.Suits.Clubs, Color.Black));
                unshuffled.Add(new Card(playingCardTexture, startingDeckPosition, new Rectangle(76 * 10, 105, 71, 100), 10, 10, "JC", "Jack of Clubs", Card.Suits.Clubs, Color.Black));
                unshuffled.Add(new Card(playingCardTexture, startingDeckPosition, new Rectangle(76 * 11, 105, 71, 100), 10, 10, "QC", "Queen of Clubs", Card.Suits.Clubs, Color.Black));
                unshuffled.Add(new Card(playingCardTexture, startingDeckPosition, new Rectangle(76 * 12, 105, 71, 100), 10, 10, "KC", "King of Clubs", Card.Suits.Clubs, Color.Black));
                unshuffled.Add(new Card(playingCardTexture, startingDeckPosition, new Rectangle(0, 210, 71, 100), 1, 11, "AH", "Ace of Hearts", Card.Suits.Hearts, Color.Red));
                unshuffled.Add(new Card(playingCardTexture, startingDeckPosition, new Rectangle(76, 210, 71, 100), 2, 2, "2H", "Two of Hearts", Card.Suits.Hearts, Color.Red));
                unshuffled.Add(new Card(playingCardTexture, startingDeckPosition, new Rectangle(76 * 2, 210, 71, 100), 3, 3, "3H", "Three of Hearts", Card.Suits.Hearts, Color.Red));
                unshuffled.Add(new Card(playingCardTexture, startingDeckPosition, new Rectangle(76 * 3, 210, 71, 100), 4, 4, "4H", "Four of Hearts", Card.Suits.Hearts, Color.Red));
                unshuffled.Add(new Card(playingCardTexture, startingDeckPosition, new Rectangle(76 * 4, 210, 71, 100), 5, 5, "5H", "Five of Hearts", Card.Suits.Hearts, Color.Red));
                unshuffled.Add(new Card(playingCardTexture, startingDeckPosition, new Rectangle(76 * 5, 210, 71, 100), 6, 6, "6H", "Six of Hearts", Card.Suits.Hearts, Color.Red));
                unshuffled.Add(new Card(playingCardTexture, startingDeckPosition, new Rectangle(76 * 6, 210, 71, 100), 7, 7, "7H", "Seven of Hearts", Card.Suits.Hearts, Color.Red));
                unshuffled.Add(new Card(playingCardTexture, startingDeckPosition, new Rectangle(76 * 7, 210, 71, 100), 8, 8, "8H", "Eight of Hearts", Card.Suits.Hearts, Color.Red));
                unshuffled.Add(new Card(playingCardTexture, startingDeckPosition, new Rectangle(76 * 8, 210, 71, 100), 9, 9, "9H", "Nine of Hearts", Card.Suits.Hearts, Color.Red));
                unshuffled.Add(new Card(playingCardTexture, startingDeckPosition, new Rectangle(76 * 9, 210, 71, 100), 10, 10, "10H", "Ten of Hearts", Card.Suits.Hearts, Color.Red));
                unshuffled.Add(new Card(playingCardTexture, startingDeckPosition, new Rectangle(76 * 10, 210, 71, 100), 10, 10, "JH", "Jack of Hearts", Card.Suits.Hearts, Color.Red));
                unshuffled.Add(new Card(playingCardTexture, startingDeckPosition, new Rectangle(76 * 11, 210, 71, 100), 10, 10, "QH", "Queen of Hearts", Card.Suits.Hearts, Color.Red));
                unshuffled.Add(new Card(playingCardTexture, startingDeckPosition, new Rectangle(76 * 12, 210, 71, 100), 10, 10, "KH", "King of Hearts", Card.Suits.Hearts, Color.Red));
                unshuffled.Add(new Card(playingCardTexture, startingDeckPosition, new Rectangle(0, 315, 71, 100), 1, 11, "AD", "Ace of Diamonds", Card.Suits.Diamonds, Color.Red));
                unshuffled.Add(new Card(playingCardTexture, startingDeckPosition, new Rectangle(76, 315, 71, 100), 2, 2, "2D", "Two of Diamonds", Card.Suits.Diamonds, Color.Red));
                unshuffled.Add(new Card(playingCardTexture, startingDeckPosition, new Rectangle(76 * 2, 315, 71, 100), 3, 3, "3D", "Three of Diamonds", Card.Suits.Diamonds, Color.Red));
                unshuffled.Add(new Card(playingCardTexture, startingDeckPosition, new Rectangle(76 * 3, 315, 71, 100), 4, 4, "4D", "Four of Diamonds", Card.Suits.Diamonds, Color.Red));
                unshuffled.Add(new Card(playingCardTexture, startingDeckPosition, new Rectangle(76 * 4, 315, 71, 100), 5, 5, "5D", "Five of Diamonds", Card.Suits.Diamonds, Color.Red));
                unshuffled.Add(new Card(playingCardTexture, startingDeckPosition, new Rectangle(76 * 5, 315, 71, 100), 6, 6, "6D", "Six of Diamonds", Card.Suits.Diamonds, Color.Red));
                unshuffled.Add(new Card(playingCardTexture, startingDeckPosition, new Rectangle(76 * 6, 315, 71, 100), 7, 7, "7D", "Seven of Diamonds", Card.Suits.Diamonds, Color.Red));
                unshuffled.Add(new Card(playingCardTexture, startingDeckPosition, new Rectangle(76 * 7, 315, 71, 100), 8, 8, "8D", "Eight of Diamonds", Card.Suits.Diamonds, Color.Red));
                unshuffled.Add(new Card(playingCardTexture, startingDeckPosition, new Rectangle(76 * 8, 315, 71, 100), 9, 9, "9D", "Nine of Diamonds", Card.Suits.Diamonds, Color.Red));
                unshuffled.Add(new Card(playingCardTexture, startingDeckPosition, new Rectangle(76 * 9, 315, 71, 100), 10, 10, "10D", "Ten of Diamonds", Card.Suits.Diamonds, Color.Red));
                unshuffled.Add(new Card(playingCardTexture, startingDeckPosition, new Rectangle(76 * 10, 315, 71, 100), 10, 10, "JD", "Jack of Diamonds", Card.Suits.Diamonds, Color.Red));
                unshuffled.Add(new Card(playingCardTexture, startingDeckPosition, new Rectangle(76 * 11, 315, 71, 100), 10, 10, "QD", "Queen of Diamonds", Card.Suits.Diamonds, Color.Red));
                unshuffled.Add(new Card(playingCardTexture, startingDeckPosition, new Rectangle(76 * 12, 315, 71, 100), 10, 10, "KD", "King of Diamonds", Card.Suits.Diamonds, Color.Red));
            }
            return ArrangeDeck(Shuffle(unshuffled));
        }

        private static List<Card> ArrangeDeck(List<Card> cardList) {
            Vector2 tempPos = cardList.First().Position;
            foreach (Card c in cardList) {
                tempPos += Vector2.UnitY;
                c.Position = tempPos;
            }
            return cardList;
        }

        private static List<Card> Shuffle(List<Card> unshuffledDeck) {
            Card[] array = unshuffledDeck.ToArray();
            int n = array.Length;
            for (int i = 0; i < n; i++) {
                int r = i + (int)(Game1.random.NextDouble() * (n - i));
                Card t = array[r];
                array[r] = array[i];
                array[i] = t;
            }
            return new List<Card>(array);
        }
        #endregion
    }
}










