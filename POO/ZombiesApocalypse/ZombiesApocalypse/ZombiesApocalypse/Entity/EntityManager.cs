using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ZombiesApocalypse
{
    static class EntityManager
    {
        static List<Entity> Entities = new List<Entity>();

        // Modified to include GraphicsDevice and ContentManager
        public static void Add(Entity entity)
        {
            Entities.Add(entity);
        }


        public static void LoadContent()
        {
            Console.WriteLine($"Total Entities: {Entities.Count}");
            foreach (Entity entity in Entities)
            {
                entity.LoadContent();
            }
        }


        public static void Update(GameTime time)
        {
            foreach (Entity entity in Entities)
            {
                entity.Update(time);
            }
        }

        public static void Draw()
        {
            foreach (Entity entity in Entities)
            {
                entity.Draw();
                Console.WriteLine("Drawn");
            }
        }
    }
}
