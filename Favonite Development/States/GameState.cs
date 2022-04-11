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

namespace Favonite_Development.States
{
    class GameState : State
    {
        private ContentManager _content;
        private GraphicsDevice _details;
        private SpriteBatch _spriteBatch;
        private Player player = new Player();
        private EnemyManager enemytype = new EnemyManager();
        Texture2D playerTexture, enemyTexture;
        float scale = 1f;

        public GameState(Game1 game, GraphicsDevice graphicsDevice,ContentManager content, SpriteBatch spriteBatch) : base(game, graphicsDevice,content, spriteBatch)
        {
            _content = content;
            _details = graphicsDevice;
            _spriteBatch = spriteBatch;

        }

        public override void Initialize()
        {
            player = new Player();
        }


        public override void LoadContent()
        {
            Animation playerAnimation = new Animation();
            playerTexture = _content.Load<Texture2D>("utauDown");
            playerAnimation.Initialize(playerTexture, player.position, 32, 48, 4, 120, Color.White, scale, true);
            player.Initialize(playerAnimation);
            enemyTexture = _content.Load<Texture2D>("PlaceholderPlayer");
            enemytype.Initialize(enemyTexture, _details);
        }

        public override void Update(GameTime gameTime)
        {
            player.Update(gameTime);
            enemytype.Update(gameTime, player);
        }
        public override void PostUpdate(GameTime gameTime)
        {
         
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {

            _spriteBatch.Begin();
            player.Draw(_spriteBatch);
            enemytype.Draw(_spriteBatch);
            _spriteBatch.End();
        }
    }
}
