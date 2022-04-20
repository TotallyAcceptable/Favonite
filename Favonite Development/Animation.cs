using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Favonite_Development
{
    public class Animation
    {
        #region Declarations
        Texture2D spriteStrip;
        float scale;
        int elapsedTime, frameTime, frameCount, currentFrame;
        Color color;
        Rectangle sourceRect, destinationRect;

        public int frameWidth, frameHeight;
        public bool active, looping;
        public Vector2 position;

        private List<Rectangle> frames = new List<Rectangle>();

        #endregion

        public void Initialize(Texture2D texture, Vector2 position, int frameWidth, int frameHeight, int frameCount, int frameTime, Color color, float scale, bool looping)
        {
            this.color = color;
            this.frameWidth = frameWidth;
            this.frameHeight = frameHeight;
            this.frameCount = frameCount;
            this.frameTime = frameTime;
            this.scale = scale;

            this.looping = looping;
            this.position = position;
            spriteStrip = texture;

            elapsedTime = 0;
            currentFrame = 0;

            active = true;

            sourceRect = new Rectangle(currentFrame * frameWidth, 0, frameWidth, frameHeight);
            destinationRect = new Rectangle((int)position.X - (int)(frameWidth * scale) / 2, (int)position.Y - (int)(frameHeight * scale) / 2, (int)(frameWidth * scale), (int)(frameHeight * scale));

            for(int x =0; x< frameCount; x++)
            {
                frames.Add(new Rectangle((frameWidth * x), 0, frameWidth, frameHeight));
            }
        }

        public void Update(GameTime gameTime)
        {
            if (active == false)
                return;
            elapsedTime += (int)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (elapsedTime > frameTime)
            {
                currentFrame++;
                if(currentFrame == frameCount)
                {
                    currentFrame = 0;
                    if (looping = false)
                        active = false;
                }
                elapsedTime = 0;
            }

            sourceRect = frames[currentFrame];
            destinationRect = new Rectangle((int)position.X, (int)position.Y, frameWidth, frameHeight);

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (active)
            {
                spriteBatch.Draw(spriteStrip, destinationRect, sourceRect, color);
            }
        }

    }
}
