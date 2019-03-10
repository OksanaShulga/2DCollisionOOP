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
        public bool isRemoved;

        public Block(Texture2D texture):base(texture)
        {
            
        }

        public override void Update(GameTime gameTime)
        {
            position.Y += speed;

            //isRemoved
            if (position.Y == Game1.instance.GraphicsDevice.Viewport.Bounds.Height)
                isRemoved = true;
        }

    }
}
