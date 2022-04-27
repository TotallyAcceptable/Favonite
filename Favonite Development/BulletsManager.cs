﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Favonite_Development
{
    class BulletsManager
    {
        static Texture2D bulletsTexture;
        static Rectangle bulletsRectangle;
        static public List<Bullets> bullets;
        const float SECONDS_IN_MINUTE = 60f;
        const float RATE_OF_FIRE = 200f;
        static TimeSpan bulletsSpawnTime = TimeSpan.FromSeconds(SECONDS_IN_MINUTE / RATE_OF_FIRE);
        static TimeSpan previousBulletsSpawnTime;
        public Vector2 position;

        GraphicsDeviceManager graphics;
        static Vector2 graphicsInfo;

        KeyboardState currentKeyboardState;
        KeyboardState previousKeyboardState;

        GamePadState currentGamePadState;
        GamePadState previousGamePadState;

        public void Initialize(Texture2D texture, GraphicsDevice Graphics)
        {
            bullets = new List<Bullets>();
            previousBulletsSpawnTime = TimeSpan.Zero;
            bulletsTexture = texture;
            graphicsInfo.X = Graphics.Viewport.Width;
            graphicsInfo.Y = Graphics.Viewport.Height;
        }

        public static void ShootBullets(GameTime gameTime, Player p)
        {
            if (gameTime.TotalGameTime - previousBulletsSpawnTime > bulletsSpawnTime)
            {
                previousBulletsSpawnTime = gameTime.TotalGameTime;
                AddBullets(p);
            }

        }

        private static void AddBullets(Player p)
        {
            Animation bulletsAnimation = new Animation();
            bulletsAnimation.Initialize(bulletsTexture, p.Position, 46, 16, 1, 30, Color.White, 1f, true);
            Bullets bullet = new Bullets();
            var bulletsPosition = p.position;
            bulletsPosition.Y += 37;
            bulletsPosition.X += 70;
            bullet.Initialize(bulletsAnimation, bulletsPosition);
            bullets.Add(bullet);
            //bulletSoundInstance.Play();
        }

        public void UpdateManagerBullets(GameTime gameTime, Player player)
        {
            previousGamePadState = currentGamePadState;
           
            PlayerInputs.GetState();
            currentGamePadState = GamePad.GetState(PlayerIndex.One);

            if (PlayerInputs.IsPressed(Keys.Space) == true || GamePad.GetState(PlayerIndex.One).Buttons.X == ButtonState.Pressed)
            {
                ShootBullets(gameTime, player);
                PlayerInputs.SetState();
            }

            for (int i = 0; i < bullets.Count; i++)
            {
                bullets[i].Update(gameTime);
                if (!bullets[i].Active || bullets[i].Position.X > graphicsInfo.X)
                {
                    bullets.Remove(bullets[i]);
                }
            }

            foreach (Enemy e in EnemyManager.enemiesType1)
            {
                Rectangle enemyRectangle = new Rectangle(
                    (int)e.position.X,
                    (int)e.position.Y,
                    e.Width,
                    e.Height);

                foreach (Bullets B in BulletsManager.bullets)
                {
                    bulletsRectangle = new Rectangle(
                        (int)B.Position.X,
                        (int)B.Position.Y,
                        B.Width,
                        B.Height);

                    if (bulletsRectangle.Intersects(enemyRectangle))
                    {
                        //play the sound of explosion

                        //show the explosion

                        e.health = 0;

                        //record the kills

                        B.Active = false;

                        //record your score
                    }
                }
            }
        }

        public void DrawBullets(SpriteBatch spriteBatch)
        {
            foreach (var b in bullets)
            {
                b.Draw(spriteBatch);
            }
        }


    }
}

