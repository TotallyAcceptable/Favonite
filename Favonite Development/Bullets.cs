using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Favonite_Development
{
    class Bullets
    {
        #region Declarations
        public Animation BulletsAnimation;
        float velocity = 30f;
        public Vector2 Position;
        int Damage = 10;
        public bool Active;
        int Range;

        public int Width
        {
            get { return BulletsAnimation.frameWidth; }
        }

        public int Height
        {
            get { return BulletsAnimation.frameHeight; }
        }

        #endregion

        public void Initialize(Animation animation, Vector2 position)
        {
            BulletsAnimation = animation;
            Position = position;
            Active = true;
        }

        public void Update(GameTime gameTime)
        {
            Position.X += velocity;
            BulletsAnimation.position = Position;
            BulletsAnimation.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            BulletsAnimation.Draw(spriteBatch);
        }
    }
}
