using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BlackJack {
    abstract class Sprite {
        protected Vector2 position, origin;
        protected Rectangle sourceRectangle;
        protected Texture2D spriteTexture;
        protected float scale, rotation, layerDepth;
        protected bool isActive = true, isVisible = true;                 

        public Sprite(Texture2D spriteTexture, Vector2 position, Rectangle sourceRectangle) {
            this.spriteTexture = spriteTexture;
            this.position = position;
            this.sourceRectangle = sourceRectangle;
        }

        public virtual void Update(GameTime gameTime) {

        }

        public virtual void Draw(SpriteBatch spriteBatch) {
                       
        }

    }
}
