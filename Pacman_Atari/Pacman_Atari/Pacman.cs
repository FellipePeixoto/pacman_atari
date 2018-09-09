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
        private int size = 14;

        public Pacman(Vector2 position, float speed, String textureName)
        {
            this.position = position;
            this.speed = speed;
            this.scale = 1;
            this.textureName = textureName;

            this.isAlive = true;

            walkAnimation = new Animation();
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

            Vector2 newPos = position - new Vector2(14,14);

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

            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (isAlive)
            {
                walkAnimation.Draw(spriteBatch, center, true);
                spriteBatch.Draw(texture,rectangle,Color.Red);
            }
        }

        private bool CheckCollision()
        {
            foreach (ObjectStatic i in Items.objMovList)
            {
                if (this.rectangle.Intersects(i.rectangle) && i.type == Enum.ObjectType.block)
                    return true;
            }

            return false;
        }
    }
}
