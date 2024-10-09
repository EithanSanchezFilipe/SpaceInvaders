using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ZombiesApocalypse.Helpers;
namespace ZombiesApocalypse
{
    static class EntityManager
    {
        public static List<Entity> Entities = new List<Entity>();
        private static Level _level;
        public static void Add(Entity entity)
        {
            Entities.Add(entity);

            //Charger la texture de l'entité
            entity.LoadContent();
        }


        public static void LoadContent()
        {

            foreach (Entity entity in Entities)
            {
                entity.LoadContent();
            }
        }


        public static void Update(GameTime time, Level level)
        {
            _level = level;
            if (_level.NumberOfZombies == 0)
            {
                _level.addLevel();
                _level.SpawnZombie();
            }
            //ToArray afin déviter les modifications alors qu'on est entrain de parcourir cette liste
            foreach (Entity entity in Entities.ToArray())
            {
                entity.Update(time);
                if(entity.Health <= 0)
                    entity.Destroyed = true;
                if (entity is Bullet bullet && bullet.Position.Y < 0)
                    bullet.Destroyed = true;
            }

            //Appelle de methodes qui verifient si il y a des collision
            CollisionBulletZombie();
            CollisionFenceZombie();

            //Appele d'une methode qui efface toutes les entités mortes
            DeleteEntities();
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            foreach (Entity entity in Entities)
            {
                entity.Draw(spriteBatch);
            }
        }

        private static void DeleteEntities()
        {
            //ToArray afin déviter les modifications alors qu'on est entrain de parcourir cette liste
            foreach (Entity entity in Entities.ToArray())
            {
                if (entity.Destroyed)
                {
                    Entities.Remove(entity);
                    if (entity is Ennemy zombie)
                        _level.NumberOfZombies--;
                }

            }
        }
        private static void CollisionBulletZombie()
        {
            //ToArray afin déviter les modifications alors qu'on est entrain de parcourir cette liste
            foreach (Entity bullet in Entities.ToArray())
            {
                //prends que les balles en compte
                if (bullet is Bullet)
                {
                    //ToArray afin déviter les modifications alors qu'on est entrain de parcourir cette liste
                    foreach (Entity zombie in Entities.ToArray())
                    {
                        //prends que les zombies en compte
                        if (zombie is Ennemy)
                        {
                            //verifie la collision
                            if (bullet.Hitbox.Intersects(zombie.Hitbox) && !bullet.Destroyed)
                            {
                                
                                bullet.Destroyed = true;
                                ((Ennemy)zombie).TakeDamage(((Bullet)bullet).BulletDamage);
                                Console.WriteLine("collision");
                            }
                        }
                    }
                }
            }
        }
        private static void CollisionFenceZombie()
        {
            foreach(Entity entity in Entities.ToArray())
            {
                if(entity is Fence fence)
                {
                    foreach(Entity ennemy in Entities.ToArray())
                    {
                        if(ennemy is Ennemy zombie)
                        {
                            if (fence.Hitbox.Intersects(zombie.Hitbox) && !fence.Destroyed)
                            {
                                if(zombie._attackCooldown <= 0)
                                {
                                    fence.takeDamage(Ennemy.Damage);
                                    zombie._attackCooldown = GlobalHelpers.ZOMBIEATTACKCOOLDOWN;
                                }

                                zombie.isColliding = true;
                                Console.WriteLine("aaaaaaaa");
                            }
                            else
                                zombie.isColliding = false;
                        }
                    }
                }
            }
        }
    }
}
