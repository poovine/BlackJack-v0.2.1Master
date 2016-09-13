using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BlackJack {
    class Card : Sprite {
        private int lowValue, highValue;
        private Suits suit;
        private string name, longName;
        private bool isShowing = false;
        
        public int LowValue { get { return lowValue; } set { lowValue = value; } }
        public int HighValue { get { return highValue; } set { highValue = value; } }
        public string Name { get { return name; } set { name = value; } }
        public string LongName { get { return longName; } set { longName = value; } }
        public Vector2 Position { get { return position; } set { position = value; } }
        public bool IsShowing { get { return isShowing; } set { isShowing = value; } }

        public enum Suits { Spades, Clubs, Hearts, Diamonds };

        public Card(Texture2D spriteTexture, Vector2 position, Rectangle maskRectangle,
                    int lowValue, int highValue, string name, string longName, Suits suit, Color color) : base (spriteTexture, position, maskRectangle) {

            this.lowValue = lowValue;
            this.highValue = highValue;
            this.name = name;
            this.longName = longName;
            this.suit = suit;                        
        }   

        public override void Update(GameTime gameTime) {             
        }

        public override void Draw(SpriteBatch spriteBatch) {
            if (isShowing == true) {
                spriteBatch.Draw(spriteTexture, position, sourceRectangle, Color.White);
            }
            else
                spriteBatch.Draw(spriteTexture, position, new Rectangle(76 * 13, 210, 71, 100), Color.White);
        }

    }
}

