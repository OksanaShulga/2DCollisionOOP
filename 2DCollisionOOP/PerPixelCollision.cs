using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DCollisionOOP
{
    class PerPixelCollision : ICollision
    {
        public bool CollisionDetection(Sprite spriteA, Sprite spriteB)
        {
            // Find the bounds of the rectangle intersection
            int top = Math.Max(spriteA.Rectangle.Top, spriteB.Rectangle.Top);
            int bottom = Math.Min(spriteA.Rectangle.Bottom, spriteB.Rectangle.Bottom);
            int left = Math.Max(spriteA.Rectangle.Left, spriteB.Rectangle.Left);
            int right = Math.Min(spriteA.Rectangle.Right, spriteB.Rectangle.Right);

            // Check every point within the intersection bounds
            for (int y = top; y < bottom; y++)
            {
                for (int x = left; x < right; x++)
                {
                    // Get the color of both pixels at this point
                    //(x,y) get local regarding to rectangle by substracting Left Top Corner of Rectangle.
                    //(y) multiplying to the Width, gets rows switched
                    Color colorA = spriteA.colorData[(x - spriteA.Rectangle.Left) + (y - spriteA.Rectangle.Top) * spriteA.Rectangle.Width];
                    Color colorB = spriteB.colorData[(x - spriteB.Rectangle.Left) + (y - spriteB.Rectangle.Top) * spriteB.Rectangle.Width];

                    // If both pixels are not completely transparent,
                    if (colorA.A != 0 && colorB.A != 0)
                    {
                        // then an intersection has been found
                        return true;
                    }
                }
            }

            // No intersection found
            return false;
        }
    }
}
