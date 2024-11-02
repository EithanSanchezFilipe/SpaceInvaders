using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;

namespace ZombiesApocalypse.Helpers
{
    static class InputHelper
    {
        /// <summary>
        /// Methode qui return la touche appuyee
        /// </summary>
        /// <returns>la touche appuyee</returns>
        public static KeyboardState GetKeyStatus() => Keyboard.GetState();
    }
}
