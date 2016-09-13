using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack {
    interface ICommand {
        void Execute(Dealer dealer, Player player);
        void Execute(Dealer dealer);
        void Execute(Player player);
    }

    class HitCommand : ICommand {
        public void Execute(Dealer dealer, Player player) {
            dealer.IsStanding = false;
            dealer.Hit(player);
        }

        public void Execute(Dealer dealer) {
            dealer.IsStanding = false;
            dealer.Hit(dealer);
        }

        public void Execute(Player player) {

        }
    }

    class StandCommand : ICommand {
        public void Execute(Dealer dealer, Player player) {

        }

        public void Execute(Dealer dealer) {
            dealer.IsStanding = true;
        }
        public void Execute(Player player) {
            player.IsStanding = true;
        }
    }

    class DoubleDownCommand : ICommand {
        public void Execute(Dealer dealer, Player player) {
            dealer.Hit(player);
            player.ChipCount -= player.FinalBetAmount;
            player.FinalBetAmount *= 2;
            player.IsStanding = true;
        }

        public void Execute(Dealer dealer) {

        }
        public void Execute(Player player) {

        }
    }

    class SplitCommand : ICommand {
        public void Execute(Dealer dealer, Player player) {
            dealer.Hit(player);
            dealer.Hit(player);
            dealer.Hit(player);
            dealer.Hit(player);
            dealer.Hit(player);
            dealer.Hit(player);

        }
        public void Execute(Dealer dealer) {

        }
        public void Execute(Player player) {

        }
    }

    class BetCommand : ICommand {
        public void Execute(Dealer dealer, Player player) {

        }
        public void Execute(Dealer dealer) {

        }
        public void Execute(Player player) {
            if (player.BetAmount > 0) {
                player.FinalBetAmount = player.BetAmount;
                player.BetAmount = 0;
                player.ChipCount -= player.FinalBetAmount;
                player.PlacedBet = true;
            }
        }
    }

    class AddToBet : ICommand {
        public int Amount { get; set; }

        public void Execute(Dealer dealer, Player player) {

        }
        public void Execute(Dealer dealer) {

        }
        public void Execute(Player player) {
            if (player.BetAmount + GameManager.SubBet <= player.ChipCount) {
                player.BetAmount += GameManager.SubBet;
            }
        }
    }

    class SubstractFromBet : ICommand {
        public int Amount { get; set; }

        public void Execute(Dealer dealer, Player player) {

        }
        public void Execute(Dealer dealer) {

        }
        public void Execute(Player player) {
            if (GameManager.SubBet <= player.BetAmount) {
                player.BetAmount -= GameManager.SubBet;
            }
        }
    }

    class DoNothingCommand : ICommand {
        public void Execute(Dealer dealer, Player player) {

        }
        public void Execute(Dealer dealer) {

        }
        public void Execute(Player player) {

        }
    }
}
