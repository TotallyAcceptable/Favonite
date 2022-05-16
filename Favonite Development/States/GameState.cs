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
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

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

        Texture2D rightWalk, leftWalk, currentAnim;

        Texture2D legend;
        Texture2D playerGUI;
        GUI guiInfo = new GUI();
        private SpriteFont font;
        KeyboardState oldState;

        private Texture2D _backgroundTexture;

        private SoundEffect jumpSound;
        private SoundEffect bulletSound;
        private Song gameMusic;
        public Sounds SND = new Sounds();



        public GameState(Game1 game, GraphicsDevice graphicsDevice,ContentManager content, SpriteBatch spriteBatch) : base(game, graphicsDevice,content, spriteBatch)
        {
            _content = content;
            _details = graphicsDevice;
            _spriteBatch = spriteBatch;
            player = new Player(_content.Load<Texture2D>("ReiGunRunning"));


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
                {0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 },
                {0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
                {0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
                {1,1,1,1,1,1,1,1,0,0,0,1,0,0,0,1,1,1,1,1,1,1,0,0,0,1,1,1,1,1 },
                {1,1,1,1,1,1,1,1,0,0,0,1,1,1,1,1,1,1,1,1,1,1,0,0,0,1,0,0,0,1 },
                {1,1,1,1,1,1,1,1,0,0,0,1,1,1,1,1,1,1,1,1,1,1,0,0,0,1,0,0,0,1 },
                {1,1,1,1,1,1,1,1,0,0,0,1,1,1,1,1,1,1,1,1,1,1,0,0,0,1,0,0,0,1 },
                {1,1,1,1,1,1,1,1,0,0,0,1,1,1,1,1,1,1,1,1,1,1,0,0,0,1,0,0,0,1 },
                {1,1,1,1,1,1,1,1,0,0,0,1,1,1,1,1,1,1,1,1,1,1,0,0,0,1,0,0,0,1 },
                {1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,1 },
                {1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,1 },
                {1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,1 },
                {1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,1 },
                {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,1 },
                {1,0,0,0,0,0,0,0,0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
                {1,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 },


            },64);

            _backgroundTexture = _content.Load<Texture2D>("brickBackground");
            Animation playerAnimation = new Animation();
            playerTexture = _content.Load<Texture2D>("ReiGunRunning");
            playerAnimation.Initialize(playerTexture, player.position, 48, 62, 1, 120, Color.White, scale, true);
            player.Initialize(playerAnimation);
            enemyTexture = _content.Load<Texture2D>("PlaceholderPlayer");
            enemytype.Initialize(enemyTexture, _details);
            bulletsTexture = _content.Load<Texture2D>("bullet");
            Bullets.Initialize(bulletsTexture, _details);
            legend = _content.Load<Texture2D>("legend");
            playerGUI = _content.Load<Texture2D>("lives");
            guiInfo.Initialize(0, 100, 3, 1);
            font = _content.Load<SpriteFont>("Font");

            jumpSound = _content.Load<SoundEffect>("jumpSound");
            bulletSound = _content.Load<SoundEffect>("bulletSound");
            SND.Initialize(jumpSound,bulletSound);

        }

        public override void UnloadContent() {

        }


        public override void Update(GameTime gameTime)
        {
            _camera.Follow(player);
            player.Update(gameTime, SND);
            foreach (CollisionTiles tiles in map.CollisionTiles)
                player.Collision(tiles.Rectangle, map.Width, map.Height);
            enemytype.Update(gameTime, player, guiInfo);
            Bullets.UpdateManagerBullets(gameTime, player, SND, guiInfo);

            if(guiInfo.SCORE >= guiInfo.LEVELUPGRADE)
            {
                guiInfo.LEVELUPGRADE = guiInfo.SCORE + 50;
                guiInfo.LEVEL += 1;
            }


        }
        public override void PostUpdate(GameTime gameTime)
        {
         
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            _spriteBatch.Begin(transformMatrix: _camera.Transform); //localise view via camera
            _spriteBatch.Draw(_backgroundTexture, new Vector2(0, 0), Color.White);
            map.Draw(_spriteBatch);
            player.Draw(_spriteBatch);
            Bullets.DrawBullets(_spriteBatch);
            enemytype.Draw(_spriteBatch);
            _spriteBatch.End();

            _spriteBatch.Begin();
            //_spriteBatch.DrawString(font, "Score: " + score, new Vector2(100, 100), Color.Black);
            _spriteBatch.Draw(legend, new Vector2(0, 0), Color.White);
            _spriteBatch.DrawString(font, "Score: " + guiInfo.SCORE, new Vector2(5, 2), Color.White);
            _spriteBatch.DrawString(font, "Level: " + guiInfo.LEVEL, new Vector2(5, 32), Color.White);
            _spriteBatch.DrawString(font, "HP: " + guiInfo.PLAYERHP, new Vector2(5, 65), Color.White);
            for (int i = 0; i <= guiInfo.LIVES; i++)
            {
                _spriteBatch.Draw(playerGUI, new Vector2(300 + i * 80, 5), Color.White);
            }

            _spriteBatch.End();

        }
    }
}
