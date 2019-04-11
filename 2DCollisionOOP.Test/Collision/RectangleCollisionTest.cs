using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace _2DCollisionOOP.Test
{
    [TestClass]
    public class RectangleCollisionTest
    {

        [TestMethod]
        public void TestRectangleCollision()
        {
            RectangleCollision collision = new RectangleCollision();

            Sprite square = new Sprite();
            Sprite dot = new Sprite();
            Assert.IsTrue(collision.CollisionDetection(square, dot));
        }
    }
    /*
    public class TestSprite : Sprite
    {
        public new Rectangle Rectangle { get  { return new Rectangle(0, 0, 10, 10); } }

    } */
}
