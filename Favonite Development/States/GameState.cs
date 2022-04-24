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
using Favonite_Development.Core;

namespace Favonite_Development.States
{
    class GameState : State
    {
        private Map map;
        private ContentManager _content;
        private GraphicsDevice _details;
        private SpriteBatch _spriteBatch;
        private Camera _camera = new Camera();

        private EnemyManager enemytype = new EnemyManager();
        Texture2D playerTexture, enemyTexture;
        private Player player;
        float scale = 1f;

        public GameState(Game1 game, GraphicsDevice graphicsDevice,ContentManager content, SpriteBatch spriteBatch) : base(game, graphicsDevice,content, spriteBatch)
        {
            _content = content;
            _details = graphicsDevice;
            _spriteBatch = spriteBatch;
            player = new Player(_content.Load<Texture2D>("utauDown"));

        }

        public override void Initialize()
        {

        }


        public override void LoadContent()
        {
            map = new Map();
            Tiles.Content = _content;
            map.Generate(new int[,]{
                {2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2 },
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 },
                {2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2},
                {3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3 },
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                {3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3 },
                {3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3 },
                {3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3 },

            },64);
            Animation playerAnimation = new Animation();
            playerTexture = _content.Load<Texture2D>("utauDown");
            playerAnimation.Initialize(playerTexture, player.position, 32, 48, 4, 120, Color.White, scale, true);
            player.Initialize(playerAnimation);
            enemyTexture = _content.Load<Texture2D>("PlaceholderPlayer");
            enemytype.Initialize(enemyTexture, _details);
        }

        public override void UnloadContent() {

        }


        public override void Update(GameTime gameTime)
        {
            _camera.Follow(player);
            player.Update(gameTime);
            foreach (CollisionTiles tiles in map.CollisionTiles)
                player.Collision(tiles.Rectangle, map.Width, map.Height);
            enemytype.Update(gameTime, player);

        }
        public override void PostUpdate(GameTime gameTime)
        {
         
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            _spriteBatch.Begin(transformMatrix: _camera.Transform); //localise view via camera
            map.Draw(_spriteBatch);
            player.Draw(_spriteBatch);
            enemytype.Draw(_spriteBatch);
            _spriteBatch.End();
           

        }
    }
}
