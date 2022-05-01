﻿using System;
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
    //game state class is used for the main game including levels enemies and player functionality instead of directly writing to the game1 class
    class GameState : State
    {
        //declarations
        private Map map;
        private ContentManager _content;
        private GraphicsDevice _details;
        private SpriteBatch _spriteBatch;
        private Camera _camera = new Camera();

        private EnemyManager enemytype = new EnemyManager();
        BulletsManager Bullets = new BulletsManager();
        Texture2D playerTexture, enemyTexture,healthBar;
        Texture2D bulletsTexture;
        private Player player;
        float scale = 1f;

        private SpriteFont font;
        private int score = 0;
        KeyboardState oldState;

        public GameState(Game1 game, GraphicsDevice graphicsDevice,ContentManager content, SpriteBatch spriteBatch) : base(game, graphicsDevice,content, spriteBatch)
        {
            _content = content;
            _details = graphicsDevice;
            _spriteBatch = spriteBatch;
            player = new Player(_content.Load<Texture2D>("utauDown"));


        }

        public override void Initialize()
        {
            oldState = Keyboard.GetState();
        }


        public override void LoadContent()
        {
            //load in the map
            map = new Map();
            Tiles.Content = _content;
            map.Generate(new int[,]{
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                {3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3 },
                {3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3 },
                {3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3 },
                {2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2},
                {3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3 },
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                {2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2 },
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 },


            },64);
            Animation playerAnimation = new Animation();
            playerTexture = _content.Load<Texture2D>("utauDown");
            playerAnimation.Initialize(playerTexture, player.position, 32, 48, 4, 120, Color.White, scale, true);
            player.Initialize(playerAnimation);
            enemyTexture = _content.Load<Texture2D>("PlaceholderPlayer");
            enemytype.Initialize(enemyTexture, _details);
            bulletsTexture = _content.Load<Texture2D>("bullet");
            Bullets.Initialize(bulletsTexture, _details);
            font = _content.Load<SpriteFont>("Score");


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
            Bullets.UpdateManagerBullets(gameTime, player);

        }
        public override void PostUpdate(GameTime gameTime)
        {
         
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            _spriteBatch.Begin();
            _spriteBatch.DrawString(font, "Score: " + score, new Vector2(100, 100), Color.Black);
            _spriteBatch.End();

            _spriteBatch.Begin(transformMatrix: _camera.Transform); //localise view via camera
            map.Draw(_spriteBatch);
            player.Draw(_spriteBatch);
            Bullets.DrawBullets(_spriteBatch);
            enemytype.Draw(_spriteBatch);
            _spriteBatch.End();
           

        }
    }
}
