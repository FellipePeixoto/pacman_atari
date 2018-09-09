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
        #region Protected variables
        /// <summary>
        /// Sprite/textura do objeto
        /// </summary>
        protected Texture2D texture;

        /// <summary>
        /// Nome do arquivo de textura
        /// </summary>
        protected String textureName;

        /// <summary>
        /// Posicao do objeto
        /// </summary>
        protected Vector2 position;

        /// <summary>
        /// Escala do objeto
        /// </summary>
        protected float scale;

        /// <summary>
        /// Centro do objeto
        /// </summary>
        protected Vector2 center;

        protected float speed;

        protected Rectangle rectangle;

        /// <summary>
        /// Indica se o objeto ainda está vivo
        /// </summary>
        protected bool isAlive = false; 
        #endregion

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
