using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

using Microsoft.Xna.Framework.Input;

namespace BlackJack {

    class GameManager {
        private static GameManager instance;

        public static GameManager Instance {
            get {
                if (instance == null) {
                    instance = new GameManager();
                }
                return instance;
            }
        }

        public enum GamePlayState {
            InitializeState,
            PlaceBets, //pre cards dealt phase...place bets...once bet placed...state changes to deal cards...only bet buttons active...hit/stand are not
            DealCards, //dealer and player have 2 cards each...check for blackjack...if no blackjack go to player action...if blackjack then get winner           
            PlayerAction, //player able to use hit/stand buttons...bet buttons turned off...after every hit check for bust...
            //hit until bust then go to GetWinner, hit until stand then go to DealerAction, DoubleDown (effectively 1 hit then stand)...if hit causes bust, Get winner,
            //if hit doesnt cause bust go to dealer action...split...create 2 hands...repeat player actions on one hand and then the other...stand, go to dealer Action.
            DealerAction, //go through dealer AI...if dealer hit, check for bust each time....if bust ever go to get winner...if dealer stand...go to get winner.../all buttons deactivated at this point.
            GetWinner//check winner logic...transfer won or lost chips. clear the table of cards...back to place bets
        }

        public ButtonManager ButtonManager { get { return buttonManager; } private set { } }
        public CommandManager CommandManager { get { return commandManager; } private set { } }
        public PlayerManager PlayerManager { get { return playerManager; } private set { } }

        private ButtonManager buttonManager;
        private CommandManager commandManager;
        private PlayerManager playerManager;
        private ContentManager content;

        private Player player;
        private Dealer dealer;
        private bool cardsDealt = false;
        private SpriteFont font;

        public GamePlayState gamePlayState = GamePlayState.PlaceBets;

        public static int SubBet;

        public GameManager() {
            this.content = new ContentManager(Game1.content.ServiceProvider, "Content");
            CardManager.Instance.LoadContent();
            commandManager = new CommandManager();
            playerManager = new PlayerManager();
            buttonManager = new ButtonManager();
        }

        public void LoadContent() {
            PlayerManager.LoadContent();
            ButtonManager.LoadContent();
            font = content.Load<SpriteFont>("Fonts\\font");
            player = playerManager.Player;
            dealer = playerManager.Dealer;

            /******** Test Area *******/
  

            /******Test Area ********/
        }

        public void UnLoadContent() {

        }

        public void Update(GameTime gameTime) {
            CardManager.Instance.Update(gameTime);
            PlayerManager.Update(gameTime);
            ButtonManager.Update(gameTime);

           

            /****/

            switch (gamePlayState) {
                case GamePlayState.InitializeState: {
                        PlayerManager.ClearHands();
                        PlayerManager.ClearPlayerDealerValues();
                        cardsDealt = false;
                        gamePlayState = GamePlayState.PlaceBets;
                        break;
                    }
                case GamePlayState.PlaceBets:
                    if (playerManager.Player.PlacedBet) {
                        gamePlayState = GamePlayState.DealCards;
                    }
                    break;
                case GamePlayState.DealCards:
                    if (cardsDealt == false) {
                        playerManager.Dealer.DealCards(playerManager.Player);
                        cardsDealt = true;
                    }
                    if (BlackJackHandler.IsBlackJack(player) && !BlackJackHandler.IsBlackJack(dealer)) {
                        player.HasBlackJack = true;
                        dealer.HasBlackJack = false;
                        gamePlayState = GamePlayState.GetWinner;
                    }
                    else if (BlackJackHandler.IsBlackJack(dealer)) {
                        dealer.HasBlackJack = true;
                        player.HasBlackJack = false;
                        gamePlayState = GamePlayState.GetWinner;
                    }
                    else {
                        dealer.HasBlackJack = false;
                        player.HasBlackJack = false;
                        gamePlayState = GamePlayState.PlayerAction;
                    }
                    break;
                case GamePlayState.PlayerAction:
                    if (BlackJackHandler.IsBust(player)) {
                        player.HasBusted = true;
                        gamePlayState = GamePlayState.GetWinner;
                    }
                    if (player.IsStanding) {
                        gamePlayState = GamePlayState.DealerAction;
                    }
                    break;
                case GamePlayState.DealerAction:
                    if (BlackJackHandler.IsBust(dealer)) {
                        dealer.HasBusted = true;
                        gamePlayState = GamePlayState.GetWinner;
                    }
                    else if (!dealer.IsStanding && !dealer.HasBusted) {
                        BlackJackHandler.DealerSelfAIAction();
                    }
                    else
                        gamePlayState = GamePlayState.GetWinner;
                    break;
                case GamePlayState.GetWinner:
                    int winValue = BlackJackHandler.CheckWinner(dealer, player);                    
                    if (winValue == 1 && !player.HasBeenPaid) {
                        player.ChipCount += player.FinalBetAmount * 2;
                        player.HasBeenPaid = true;
                        player.playerWinState = Player.PlayerWinState.Won;
                    }
                    else if (winValue == 0) {
                        player.playerWinState = Player.PlayerWinState.Lost;
                    }

                    else if (winValue == 2 && !player.HasBeenPaid) {
                        player.ChipCount += player.FinalBetAmount + (int)(player.FinalBetAmount * 1.5f);
                        player.HasBeenPaid = true;
                        player.playerWinState = Player.PlayerWinState.BlackJackWin;
                    }

                    else if (winValue == -1 && !player.HasBeenPaid) {
                        player.ChipCount += player.FinalBetAmount;
                        player.HasBeenPaid = true;
                        player.playerWinState = Player.PlayerWinState.Push;
                    }

                    if (Mouse.GetState().RightButton == ButtonState.Pressed)
                        gamePlayState = GamePlayState.InitializeState;
                    break;
            }





            /*****/


        }

       

        public void Draw(SpriteBatch spriteBatch) {
            PlayerManager.Draw(spriteBatch);
            ButtonManager.Draw(spriteBatch);
            DrawFonts(spriteBatch);
        }

        public void DrawFonts(SpriteBatch spriteBatch) {
            spriteBatch.DrawString(font, "Player High Hand Value?: " + player.HighHandValue, new Vector2(800, 425), Color.Black);
            spriteBatch.DrawString(font, "Player Low Hand Value?: " + player.LowHandValue, new Vector2(800, 450), Color.Black);
            spriteBatch.DrawString(font, "Player Final Hand Value?: " + player.FinalHandValue, new Vector2(800, 475), Color.Black);
            spriteBatch.DrawString(font, "Player Chips: " + player.ChipCount.ToString(), new Vector2(800, 500), Color.Black);
            spriteBatch.DrawString(font, "Player win state: " + player.playerWinState, new Vector2(200,550), Color.Black);
            spriteBatch.DrawString(font, "Player Final Bet Amount?: " + player.FinalBetAmount, new Vector2(200, 525), Color.Black);
            spriteBatch.DrawString(font, "Player BetAmount: " + player.BetAmount.ToString(), new Vector2(800, 525), Color.Black);
            spriteBatch.DrawString(font, "Player has BJ?: "  + player.HasBlackJack, new Vector2(800, 550), Color.Black);
            spriteBatch.DrawString(font, "Player has bet?: " + player.PlacedBet, new Vector2(800, 575), Color.Black);
            spriteBatch.DrawString(font, "Player has busted?: " + player.HasBusted, new Vector2(800, 600), Color.Black);
            spriteBatch.DrawString(font, "Player has been paid?: " + player.HasBeenPaid, new Vector2(800, 625), Color.Black);
            spriteBatch.DrawString(font, "Player is Standing?: " + player.IsStanding, new Vector2(800, 650), Color.Black);
            spriteBatch.DrawString(font, "Player won last?: " + player.WonLastHand, new Vector2(800, 675), Color.Black);

            spriteBatch.DrawString(font, "Dealer High Hand Value?: " + dealer.HighHandValue, new Vector2(800, 0), Color.Black);
            spriteBatch.DrawString(font, "Dealer Low Hand Value?: " + dealer.LowHandValue, new Vector2(800, 25), Color.Black);
            spriteBatch.DrawString(font, "Dealer Final Hand Value?: " + dealer.FinalHandValue, new Vector2(800, 50), Color.Black);
            spriteBatch.DrawString(font, "Dealer Has BJ?: " + dealer.HasBlackJack, new Vector2(800, 75), Color.Black);
            spriteBatch.DrawString(font, "Dealer Has Busted?: " + dealer.HasBusted, new Vector2(800, 100), Color.Black);
            spriteBatch.DrawString(font, "Dealer Is Standing?: " + dealer.IsStanding, new Vector2(800, 125), Color.Black);
            
            



        }

        /*
        -GameStart()
        -Initialize(){
        -create/shuffle deck
        -create players
        -create buttons
        -state=place bets
        }
        {PlaceBets}
        -clear table
        -place bets
        -once "Bet" is pressed state = DealCards
        {DealCards}
        dealers deals cards
        -check blackjack (if blackjack...state = getwinner)
        -if (no blackjack state = playeraction)
        {playerAction}
        -get input(after every hit or dd) check if bust
        -if (bust, state = getwinner)
        -if (bust on a leg of split, or stand on leg of split continue)//implement later
        -if (stand, state = dealerAction)
        {dealerAction}
        -do Dealer AI actions
        -if bust (state = getwinner)
        -compare dealer value to player value
        -state = getwinner.
        {getwinner}
        -if busts do bust logic
        -if comparing values do compare values logic
        -display win or loss message
        -allocate money 
        state = placebets
        

        


   

        










    */
    }
}
