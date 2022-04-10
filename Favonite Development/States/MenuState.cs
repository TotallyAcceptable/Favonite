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
    public class MenuState :  State
    {
        private List<Component> _components;
        private Texture2D menuBackgroundTexture, icon, titleName;



        public MenuState(Game1 game, GraphicsDevice graphicsDevice,ContentManager content) : base(game,graphicsDevice,content)
        {
            var buttonTexture = _content.Load<Texture2D>("Start Game");

            var newGameButton = new Button(buttonTexture)
            {
                Position = new Vector2(960, 700),
                
            };

            newGameButton.Click += NewGameButton_Click;

            var loadGameButton = new Button(buttonTexture)
            {
                Position = new Vector2(960, 800),
                Text = "Load Game",
            };

            loadGameButton.Click += LoadGameButton_Click;

            var quitGameButton = new Button(buttonTexture)
            {
                Position = new Vector2(960, 900),
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

        public override void LoadContent()
        {
            var buttonTexture = _content.Load<Texture2D>("Start Game");
            menuBackgroundTexture = _content.Load<Texture2D>("Main Menu Background");
            icon = _content.Load<Texture2D>("FavoniteIcon");
            titleName = _content.Load<Texture2D>("Title name");

        }


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
            foreach (var component in _components)
                component.Draw(gameTime,spriteBatch);
            spriteBatch.End();
        }

        private void LoadGameButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Load Game");
        }
        private void NewGameButton_Click(object sender, EventArgs e)
        {
            _game.ChangeState(new GameState(_game, _graphicsDevice, _content));
        }
        private void QuitGameButton_Click(object sender, EventArgs e)
        {
            _game.Exit();
        }

    }
}
