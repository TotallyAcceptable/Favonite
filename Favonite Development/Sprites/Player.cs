using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;
using Favonite_Development.Sprites;
using Favonite_Development.Core;

namespace Favonite_Development
{
    public class Player : Sprite
    {
        #region Declarations
        
        private Animation animation;
        public Vector2 position, velocity, acceleration,jumpingAcceleration, normalDirection;
        private Rectangle boundingRectangle;
        private float speed;
        private bool _Jumping , _onGround;
        public bool active, isHit;
        public int playerHealth, playerAttack, playerDefence;

        private List<Bullets> bullets = new List<Bullets>();
  

        public int Width
        {
            get { return animation.frameWidth; }
        }
        
        public int Height
        {
            get { return animation.frameHeight; }
        }

        public Vector2 Position
        {
            get { return position; }
        }

        public Player(Texture2D texture) : base(texture)
        {

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
            _Jumping = false;
            playerHealth = 100;
            boundingRectangle = Rectangle.Empty;
            _onGround = true;
        }

        public void Update(GameTime gameTime)
        {
            position += velocity;
            //Rectangle boundingRectangle = new Rectangle((int)position.X, (int)position.Y, animation.frameWidth, animation.frameHeight);
            PlayerInputs.GetState();
            Input(gameTime);

            #region animation
            animation.position = position;
            animation.Update(gameTime);
            #endregion


            if (velocity.Y < 10)
                velocity.Y += 0.4f;
            
            #region Gravity
            //velocity.Y += .01f * (Globals.gravity * (float)gameTime.ElapsedGameTime.TotalSeconds);
           // position.Y += MathHelper.Clamp(velocity.Y, 0, 60);
            #endregion


            if(playerHealth == 0)
            {
                active = false;
            }
        }

        private void Input(GameTime gameTime)
        {
            PlayerInputs.GetState();

            if(PlayerInputs.IsPressed(Keys.D) == true)
            {
                velocity.X = (float)gameTime.ElapsedGameTime.TotalMilliseconds / 3;
                PlayerInputs.SetState();
            }
            else if (PlayerInputs.IsKeyReleased(Keys.D) == true)
            {
                velocity.X = 0;
                PlayerInputs.SetState();
            }
            else if (PlayerInputs.IsPressed(Keys.A) == true)
            {
                velocity.X = -(float)gameTime.ElapsedGameTime.TotalMilliseconds / 3;
                PlayerInputs.SetState();
            }
            else if (PlayerInputs.IsKeyReleased(Keys.A) == true)
            {
                velocity.X = 0;
                PlayerInputs.SetState();
            }
            if (PlayerInputs.IsPressed(Keys.W) == true && _Jumping == false)
            {
                position.Y -= +5f;
                velocity.Y = -9f;
                _Jumping = true;
                PlayerInputs.SetState();
            }
        }

        private void shoot()
        {
            

        }
        private void UpdateBullets()
        {
            foreach(Bullets b in bullets)
            {
                b.position += b.velocity;
                if (Vector2.Distance(b.position, position) > 600)
                    b.isVisible = false;
            }
            for(int i =0; i< bullets.Count; i++)
            {
                if (!bullets[i].isVisible)
                    bullets.RemoveAt(i);
                i--;
            }
        }
        public void Collision(Rectangle newRectangle, int xOffset, int yOffset)
        {
            Rectangle boundingRectangle = new Rectangle((int)position.X, (int)position.Y, animation.frameWidth, animation.frameHeight);

            if (boundingRectangle.TouchTopOf(newRectangle)){
                boundingRectangle.Y = newRectangle.Y - boundingRectangle.Height;
                velocity.Y = 0f;
                _Jumping = false;
            }
            if (boundingRectangle.TouchLeftOf(newRectangle))
            {
                position.X = newRectangle.X - boundingRectangle.Width - 2;
            }
            if (boundingRectangle.TouchRightOf(newRectangle))
            {
                position.X = newRectangle.X + boundingRectangle.Width + 2;
            }
            if (boundingRectangle.TouchBottomOf(newRectangle))
            {
                velocity.Y = 1f;
            }

            position.X = MathHelper.Clamp(position.X, 0, Globals.screenWidth - animation.frameWidth);
            position.Y = MathHelper.Clamp(position.Y, 0, Globals.screenHeight - animation.frameHeight);
        }
        
        public void Draw(SpriteBatch spriteBatch)
        {
            animation.Draw(spriteBatch);
            
        }

        #region TemporaryMethods
        private void Velocity()
        {
            speed = MathF.Sqrt(velocity.X * velocity.X + velocity.Y * velocity.Y);
            normalDirection = new Vector2(velocity.X / speed, velocity.Y / speed);
            velocity = normalDirection * speed;
        }
        private void temp()
        {
            #region Keys

            if (PlayerInputs.IsPressed(Keys.D) == true)
            {

                #region 1stmovementimplementation
                /*
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
                */
                #endregion

            }
            if (PlayerInputs.IsKeyReleased(Keys.D) == true)
            {
                velocity.X = 0;
                System.Diagnostics.Debug.WriteLine("TRUE");
                PlayerInputs.SetState();
            }
            if (PlayerInputs.IsPressed(Keys.A) == true)
            {
                #region 1stmovementimplementation
                /*
                // using pythagoras theorem to calculate physics based movement
                speed = MathF.Sqrt(velocity.X * velocity.X + velocity.Y * velocity.Y); //scalar representation of velocity
                normalDirection = new Vector2(velocity.X / speed, velocity.Y / speed); //normalised vector
                velocity = normalDirection * speed;//velocity
                velocity -= acceleration * (float)gameTime.ElapsedGameTime.TotalSeconds; // velocity with acceleration applied
                System.Diagnostics.Debug.WriteLine(velocity);
                position.X += velocity.X * (float)gameTime.ElapsedGameTime.TotalSeconds; // change in player position
                PlayerInputs.SetState();
                System.Diagnostics.Debug.WriteLine("FALSE");
                */
                #endregion

            }
            if (PlayerInputs.IsKeyReleased(Keys.A) == true)
            {
                velocity.X = 0;
                System.Diagnostics.Debug.WriteLine("TRUE");
                PlayerInputs.SetState();
            }
            if (PlayerInputs.IsPressed(Keys.Space) == true && _Jumping == false)
            {
                _Jumping = true;
                //fill in
                if (!_onGround)
                    velocity.Y += 0.2f;
                if (_onGround && _Jumping)
                {
                    velocity.Y = -5f;
                    System.Diagnostics.Debug.WriteLine("_Jumping");
                }


                PlayerInputs.SetState();
            }
            if (PlayerInputs.IsKeyReleased(Keys.Space) == true && _Jumping == true)
            {
                _Jumping = false;
                PlayerInputs.SetState();
            }

            #endregion
        }


    }

    #endregion
}
