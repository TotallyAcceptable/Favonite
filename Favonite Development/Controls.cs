using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Favonite_Development
{
    public class Controls
    {
        public static KeyboardState currentKeyboardState;
        public static KeyboardState oldKeyboardState;
        public static GamePadState currentGamePadState;
        public static GamePadState oldGamePadState;

        public static KeyboardState GetState()
        {
            currentKeyboardState = Keyboard.GetState();
            return currentKeyboardState;
        }

        public static GamePadState GetGamepadState()
        {
            currentGamePadState = GamePad.GetState(PlayerIndex.One);
            return currentGamePadState;
        }

        public static bool IsPressed(Keys keys)
        {
            return currentKeyboardState.IsKeyDown(keys);
        }

        public static bool IsKeyReleased(Keys keys)
        {
            return currentKeyboardState.IsKeyUp(keys) && oldKeyboardState.IsKeyDown(keys);
        }

        public static void SetState()
        {
            oldKeyboardState = currentKeyboardState;
        }

        public static void SetGamepadState()
        {
            oldGamePadState = currentGamePadState;
        }


    }
}
