using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Linq;
using Microsoft.Xna.Framework.Content;

namespace Favonite_Development.States
{
    public abstract class State
    {
        protected Game1 _game;
        protected ContentManager _content;
        protected GraphicsDevice _graphicsDevice;

        public State(Game1 game, GraphicsDevice graphicsDevice,ContentManager content, SpriteBatch spriteBatch)
        {
            _game = game;
            _content = content;
            _graphicsDevice = graphicsDevice;
        }

        public abstract void Initialize();
        public abstract void LoadContent();


        public abstract void Update(GameTime gameTime);


        public abstract void PostUpdate(GameTime gameTime);


        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);
    }
}
