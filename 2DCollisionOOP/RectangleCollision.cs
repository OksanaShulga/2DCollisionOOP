using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DCollisionOOP
{
    class RectangleCollision : ICollision
    {
        public bool CollisionDetection(Sprite spriteA, Sprite spriteB)
        {
            return spriteA.Rectangle.Intersects(spriteB.Rectangle);
        }
    }
}
