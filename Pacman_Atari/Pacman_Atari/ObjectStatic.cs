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
    class ObjectStatic
    {
        public Texture2D texture;

        protected String textureName;

        public Vector2 position;

        public Rectangle rectangle;

        public Enum.ObjectType type;

        protected Vector2 scale;

        protected Color color;

        public virtual void LoadContent(ContentManager content)
        {
            this.texture = content.Load<Texture2D>("Sprites/" + this.textureName);
        }

        public virtual void Update(GameTime gameTime)
        {
            
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(this.texture, position, Color.White);
            spriteBatch.Draw(this.texture, rectangle, color);
        }
    }
}
