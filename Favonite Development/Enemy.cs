using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Favonite_Development
{
    class Enemy
    {

        #region Declarations
        public Animation EnemyAnimation;
        public Vector2 position;
        public bool active;
        public int health;
        public int Damage;
        public int value;
        float enemyMoveSpeed;

        public int Width
        {
            get { return EnemyAnimation.frameWidth; }
        }
        
        public int Height
        {
            get { return EnemyAnimation.frameHeight; }
        }

        #endregion
        public void Initialize(Animation animation, Vector2 position)
        {
            EnemyAnimation = animation;
            this.position = position;
            active = true;
            health = 10;
            Damage = 10;
            enemyMoveSpeed = 2f;
            value = 100;

        }

        public void Update(GameTime gameTime)
        {
            position.X -= enemyMoveSpeed;
            EnemyAnimation.position = position;

            EnemyAnimation.Update(gameTime);

            if(position.X < -Width|| health <= 0)
            {
                active = false;
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            EnemyAnimation.Draw(spriteBatch);
        }


    }
}
