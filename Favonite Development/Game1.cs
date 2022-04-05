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

        private Player player;
        private EnemyManager enemytype = new EnemyManager();
        
        Texture2D playerTexture, enemyTexture;
        float scale = 1f;

        #endregion

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
             player = new Player();

            _graphics.PreferredBackBufferWidth = Globals.screenWidth;
            _graphics.PreferredBackBufferHeight = Globals.screenHeight;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            Animation playerAnimation = new Animation();
            playerTexture = Content.Load<Texture2D>("utauDown");
            playerAnimation.Initialize(playerTexture, player.position, 32, 48, 4, 120, Color.White, scale, true);
            player.Initialize(playerAnimation);
            details = GraphicsDevice;
            enemyTexture = Content.Load<Texture2D>("PlaceholderPlayer");
            enemytype.Initialize(enemyTexture, details);
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Controls.GetState().IsKeyDown(Keys.Escape))
                Exit();

            player.Update(gameTime);
            enemytype.Update(gameTime,player);
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            player.Draw(_spriteBatch);
            enemytype.Draw(_spriteBatch);
            _spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
