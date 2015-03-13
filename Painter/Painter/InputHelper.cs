using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Painter
{
    public class InputHelper
    {
        MouseState currentMouseState;
        MouseState previousMouseState;

        KeyboardState currentKeyboardState;
        KeyboardState previousKeyboardState;

        public void Update()
        {
            previousMouseState = currentMouseState;
            currentMouseState = Mouse.GetState();

            previousKeyboardState = currentKeyboardState;
            currentKeyboardState = Keyboard.GetState();
        }

        public Vector2 MousePosition
        {
            get { return new Vector2(currentMouseState.X, currentMouseState.Y); }
        }

        public bool MouseLeftButtonPressed()
        {
            return currentMouseState.LeftButton == ButtonState.Pressed
                    && previousMouseState.LeftButton == ButtonState.Released;
        }

        public bool KeyPressed(Keys k)
        {
            return currentKeyboardState.IsKeyDown(k) && previousKeyboardState.IsKeyUp(k);
        }
    }
}
