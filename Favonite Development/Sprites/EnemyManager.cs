using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Favonite_Development
{
    class EnemyManager
    {
        #region Declarations
        Texture2D enemyTexture;
        static public List<Enemy> enemiesType1 = new List<Enemy>();
        GraphicsDeviceManager graphics;
        TimeSpan enemySpawnTime = TimeSpan.FromSeconds(4.0f);
        TimeSpan previousSpawnTime = TimeSpan.Zero;
        Random random = new Random(); // random number generator

        Vector2 graphicsInfo;

        #endregion

        public static void UpdateCollision(Player player, GUI guiInfo)
        {
            Rectangle rect1, rect2;

            rect1 = new Rectangle((int)player.position.X, (int)player.position.Y, player.Width, player.Height);

            for(int i =0; i < enemiesType1.Count; i++)
            {
                rect2 = new Rectangle((int)enemiesType1[i].position.X, (int)enemiesType1[i].position.Y, (int)enemiesType1[i].Width, (int)enemiesType1[i].Height);

                if (rect1.Intersects(rect2))
                {
                    System.Diagnostics.Debug.WriteLine("   player hittt ");
                    player.playerHealth -= enemiesType1[i].Damage;
                    enemiesType1[i].health = 0;
                    enemiesType1[i].active = false;
                    guiInfo.PLAYERHP -= 25;
                    if(guiInfo.PLAYERHP == 0 && guiInfo.LIVES > 0)
                    {
                        player.active = false;
                        guiInfo.LIVES -= 1;
                        guiInfo.PLAYERHP = 100;
                    }
                    

                    if (player.playerHealth <= 0)
                        player.active = false;

                    player.isHit = true;
                }
            }

        }

        public void Initialize(Texture2D texture, GraphicsDevice graphics)
        {
            enemyTexture = texture;
            graphicsInfo.X = graphics.Viewport.Width;
            graphicsInfo.Y = graphics.Viewport.Height;
        }

        private void AddEnemy()
        {
            Animation enemyAnimation = new Animation();
            enemyAnimation.Initialize(enemyTexture, Vector2.Zero, 47, 61, 1, 30, Color.White, 1f, true);
            int newY = (int)graphicsInfo.Y;
            Vector2 position = new Vector2(graphicsInfo.X + enemyTexture.Width / 2, random.Next(50, newY - 50));

            Enemy enemy = new Enemy();
            enemy.Initialize(enemyAnimation, position);
            enemiesType1.Add(enemy);

        }

        public void Update(GameTime gameTime, Player player, GUI guiInfo)
        {
            if (gameTime.TotalGameTime - previousSpawnTime > enemySpawnTime)
            {
                previousSpawnTime = gameTime.TotalGameTime;
                AddEnemy();
            }

            UpdateCollision(player, guiInfo);

            for (int i = (enemiesType1.Count - 1); i >= 0; i--)
            {
                enemiesType1[i].Update(gameTime);
                if (enemiesType1[i].active == false)
                    enemiesType1.RemoveAt(i);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < enemiesType1.Count; i++)
                enemiesType1[i].Draw(spriteBatch);

        }
    }
}
