using Favonite_Development.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Favonite_Development
{
    public class Game1 : Game
    {
        #region Declarations
        public GraphicsDeviceManager _graphics;
        GraphicsDevice details;
        private SpriteBatch _spriteBatch;
        enum GameStates { TitleScreen, OpeningMenu, Playing, Credits }
        GameStates gameStates = GameStates.TitleScreen;

        private State _currentState;
        private State _nextState;
        #endregion

        public void ChangeState(State state)
        {
            _nextState = state;
        }

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {   
            _graphics.PreferredBackBufferWidth = Globals.screenWidth;
            _graphics.PreferredBackBufferHeight = Globals.screenHeight;
            _graphics.ApplyChanges();

            

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _currentState = new MenuState(this, _graphics.GraphicsDevice, Content, _spriteBatch);
            _currentState.LoadContent();
            _nextState = null;
            // TODO: use this.Content to load your game content here
        }

        protected override void UnloadContent()
        {

            base.UnloadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || PlayerInputs.GetState().IsKeyDown(Keys.Escape))
                Exit();
            {
                if (_nextState != null)
                {
                    _currentState = _nextState;
                    _currentState.LoadContent();

                    _nextState = null;
                }

                _currentState.Update(gameTime);
                _currentState.PostUpdate(gameTime);
            }
           

            // TODO: Add your update logic here

            base.Update(gameTime);
        }



        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _currentState.Draw(gameTime, _spriteBatch);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
