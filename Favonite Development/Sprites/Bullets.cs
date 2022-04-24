using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Favonite_Development.Sprites
{
    class Bullets : Sprite
    {
        public Texture2D texture;

        public Vector2 position, velocity, origin;
        public bool isVisible;

        public Bullets(Texture2D newTexture) : base(newTexture)
        {
            texture = newTexture;
            isVisible = false;
        }


        public void LoadContent()
        {
            Bullets newBullets = new Bullets(_Content.Load<Texture2D>("Bullet"));
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, null, Color.White, 0f ,origin, 1f, SpriteEffects.None, 0);
        }
    }
}
