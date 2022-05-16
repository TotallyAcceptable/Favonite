using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Favonite_Development.Core
{
    public class Camera
    {
        public Matrix Transform { get; private set; }

        public void Follow(Player target)
        {
            var position = Matrix.CreateTranslation(-target.position.X - (target.Width / 2), -target.position.Y - (target.Height / 2), 0);
            var offet = Matrix.CreateTranslation(Globals.screenWidth / (float)2, Globals.screenHeight / (float)2, 0);

            Transform = position * offet;
        }
    }
}
