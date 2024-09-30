using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;

namespace ZombieApocalypse.Helpers
{
    static class InputHelpers
    {
        public static Vector2 GetPlayerDirection(KeyboardState keyState)
        {
            Vector2 direction = new Vector2(0, 0);

            if (keyState.IsKeyDown(Keys.A))
                direction = new Vector2(-1, 0);

            else if (keyState.IsKeyDown(Keys.D))
                direction = new Vector2(1, 0);
            return direction;
        }

        public static void CheckForPlayerAction(KeyboardState keyState, float timeSinceLastBullet, float pistolBulletCooldown, float timeSinceLastChange, float attackChangeCooldown, Player Soldat)
        {

            if (keyState.IsKeyDown(Keys.X) && timeSinceLastChange >= attackChangeCooldown)
            {
                Soldat.ChangeAttackType();
            }

            if (keyState.IsKeyDown(Keys.Space) && timeSinceLastBullet >= pistolBulletCooldown)
                Soldat.NewBullet();
        }
    }
}
