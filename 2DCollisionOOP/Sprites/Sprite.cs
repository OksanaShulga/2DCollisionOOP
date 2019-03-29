using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DCollisionOOP
{
    public class Sprite
    {
        public Texture2D texture;
        public Vector2 position;
        public Color[] colorData;
        public float speed = 0f;
        public bool isRemoved;
        public float acceleration = 1f;

        public Rectangle Rectangle { get { return new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height); } }
        
        public Sprite(Texture2D texture)
        {
            this.texture = texture;
            colorData = new Color[texture.Width*texture.Height];
            texture.GetData<Color>(colorData);
        }

        public virtual void Update(GameTime gameTime, List<Sprite> sprites)
        {
            
        }

        public virtual void Draw (SpriteBatch spriteBatch, List<Sprite> sprites)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }       
      
    }
}
