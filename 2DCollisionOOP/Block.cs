using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DCollisionOOP
{
    public class Block:Sprite
    {
        
        public float acceleration;
        public float spawnProbability = 0.01f;

        public Block(Texture2D texture):base(texture)
        {
            position = new Vector2 ((float)Game1.random.NextDouble() * (Game1.instance.GraphicsDevice.Viewport.Width - texture.Width),-texture.Height);
        }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            position.Y += speed;

            //isRemoved
            if (Rectangle.Bottom >= Game1.instance.GraphicsDevice.Viewport.Bounds.Height)
                isRemoved = true;
        }
    }
}
