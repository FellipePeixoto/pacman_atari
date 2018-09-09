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
    class Object
    {
        protected Texture2D texture;

        protected String textureName;

        protected Vector2 position;

        protected float scale;

        protected Vector2 center;

        protected float speed;

        protected Rectangle rectangle;

        protected bool isAlive = false; 

        #region XNA framework methods
        public virtual void LoadContent(ContentManager content)
        {
            // load da textura
            this.texture = content.Load<Texture2D>("Sprites/" + this.textureName);
        }

        public virtual void Update(GameTime gameTime)
        {
            
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        } 
        #endregion
    }
}
