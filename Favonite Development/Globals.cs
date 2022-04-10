using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Favonite_Development
{
    public static class Globals
    {

        public const float gravity = 9.81f;
        public static Vector2 Gravity = new Vector2(0, 9.81f);

        public const int screenWidth = 1920;
        public const int screenHeight = 1080;

        public const int screenRatio = 16 / 9;
    }
}
