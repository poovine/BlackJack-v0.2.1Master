using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace BlackJack {
    class ButtonManager {
        private Button hitButton, standButton, doubleButton, splitButton,
                       betButton, tenButton, hundredButton, fiveHundredButton,
                       oneThousandButton, fiveThousandButton, tenThousandButton;        

        public Button HitButton { get { return hitButton; } }
        public Button StandButton { get { return standButton; } }
        public Button DoubleButton { get { return doubleButton; } }
        public Button SplitButton { get { return splitButton; } }
        public Button BetButton { get { return betButton; } }
        public Button TenButton { get { return tenButton; } }
        public Button HundredButton { get { return hundredButton; } }
        public Button FiveHundredButton { get { return fiveHundredButton; } }
        public Button OneThousandButton { get { return oneThousandButton; } }
        public Button FiveThousandButton { get { return fiveThousandButton; } }
        public Button TenThousandButton { get { return tenThousandButton; } }

        public List<Button> Buttons { get; set; }

        private Texture2D buttonSprites, chipSprites;

        private ContentManager content;

        public ButtonManager() {
            this.content = new ContentManager(Game1.content.ServiceProvider, "Content");
        }
        public void InitializeButtons() {
            buttonSprites = content.Load<Texture2D>("Textures\\bjbuttons");
            chipSprites = content.Load<Texture2D>("Textures\\chipsSheet3");
            Buttons = new List<Button>();
            Buttons.Add(hitButton = new Button(0,Button.ButtonType.CardActionButton,"Hit", buttonSprites, new Vector2(475, 515), new Rectangle(0, 0, 90, 65)));
            Buttons.Add(standButton = new Button(0,Button.ButtonType.CardActionButton,"Stand", buttonSprites, new Vector2(720, 515), new Rectangle(90, 0, 90, 65)));
            Buttons.Add(doubleButton = new Button(0,Button.ButtonType.CardActionButton,"DoubleDown",buttonSprites, new Vector2(475, 570), new Rectangle(180, 0, 90, 65)));
            Buttons.Add(splitButton = new Button(0,Button.ButtonType.CardActionButton,"Split",buttonSprites, new Vector2(720, 570), new Rectangle(270, 0, 90, 65)));
            Buttons.Add(betButton = new Button(0,Button.ButtonType.BettingButton,"Bet", buttonSprites, new Vector2(720, 650), new Rectangle(360, 0, 90, 65)));
            Buttons.Add(tenButton = new Button(10,Button.ButtonType.BettingButton, "Ten", chipSprites, new Vector2(845, 640), new Rectangle(343, 0, 65, 65)));
            Buttons.Add(hundredButton = new Button(100,Button.ButtonType.BettingButton, "Hundred", chipSprites, new Vector2(915, 640), new Rectangle(69, 0, 65, 65)));
            Buttons.Add(fiveHundredButton = new Button(500,Button.ButtonType.BettingButton, "FiveHundred", chipSprites, new Vector2(985, 640), new Rectangle(275, 0, 65, 65)));
            Buttons.Add(oneThousandButton = new Button(1000,Button.ButtonType.BettingButton, "OneThousand",chipSprites, new Vector2(1055, 640), new Rectangle(206, 0, 65, 65)));
            Buttons.Add(fiveThousandButton = new Button(5000,Button.ButtonType.BettingButton, "FiveThousand",chipSprites, new Vector2(1125, 640), new Rectangle(137, 0, 65, 65)));
            Buttons.Add(tenThousandButton = new Button(10000,Button.ButtonType.BettingButton, "TenThousand",chipSprites, new Vector2(1195, 640), new Rectangle(0, 0, 65, 65)));
        }

        public void DrawGameButtons(SpriteBatch spriteBatch) {
            foreach(Button button in Buttons) {
                button.Draw(spriteBatch);
            }
        }

        public void UpdateAllButtons(GameTime gameTime) {
           foreach(Button button in Buttons) {
                button.Update(gameTime);
            }
        }

        public void LoadContent() {
            InitializeButtons();
        }

        public void Update(GameTime gameTime) {
            UpdateAllButtons(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch) {
            DrawGameButtons(spriteBatch);
        }
    }
}
