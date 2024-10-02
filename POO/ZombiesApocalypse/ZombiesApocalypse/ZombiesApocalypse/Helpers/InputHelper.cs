using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;

namespace ZombiesApocalypse.Helpers
{
    static class InputHelper
    {
        public static KeyboardState GetKeyStatus() => Keyboard.GetState();
    }
}
