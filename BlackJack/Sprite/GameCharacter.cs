using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace BlackJack {
    class GameCharacter : Sprite {

        protected List<Card> currentHand = new List<Card>();
        protected List<Vector2> currentHandCardPositions = new List<Vector2>();
        protected string Name { get; set; }
        protected int lowHandValue, highHandValue, finalHandValue;
        //protected bool isStanding;

        public List<Card> CurrentHand { get { return currentHand; } }

        public int FinalHandValue { get { GetFinalHandValue(); return finalHandValue; } }

        public int LowHandValue {
            get {
                if (currentHand != null) { GetHandValues(); }
                return lowHandValue;
            }
        }

        public int HighHandValue {
            get {
                if (currentHand != null) { GetHandValues(); }
                return highHandValue;
            }
        }

        private int[] handValues = new int[2];

        public GameCharacter(Texture2D characterTexture, Vector2 position, Rectangle maskRectangle)
                             : base(characterTexture, position, maskRectangle) {

        }

        public override void Update(GameTime gameTime) {
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch) {
            base.Draw(spriteBatch);
        }

        protected void DrawCurrentHand(SpriteBatch spriteBatch) {
            int spacing = 60;
            //if Player draw at y = 400, else draw the Dealear at 175;
            int yLocation = (typeof(Player) == this.GetType()) ? 400 : 175;
            if (currentHand != null) {
                for (int i = 0; i < currentHand.Count; i++) {
                    //change position later
                    currentHand[i].Position = new Vector2(365 + spacing * i, yLocation);
                    currentHand[i].Draw(spriteBatch);
                }
            }
        }

        protected void GetHandValues() {
            int totalLow = 0;
            int totalHigh = 0;
            foreach (Card c in currentHand) {
                totalLow += c.LowValue;
                totalHigh += c.HighValue;
            }
            lowHandValue = totalLow;
            highHandValue = totalHigh;
        }

        protected void GetFinalHandValue() {
            if (lowHandValue <= 21 && highHandValue > 21)
                finalHandValue = lowHandValue;
            if (lowHandValue <= 21 && highHandValue <= 21)
                finalHandValue = Math.Max(lowHandValue, highHandValue);
            if (lowHandValue > 21 && highHandValue > 21)
                finalHandValue = 0;
        }
    }
}
