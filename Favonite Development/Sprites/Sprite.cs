using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Favonite_Development.Sprites 
{
   public class Sprite
    {

        public Texture2D _texture;

        public Vector2 position { get; set; }

        public Rectangle rectangle
        {
            get { return new Rectangle((int)position.X, (int)position.Y, _texture.Width, _texture.Height); }
        }

        public Sprite(Texture2D texture)
        {
            _texture = texture;
        }
        public void Draw(GameTime gameTime,SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, position, Color.White);
        }


        public void Update(GameTime gameTime)
        {

        }

        public virtual void ApplyPhysiscs()
        {

        }

    }
}
