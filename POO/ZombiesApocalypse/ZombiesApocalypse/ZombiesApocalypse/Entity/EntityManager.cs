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
        /// <summary>
        /// Methode qui ajoute une entite a une liste
        /// </summary>
        /// <param name="entity"></param>
        public static void Add(Entity entity)
        {
            Entities.Add(entity);

            //Charger la texture de l'entité
            entity.LoadContent();
        }

        /// <summary>
        /// Methode qui initialise les hitbox et textures de toutes les entites
        /// </summary>
        public static void LoadContent()
        {

            foreach (Entity entity in Entities)
            {
                entity.LoadContent();
            }
        }

        /// <summary>
        /// Methode qui actualise le niveau, les entites
        /// </summary>
        /// <param name="time"></param>
        /// <param name="level"></param>
        public static void Update(GameTime time, Level level)
        {
            _level = level;
            if (_level.NumberOfZombies == 0)
            {
                _level.AddLevel();
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

                foreach(Entity entity1 in Entities)
                {
                    if (entity is Limit limit && entity1 is Player soldier)
                        soldier.Health = limit.Health;
                    if(entity is Limit limitWire && entity1 is Player player && limitWire.Destroyed)
                            Game1._gameState = GameState.GameOver;
                }
            }

            //ToArray afin déviter les modifications alors qu'on est entrain de parcourir cette liste
            if (Game1._gameState == GameState.GameOver)
            {
                foreach (Entity entity in Entities.ToArray())
                {
                    Entities.Remove(entity);
                }
            }

            //Appelle de methodes qui verifient si il y a des collision
            CollisionBulletZombie();
            CollisionFenceZombie();
            CollisionLimitZombie();

            //Appele d'une methode qui efface toutes les entités mortes
            DeleteEntities();
        }
        /// <summary>
        /// Methode qui appelle les methodes draw de chaque entite
        /// </summary>
        /// <param name="spriteBatch"></param>
        public static void Draw(SpriteBatch spriteBatch)
        {
            Player player = GetPlayer();
            foreach (Entity entity in Entities)
            {
                entity.Draw(spriteBatch);
            }
            player.Draw(spriteBatch);
        }

        /// <summary>
        /// Methode qui enleve des entites de la liste
        /// </summary>
        private static void DeleteEntities()
        {
            //ToArray afin déviter les modifications alors qu'on est entrain de parcourir cette liste
            foreach (Entity entity in Entities.ToArray())
            {
                if (entity.Destroyed)
                {
                    Entities.Remove(entity);
                    if (entity is Enemy zombie)
                        _level.NumberOfZombies--;
                }

            }
        }
        /// <summary>
        /// Verifie les collisions entre les balles et les zombies
        /// </summary>
        private static void CollisionBulletZombie()
        {
            foreach (Entity bullet in Entities)
            {
                //prends que les balles en compte
                if (bullet is Bullet)
                {
                    foreach (Entity zombie in Entities)
                    {
                        //prends que les zombies en compte
                        if (zombie is Enemy)
                        {
                            //verifie la collision
                            if (bullet.Hitbox.Intersects(zombie.Hitbox) && !bullet.Destroyed)
                            {
                                
                                bullet.Destroyed = true;
                                ((Enemy)zombie).TakeDamage(((Bullet)bullet).BulletDamage);
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Verifie les collisions entre les barricades et les zombies
        /// </summary>
        private static void CollisionFenceZombie()
        {
            foreach(Entity entity in Entities)
            {
                if(entity is Fence fence)
                {
                    foreach(Entity ennemy in Entities)
                    {
                        if(ennemy is Enemy zombie)
                        {
                            if (fence.Hitbox.Intersects(zombie.Hitbox) && !fence.Destroyed)
                            {
                                if(zombie._attackCooldown <= 0)
                                {
                                    fence.takeDamage(Enemy.Damage);
                                    zombie._attackCooldown = GlobalHelpers.ZOMBIEATTACKCOOLDOWN;
                                }

                                zombie.isColliding = true;
                            }
                            else
                                zombie.isColliding = false;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Verifie les collisions entre la limite et les zombies
        /// </summary>
        private static void CollisionLimitZombie()
        {
            foreach (Entity entity in Entities)
            {
                if(entity is Enemy zombie)
                {
                    foreach(Entity entity1 in Entities)
                    {
                        if(entity1 is Limit LimitWire&& zombie.Hitbox.Intersects(LimitWire.Hitbox))
                        {
                            zombie.Destroyed = true;
                            LimitWire.takeDamage(Enemy.Damage);
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Methode qui permet de recupere le player de la liste
        /// </summary>
        /// <returns>le joueur</returns>
        private static Player GetPlayer()
        {
            foreach (Entity entity in Entities)
            {
                if (entity is Player player)
                {
                    return player;
                }
            }
            return null;
        }
        /// <summary>
        /// Methode qui detruit toutes les barricades a chaque niveau
        /// </summary>
        public static void DestroyAllFences()
        {
            foreach(Entity entity in Entities)
            {
                if(entity is Fence fence)
                {
                    fence.Destroyed= true;
                }
            }
        }
    }
}
