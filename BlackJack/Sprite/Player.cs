using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BlackJack {
    class Player : GameCharacter {

        public int ChipCount { get; set; } = 100;
        public int BetAmount { get; set; } = 0;
        public int FinalBetAmount { get; set; }
        public bool IsStanding { get; set; }
        public bool PlacedBet { get; set; }
        public bool HasBusted { get; set; }
        public bool HasBlackJack { get; set; }
        public bool WonLastHand { get; set; }
        public bool HasBeenPaid { get; set; }
        public PlayerWinState playerWinState;               

        public enum PlayerWinState {
            Won,
            Lost,
            BlackJackWin,
            Push
            
        }
        public Player(Texture2D playerTexture, Vector2 position, Rectangle maskRectangle)
                        : base(playerTexture, position, maskRectangle) {           
        }

        public bool CanDoubleDown() {
            return ((this.CurrentHand.Count == 2) && (this.FinalBetAmount <= this.ChipCount) && !IsStanding);
        }

        //CANSPLIT NOT FULLY IMPLEMENTED!!!!
        public bool CanSplit() {
            return ((this.CurrentHand.Count == 2) && (this.CurrentHand[0].HighValue == this.CurrentHand[1].HighValue));
        }

        public bool CanHit() {
            return (!BlackJackHandler.IsBust(this) && !GameManager.Instance.PlayerManager.Player.IsStanding);
        }  

        public bool CanStand() {
            return (!BlackJackHandler.IsBust(this) && !GameManager.Instance.PlayerManager.Player.IsStanding);
        }      

        public override void Update(GameTime gameTime) {
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("ChipCount is: " + this.ChipCount);
            Console.WriteLine("Sub bet is: " + this.BetAmount);
            Console.WriteLine("FinalBet is: " + this.FinalBetAmount);
            Console.WriteLine("TotalHigh is: " + this.HighHandValue);
            Console.WriteLine("TotalLow is: " + this.LowHandValue);
            Console.WriteLine("FinalTotal is: " + this.FinalHandValue);
            Console.WriteLine("BlackJack? " + this.HasBlackJack);
            Console.WriteLine("Standing? " + this.IsStanding);
            Console.WriteLine("Busted? " + this.HasBusted);
            Console.WriteLine("HasBet? " + this.PlacedBet);
                   
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(this.spriteTexture, position, Color.White);
            DrawCurrentHand(spriteBatch);
            base.Draw(spriteBatch);
        }
    }
}
