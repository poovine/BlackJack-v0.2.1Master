using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace BlackJack {
    class InputManager {

        public static ICommand LastInput = null;
        private static InputManager instance;

        public static InputManager Instance {
            get {
                if (instance == null) {
                    instance = new InputManager();
                }
                return instance;
            }
        }
        private Player player;
        private Dealer dealer;

        public InputHandler InputHandler { get; private set; }

        public InputManager() {
            InputHandler = new InputHandler();
        }

        public void LoadContent() {
            player = GameManager.Instance.PlayerManager.Player;
            dealer = GameManager.Instance.PlayerManager.Dealer;
        }

        public void Update(GameTime gameTime) {
            var cmd = InputHandler.HandleInput();
            if (cmd.GetType() == typeof(HitCommand) || cmd.GetType() == typeof(DoubleDownCommand)) {
                LastInput = cmd;
                cmd.Execute(dealer, player);
            }
            else {
                LastInput = cmd;
                cmd.Execute(player);
            }         
        }
    }
}
