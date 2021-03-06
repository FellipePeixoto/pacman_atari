﻿#region using
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
#endregion


namespace Pacman_Atari
{
    class Pacman : Object
    {
        private KeyboardState currentKeyBoardState;
        private Animation walkAnimation;
        private int distance = 1;
        private int size = 15;
        private Vector2 newPos;
        private Vector2 diff = new Vector2(15, 15);
        public static int score = 0;
        private Rectangle pacmanCollider;
        private Enum.Direction dir;
        private Enum.Direction nextDir;

        public Pacman(Vector2 position, float speed, String textureName, String debugTextureName)
        {
            this.position = position;
            this.speed = speed;
            this.scale = 1;
            this.textureName = textureName;
            this.debugTextureName = debugTextureName;

            this.isAlive = true;

            dir = Enum.Direction.stopped;
            nextDir = Enum.Direction.stopped;

            walkAnimation = new Animation();

            score = 0;
        }

        public override void LoadContent(ContentManager content)
        {
            base.LoadContent(content);

            walkAnimation.Inatialize(texture, position, 14, 14, 4, 200, Color.White, scale, true, 0);

            center = new Vector2(walkAnimation.frameWidth / 2, walkAnimation.frameHeight / 2);
        }

        public override void Update(GameTime gameTime)
        {
            if (!isAlive)
                return;

            currentKeyBoardState = Keyboard.GetState();
            newPos = position - diff;

            #region movement
            if (currentKeyBoardState.IsKeyDown(Keys.Up))
            {
                colliderDetection = new Rectangle((int)newPos.X, (int)newPos.Y - distance, size, distance);
                if (!CheckCollision())
                    dir = Enum.Direction.up;
                else
                    nextDir = Enum.Direction.up;
            }
            else if (currentKeyBoardState.IsKeyDown(Keys.Down))
            {
                colliderDetection = new Rectangle((int)newPos.X, (int)newPos.Y + distance + size, size, distance);
                if (!CheckCollision())
                    dir = Enum.Direction.down;
                else
                    nextDir = Enum.Direction.down;
            }
            else if (currentKeyBoardState.IsKeyDown(Keys.Right))
            {
                colliderDetection = new Rectangle((int)newPos.X + distance + size, (int)newPos.Y, distance, size);
                if (!CheckCollision())
                    dir = Enum.Direction.right;
                else
                    nextDir = Enum.Direction.right;
            }
            else if (currentKeyBoardState.IsKeyDown(Keys.Left))
            {
                colliderDetection = new Rectangle((int)newPos.X - distance, (int)newPos.Y, distance, size);
                if (!CheckCollision())
                    dir = Enum.Direction.left;
                else
                    nextDir = Enum.Direction.left;
            }

            switch (dir)
            {
                case Enum.Direction.up:
                    colliderDetection = new Rectangle((int)newPos.X, (int)newPos.Y - distance, size, distance);
                    if (!CheckCollision())
                        position.Y -= speed;
                    break;

                case Enum.Direction.right:
                    colliderDetection = new Rectangle((int)newPos.X + distance + size, (int)newPos.Y, distance, size);
                    if (!CheckCollision())
                        position.X += speed;
                    break;

                case Enum.Direction.down:
                    colliderDetection = new Rectangle((int)newPos.X, (int)newPos.Y + distance + size, size, distance);
                    if (!CheckCollision())
                        position.Y += speed;
                    break;

                case Enum.Direction.left:
                    colliderDetection = new Rectangle((int)newPos.X - distance, (int)newPos.Y, distance, size);
                    if (!CheckCollision())
                        position.X -= speed;
                    break;
            } 
            #endregion

            if (position.Y < 0)
                position = new Vector2(((int)Game1.screenWidth / 2) + 7, (int)Game1.screenHeight-20);

            if (position.Y > Game1.screenHeight - 20)
                position = new Vector2(((int)Game1.screenWidth / 2) + 7, 0);

            walkAnimation.position = position;
            walkAnimation.Update(gameTime);

            pacmanCollider = new Rectangle((int)newPos.X + 4, (int)newPos.Y + 4, 7, 7);

            if (CheckCollision(Enum.ObjectType.dot, true))
                score++;
            if (CheckCollision(Enum.ObjectType.pill, true))
                score += 5;

            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (isAlive)
            {
                walkAnimation.Draw(spriteBatch, center, true);
            }
        }

        /// <summary>
        /// Checa a colisão contra objeto solido
        /// </summary>
        /// <returns></returns>
        private bool CheckCollision()
        {
            foreach (ObjectStatic i in Items.objMovList)
            {
                if (i != null && colliderDetection.Intersects(i.rectangle) &&
                    (i.type == Enum.ObjectType.block || i.type == Enum.ObjectType.ghost))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Checar colisão contra objeto especifico
        /// </summary>
        /// <param name="type">Enumerador dos tipos de entidades no mapa</param>
        /// <returns>Verdadeiro caso o há colisão</returns>
        private bool CheckCollision(Enum.ObjectType type, bool destroy)
        {
            foreach (ObjectStatic i in Items.objMovList)
            {
                if (i != null && pacmanCollider.Intersects(i.rectangle) &&
                    (i.type == type))
                {
                    if (destroy)
                        Items.objMovList[Items.objMovList.IndexOf(i)] = null;
                    return true;
                }
            }
            return false;
        }
    }
}
