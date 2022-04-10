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
        private bool isJumping;
        public bool active, isHit;
        public int playerHealth, playerAttack, playerDefence;
  

        public int Width
        {
            get { return animation.frameWidth; }
        }
        
        public int Height
        {
            get { return animation.frameHeight; }
        }

        private void Velocity()
        {
            speed = MathF.Sqrt(velocity.X * velocity.X + velocity.Y * velocity.Y);
            normalDirection = new Vector2(velocity.X / speed, velocity.Y / speed);
            velocity = normalDirection * speed;
        }
        #endregion

        public void Initialize(Animation animation)
        {
            this.animation = animation;
            speed = 0f;
            position = Vector2.Zero;
            velocity = Vector2.Zero;
            acceleration = new Vector2(500,0);
            jumpingAcceleration = new Vector2(0, 2000);
            friction = 3f;
            windResistance = 0.2f;
            sourceRect = new Rectangle(0, 0, 40, 40);
            isJumping = false;
            playerHealth = 100;
        }

        public void Update(GameTime gameTime)
        {
            Rectangle boundingRectangle = new Rectangle((int)position.X, (int)position.Y, animation.frameWidth, animation.frameHeight);
            PlayerInputs.GetState();
            #region Keys

            if (PlayerInputs.IsPressed(Keys.D) == true)
            {
                
                // using pythagoras theorem to calculate physics based movement
                speed = MathF.Sqrt(velocity.X * velocity.X + velocity.Y * velocity.Y); //scalar representation of velocity
                normalDirection = new Vector2(velocity.X / speed, velocity.Y / speed); //normalised vector
                velocity = normalDirection * speed;//velocity
                System.Diagnostics.Debug.WriteLine(velocity);
                velocity += acceleration * (float)gameTime.ElapsedGameTime.TotalSeconds; // velocity with acceleration applied
                System.Diagnostics.Debug.WriteLine(velocity);
                position.X += velocity.X * (float)gameTime.ElapsedGameTime.TotalSeconds; // change in player position
                PlayerInputs.SetState();
                System.Diagnostics.Debug.WriteLine("FALSE");

            }
            if (PlayerInputs.IsKeyReleased(Keys.D) == true)
            {
                velocity.X = 0;
                System.Diagnostics.Debug.WriteLine("TRUE");
                PlayerInputs.SetState();
            }
            if (PlayerInputs.IsPressed(Keys.A) == true)
            {
                
                // using pythagoras theorem to calculate physics based movement
                speed = MathF.Sqrt(velocity.X * velocity.X + velocity.Y * velocity.Y); //scalar representation of velocity
                normalDirection = new Vector2(velocity.X / speed, velocity.Y / speed); //normalised vector
                velocity = normalDirection * speed;//velocity
                velocity -= acceleration * (float)gameTime.ElapsedGameTime.TotalSeconds; // velocity with acceleration applied
                System.Diagnostics.Debug.WriteLine(velocity);
                position.X += velocity.X * (float)gameTime.ElapsedGameTime.TotalSeconds; // change in player position
                PlayerInputs.SetState();
                System.Diagnostics.Debug.WriteLine("FALSE");

            }
            if (PlayerInputs.IsKeyReleased(Keys.A) == true)
            {
                velocity.X = 0;
                System.Diagnostics.Debug.WriteLine("TRUE");
                PlayerInputs.SetState();
            }
            if (PlayerInputs.IsPressed(Keys.Space) == true && isJumping == false)
            {
                isJumping = true;
                //fill in

                speed = MathF.Sqrt(velocity.X * velocity.X + velocity.Y * velocity.Y); //scalar representation of velocity
                normalDirection = new Vector2(velocity.X / speed, velocity.Y / speed); //normalised vector
                velocity = normalDirection * speed;//velocity
                velocity -= jumpingAcceleration * (float)gameTime.ElapsedGameTime.TotalSeconds; // velocity with acceleration applied
                System.Diagnostics.Debug.WriteLine(velocity);
                position.Y += velocity.Y * (float)gameTime.ElapsedGameTime.TotalSeconds;

                PlayerInputs.SetState();
            }
            if (PlayerInputs.IsKeyReleased(Keys.Space) == true && isJumping == true)
            {
                isJumping = false;  
                PlayerInputs.SetState();
            }

            #endregion

            position.X = MathHelper.Clamp(position.X, 0,Globals.screenWidth - animation.frameWidth);
            position.Y = MathHelper.Clamp(position.Y, 0, Globals.screenHeight - animation.frameHeight);

            #region Gravity
            velocity.Y += .01f * (Globals.gravity * (float)gameTime.ElapsedGameTime.TotalSeconds);
            position.Y += MathHelper.Clamp(velocity.Y, 0, 60);
            #endregion

            #region collision

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



    }
}
