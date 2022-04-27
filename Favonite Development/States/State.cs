using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Favonite_Development.States
{
    //abstract parent class state containing all the methods and declarations used for stateclasses 
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

        public abstract void UnloadContent();


        public abstract void Update(GameTime gameTime);


        public abstract void PostUpdate(GameTime gameTime);


        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);
    }
}
