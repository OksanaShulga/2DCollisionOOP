using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DCollisionOOP
{
    public class Present:Block
    {
        public float spawnProbability = 0.001f;
        
        public Present(Texture2D texture):base(texture)
        {
            
        }

       
    }
}
