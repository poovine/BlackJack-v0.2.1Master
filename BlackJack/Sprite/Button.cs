using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BlackJack {
    class Button : Sprite {

        public Vector2 Position { get { return position; } }
        public Rectangle SourceRectangle { get { return sourceRectangle; } }
        public bool IsActive { get { return isActive; } set { isActive = value; } }
        public bool IsVisible { get { return isVisible; } set { isVisible = value; } }
        public string Name { get { return name; } }
        public int Value { get; set; }

        public enum ButtonType {
            CardActionButton,
            BettingButton
        }

        private ButtonType buttonType;

        private string name;

        public Button(int value, ButtonType buttonType, string name, Texture2D buttonTexture, Vector2 buttonPosition, Rectangle sourceRectangle,
                      float scale = 1, float rotation = 0, float layerDepth = 1
            ) : base(buttonTexture, buttonPosition, sourceRectangle) {
            this.Value = value;
            this.buttonType = buttonType;
            this.name = name;
            this.scale = scale;
            this.rotation = rotation;
            this.layerDepth = layerDepth;
        }

        private void UpdateIfActive() {
            var player = GameManager.Instance.PlayerManager.Player;
            var dealer = GameManager.Instance.PlayerManager.Dealer;

            if (Game1.gameState == Game1.GameState.Game && GameManager.Instance.gamePlayState == GameManager.GamePlayState.PlaceBets) {

                switch (this.buttonType) {
                    case ButtonType.CardActionButton:
                        this.IsActive = false;
                        this.IsVisible = false;
                        break;
                    case ButtonType.BettingButton:
                        if (this.Value > player.ChipCount) {
                            this.IsActive = false;
                            this.IsVisible = false;
                        }
                        else {
                            this.IsActive = true;
                            this.IsVisible = true;
                        }
                        break;
                }
            }
            else if (Game1.gameState == Game1.GameState.Game && GameManager.Instance.gamePlayState == GameManager.GamePlayState.PlayerAction) {
                switch (this.buttonType) {
                    case ButtonType.CardActionButton: {
                            if (player.CanHit() && this.Name == "Hit") {
                                this.IsActive = true;
                                this.IsVisible = true;
                            }

                            else if (player.CanDoubleDown() && this.Name == "DoubleDown") {
                                this.IsActive = true;
                                this.IsVisible = true;
                            }

                            else if (player.CanStand() && this.Name == "Stand") {
                                this.IsActive = true;
                                this.IsVisible = true;
                            }

                             else if (player.CanSplit() && this.Name == "Split"){
                                this.IsActive = true;
                                this.IsVisible = true;   
                            } 
                            else {
                                this.IsActive = false;
                                this.IsVisible = false;
                            }
                        }
                        break;

                    case ButtonType.BettingButton:
                        this.IsActive = false;
                        this.IsVisible = false;
                        break;
                }
            }

            else {
                switch (this.buttonType) {
                    case ButtonType.CardActionButton:
                        this.IsActive = false;
                        this.IsVisible = false;
                        break;
                    case ButtonType.BettingButton:
                        this.IsActive = false;
                        this.IsVisible = false;
                        break;
                }
            }

        }

        public override void Update(GameTime gameTime) {
            UpdateIfActive();
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch) {
            if (this.isVisible) {
                spriteBatch.Draw(spriteTexture, position, sourceRectangle, Color.White, rotation, origin, scale, SpriteEffects.None, layerDepth);
            }
            base.Draw(spriteBatch);
        }

    }
}
