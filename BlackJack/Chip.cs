using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BlackJack {

    //NOT BEING USED ATM...ENDED UP MAKING CHIPS AS BUTTONS
    class Chip : Sprite {
        public Vector2 Position { get { return position; } set { position = value; } }
        public Rectangle SourceRectangle { get { return sourceRectangle; } private set { } }
        public int Value { get; set; }

        public Chip(Texture2D chipTexture, Vector2 position, Rectangle sourceRectangle,
                    float scale = 1, float rotation = 0, float layerDepth = 1)
                   : base(chipTexture, position, sourceRectangle) {
            this.rotation = rotation;
            this.scale = scale;
            this.layerDepth = layerDepth;
        }

        public override void Update(GameTime gameTime) {
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(spriteTexture, position,sourceRectangle,Color.White, rotation,origin, scale, SpriteEffects.None, layerDepth);
            base.Draw(spriteBatch);
        }
    }
}
