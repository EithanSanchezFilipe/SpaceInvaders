using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace ZombieApocalypse.Helpers
{
    public static class CollisionHelpers
    {
        public static bool CollidesWith(Zombie zombie, Bullet bullet) => !zombie.isDespawning && bullet.Position.Y < zombie.Position.Y + zombie.texture.Height * 0.4f / 2 && bullet.Position.X > zombie.Position.X - zombie.texture.Width * 0.4f / 2 && bullet.Position.X < zombie.Position.X + zombie.texture.Width * 0.4f / 2;
        public static bool IsOutOfBounds(Vector2 playerPosition, Vector2 playerDirection, int playerWidth) => !(playerPosition.X + playerWidth * 0.4f / 2 + playerDirection.X < GlobalHelpers.screenWidth) || !(playerPosition.X - playerWidth * 0.4f / 2 + playerDirection.X > 0);


    }
}
