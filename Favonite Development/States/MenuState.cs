using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Linq;
using Microsoft.Xna.Framework.Content;
using Favonite_Development.Controls;
using System.ComponentModel;
using Favonite_Development;

namespace Favonite_Development.States
{
    public class MenuState :  State // child class of state
    {

        private List<Component> _components;
        private Texture2D menuBackgroundTexture, icon, titleName;
        private SpriteBatch _spriteBatch;

        //constructor
        //setting the buttons and button textures within the constructor
        public MenuState(Game1 game, GraphicsDevice graphicsDevice,ContentManager content, SpriteBatch spriteBatch) : base(game,graphicsDevice,content , spriteBatch)
        {
            _spriteBatch = spriteBatch;

            var buttonTexture = _content.Load<Texture2D>("startGame");

            var newGameButton = new Button(buttonTexture)
            {
                Position = new Vector2(960, 600),
                
            };

            newGameButton.Click += NewGameButton_Click;

            var loadGameButton = new Button(buttonTexture)
            {
                Position = new Vector2(960, 775),
                Text = "Load Game",
            };

            loadGameButton.Click += LoadGameButton_Click;

            var quitGameButton = new Button(buttonTexture)
            {
                Position = new Vector2(960, 950),
                Text = "Quit Game",
            };

            quitGameButton.Click += QuitGameButton_Click;

            _components = new List<Component>()
            {
                newGameButton,
                loadGameButton,
                quitGameButton,
            };

        }

        public override void Initialize()
        {

        }

        //load in the textures
        public override void LoadContent()
        {
            var buttonTexture = _content.Load<Texture2D>("startGame");
            menuBackgroundTexture = _content.Load<Texture2D>("Main Menu Background");
            icon = _content.Load<Texture2D>("FavoniteIcon");
            titleName = _content.Load<Texture2D>("Title name");

        }

        public override void UnloadContent()
        {
           
        }


        //applies and updates the components with the correct functionality
        public override void Update(GameTime gameTime)
        {
            foreach (var component in _components)
                component.Update(gameTime);
        }

        public override void PostUpdate(GameTime gameTime)
        {
            
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            spriteBatch.Draw(menuBackgroundTexture, new Vector2(0, 0), Color.White);
            spriteBatch.Draw(icon, new Vector2(860, 0), Color.White);
            spriteBatch.Draw(titleName, new Vector2(560, 200), Color.White);
            //draw each button component
            foreach (var component in _components)
                component.Draw(gameTime,spriteBatch);
            spriteBatch.End();
        }


        //button component private methods
        private void LoadGameButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Load Game");
        }
        private void NewGameButton_Click(object sender, EventArgs e)
        {
            _game.ChangeState(new GameState(_game, _graphicsDevice, _content, _spriteBatch));
        }
        private void QuitGameButton_Click(object sender, EventArgs e)
        {
            _game.Exit();
        }

    }
}
