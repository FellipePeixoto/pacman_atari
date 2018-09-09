#region using
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
        private int size = 16;
        private Vector2 newPos;
        private Vector2 diff = new Vector2(15, 15);
        public static int score = 0;
        private Rectangle centerRec;

        public Pacman(Vector2 position, float speed, String textureName, String debugTextureName)
        {
            this.position = position;
            this.speed = speed;
            this.scale = 1;
            this.textureName = textureName;
            this.debugTextureName = debugTextureName;

            this.isAlive = true;

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

            if (currentKeyBoardState.IsKeyDown(Keys.Up))
            {
                rectangle = new Rectangle((int)newPos.X, (int)newPos.Y - distance, size, distance);
                if (!CheckCollision())
                    position.Y -= speed;
            }
            else if (currentKeyBoardState.IsKeyDown(Keys.Down))
            {
                rectangle = new Rectangle((int)newPos.X, (int)newPos.Y + distance + size, size, distance);
                if (!CheckCollision())
                    position.Y += speed;
            }
            else if (currentKeyBoardState.IsKeyDown(Keys.Right))
            {
                rectangle = new Rectangle((int)newPos.X + distance + size, (int)newPos.Y, distance, size);
                if (!CheckCollision())
                    position.X += speed;
            }
            else if (currentKeyBoardState.IsKeyDown(Keys.Left))
            {
                rectangle = new Rectangle((int)newPos.X - distance, (int)newPos.Y, distance, size);
                if (!CheckCollision())
                    position.X -= speed;
            }

            walkAnimation.position = position;
            walkAnimation.Update(gameTime);

            centerRec = new Rectangle((int)newPos.X, (int)newPos.Y, 16, 16);

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
                spriteBatch.Draw(debugTexture, centerRec, Color.Red);
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
                if (i != null && this.rectangle.Intersects(i.rectangle) &&
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
                if (i != null && centerRec.Intersects(i.rectangle) &&
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
