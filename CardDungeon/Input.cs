using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardDungeon
{
    public class Input
    {
        private static KeyboardState currentKeyboardState;
        private static KeyboardState oldKeyboardState;

        private static MouseState currentMouseState;
        private static MouseState oldMouseState;
        private static int currentWheelValue, oldWheelValue;

        public static KeyboardState CurrentKeyboardState
        {
            get { return currentKeyboardState; }

            set { currentKeyboardState = value; }
        }
        public static MouseState MouseState
        {
            get { return currentMouseState; }

            set { currentMouseState = value; }
        }

        public static bool isKeyDown(Keys key)
        {
            return currentKeyboardState.IsKeyDown(key);
        }

        public static bool isKeyPressed(Keys key)
        {
            return oldKeyboardState.IsKeyUp(key) && currentKeyboardState.IsKeyDown(key);
        }

        public static bool isLeftClicked()
        {
            return oldMouseState.LeftButton == ButtonState.Released && currentMouseState.LeftButton == ButtonState.Pressed;
        }
        public static bool isRightClicked()
        {
            return oldMouseState.RightButton == ButtonState.Released && currentMouseState.RightButton == ButtonState.Pressed;
        }

        public static Vector2 CurrentMoussePosition()
        {
            return new Vector2(currentMouseState.Position.X * ((float)Settings.WIDTH_SOURCE / (float)Settings.WIDTH_TARGET)
                , currentMouseState.Position.Y * ((float)Settings.HEIGHT_SOURCE / (float)Settings.HEIGHT_TARGET));
        }

        public static Vector2 OldMoussePosition()
        {
            return new Vector2(oldMouseState.Position.X * ((float)Settings.WIDTH_SOURCE / (float)Settings.WIDTH_TARGET)
                , oldMouseState.Position.Y * ((float)Settings.HEIGHT_SOURCE / (float)Settings.HEIGHT_TARGET));
        }

        public static void Listen()
        {
            oldKeyboardState = currentKeyboardState;
            oldMouseState = currentMouseState;
            oldWheelValue = currentWheelValue;

            currentKeyboardState = Keyboard.GetState();
            MouseState = Mouse.GetState();
            currentWheelValue = Mouse.GetState().ScrollWheelValue;
        }

        public static bool isScrollUp()
        {
            return oldWheelValue < currentWheelValue;
        }
        public static bool isScrollDown()
        {
            return oldWheelValue > currentWheelValue;
        }
    }
}
