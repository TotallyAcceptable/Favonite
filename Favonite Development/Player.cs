using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Favonite_Development
{
    class Player
    {
        #region Declarations

        private Animation animation;
        public Vector2 position, velocity, acceleration,jumpingAcceleration, normalDirection;
        private Rectangle sourceRect;
        private float speed, windResistance, friction;
        private bool isJumping, isHit;
        private int playerHealth, playerAttack, playerDefence;
  

        public int Width
        {
            get { return animation.frameWidth; }
        }
        
        public int Height
        {
            get { return animation.frameHeight; }
        }

        #endregion

        public void Initialize(Animation animation)
        {
            this.animation = animation;
            speed = 0f;
            position = Vector2.Zero;
            velocity = Vector2.Zero;
            acceleration = new Vector2(1000,0);
            jumpingAcceleration = new Vector2(0, 200);
            friction = 3f;
            windResistance = 0.2f;
            sourceRect = new Rectangle(0, 0, 40, 40);
            isJumping = false;
        }

        public void Update(GameTime gameTime)
        {
            Rectangle boundingRectangle = new Rectangle((int)position.X, (int)position.Y, animation.frameWidth, animation.frameHeight);
            Controls.GetState();
            #region Keys

            if (Controls.IsPressed(Keys.D) == true)
            {
                velocity = new Vector2(1, 0);
                // using pythagoras theorem to calculate physics based movement
                speed = MathF.Sqrt(velocity.X * velocity.X + velocity.Y * velocity.Y); //scalar representation of velocity
                normalDirection = new Vector2(velocity.X / speed, velocity.Y / speed); //normalised vector
                velocity = normalDirection * speed;//velocity
                velocity += acceleration * (float)gameTime.ElapsedGameTime.TotalSeconds; // velocity with acceleration applied
                position.X += velocity.X * (float)gameTime.ElapsedGameTime.TotalSeconds; // change in player position
                Controls.SetState();
                System.Diagnostics.Debug.WriteLine("FALSE");

            }
            if (Controls.IsKeyReleased(Keys.D) == true)
            {
                velocity = Vector2.Zero;
                System.Diagnostics.Debug.WriteLine("TRUE");
                Controls.SetState();
            }
            if (Controls.IsPressed(Keys.A) == true)
            {
                velocity = new Vector2(-1, 0);
                // using pythagoras theorem to calculate physics based movement
                speed = MathF.Sqrt(velocity.X * velocity.X + velocity.Y * velocity.Y); //scalar representation of velocity
                normalDirection = new Vector2(velocity.X / speed, velocity.Y / speed); //normalised vector
                velocity = normalDirection * speed;//velocity
                velocity -= acceleration * (float)gameTime.ElapsedGameTime.TotalSeconds; // velocity with acceleration applied
                position.X += velocity.X * (float)gameTime.ElapsedGameTime.TotalSeconds; // change in player position
                Controls.SetState();
                System.Diagnostics.Debug.WriteLine("FALSE");

            }
            if (Controls.IsKeyReleased(Keys.A) == true)
            {
                velocity = Vector2.Zero;
                System.Diagnostics.Debug.WriteLine("TRUE");
                Controls.SetState();
            }
            if (Controls.IsPressed(Keys.Space) == true && isJumping == false)
            {
                isJumping = true;
                //fill in
                Controls.SetState();
            }
            if (Controls.IsKeyReleased(Keys.Space) == true && isJumping == true)
            {
                isJumping = false;
                
                Controls.SetState();
            }

            #endregion

            //position.X = MathHelper.Clamp(position.X, 0,Globals.screenWidth - animation.frameWidth);
            //position.Y = MathHelper.Clamp(position.Y, 0, Globals.screenHeight - animation.frameHeight);

            #region Gravity
            velocity.Y += .01f * (Globals.gravity * (float)gameTime.ElapsedGameTime.TotalSeconds);
            position.Y += MathHelper.Clamp(velocity.Y, 0, 10);
            #endregion

            #region collision
            if (boundingRectangle.Intersects(sourceRect)) //placeholderrr
            {
                isHit = true;
                System.Diagnostics.Debug.WriteLine("Player Hit");
            }

            #endregion

            #region animation
            animation.position = position;
            animation.Update(gameTime);
            #endregion
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            animation.Draw(spriteBatch);
        }

        private void Velocity()
        {
            speed = MathF.Sqrt(velocity.X * velocity.X + velocity.Y * velocity.Y);
            normalDirection = new Vector2(velocity.X / speed, velocity.Y / speed);
            velocity = normalDirection * speed;
        }

    }
}
