using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack {
    class CommandManager {
        public HitCommand Hit { get { return hit; } }
        public StandCommand Stand { get { return stand; } } 
        public DoubleDownCommand DoubleDown { get { return doubleDown; } }
        public SplitCommand Split { get { return split; } }
        public BetCommand Bet { get { return bet; } }
        public DoNothingCommand DoNothing { get { return doNothing; } }

        private HitCommand hit;
        private StandCommand stand;
        private DoubleDownCommand doubleDown;
        private SplitCommand split;
        private BetCommand bet;
        private DoNothingCommand doNothing;

        public CommandManager() {
            hit = new HitCommand();
            stand = new StandCommand();
            doubleDown = new DoubleDownCommand();
            split = new SplitCommand();
            bet = new BetCommand();
            doNothing = new DoNothingCommand();
        }
    }
}
