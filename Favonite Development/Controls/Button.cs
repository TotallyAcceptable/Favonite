using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Favonite_Development.States;
using System.ComponentModel;

namespace Favonite_Development.Controls
{
    public class Button : Component
    {

        #region Declarations
        private MouseState _currentMouse;
        private MouseState _previousMouse;
        private bool _isHovering;
        private Texture2D _texture;

        #endregion

        #region Properties

        public EventHandler Click;
        public bool Clicked { get; private set; }
        public float Layer { get; set; }
        public Vector2 Origin
        {
            get
            {
                return new Vector2(_texture.Width / 2, _texture.Height / 2);
            }
        }

        public Vector2 Position { get; set; }
        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)Position.X -((int)Origin.X),(int)Position.Y - (int)Origin.Y, _texture.Width,_texture.Height);
            }
        }

        public String Text;

        #endregion

        #region Methods

        public Button(Texture2D texture)
        {
            _texture = texture;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            var Colour = Color.White;

            if (_isHovering)
                Colour = Color.Blue;

            spriteBatch.Draw(_texture, Position, null, Colour, 0f, Origin,1f,SpriteEffects.None,Layer);
        }

        public override void Update(GameTime gameTime)
        {
            _previousMouse = _currentMouse;
            _currentMouse = Mouse.GetState();

            var MouseRectangle = new Rectangle(_currentMouse.X, _currentMouse.Y, 1, 1);

            _isHovering = false;

            if (MouseRectangle.Intersects(Rectangle))
            {
                _isHovering = true;

                if(_currentMouse.LeftButton == ButtonState.Released && _previousMouse.LeftButton == ButtonState.Pressed)
                {
                    Click?.Invoke(this, new EventArgs());
                }
            }
        }
        #endregion
    }
}
