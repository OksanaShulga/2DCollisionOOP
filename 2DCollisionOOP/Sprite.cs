using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DCollisionOOP
{
    public class Sprite:ICloneable
    {
        public Texture2D texture;
        public Vector2 position;
        public float speed = 0f;
        

        public Sprite(Texture2D texture)
        {
            this.texture = texture;
        }

        public virtual void Update(GameTime gameTime)
        {
            
        }

        public virtual void Draw (SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
