using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FakeItEasy;
using Microsoft.Xna.Framework;

namespace _2DCollisionOOP.Test
{
    [TestClass]
    public class RectangleCollisionTest
    {

        [TestMethod]
        public void TestRectangleCollisionNotHappens()
        {
            RectangleCollision collision = new RectangleCollision();

            Sprite square = A.Fake<Sprite>();
            Sprite dot = A.Fake<Sprite>();

            A.CallTo(() => square.Rectangle).Returns(new Rectangle(0, 0, 10, 10));
            A.CallTo(() => dot.Rectangle).Returns(new Rectangle(11, 11, 1, 1));

            Assert.IsFalse(collision.CollisionDetection(square, dot));
        }

        [TestMethod]
        public void TestRectangleCollisionHappens()
        {
            RectangleCollision collision = new RectangleCollision();

            Sprite square = A.Fake<Sprite>();
            Sprite dot = A.Fake<Sprite>();

            A.CallTo(() => square.Rectangle).Returns(new Rectangle(0, 0, 10, 10));
            A.CallTo(() => dot.Rectangle).Returns(new Rectangle(5, 5, 1, 1));

            Assert.IsTrue(collision.CollisionDetection(square, dot));
        }
    }
}
