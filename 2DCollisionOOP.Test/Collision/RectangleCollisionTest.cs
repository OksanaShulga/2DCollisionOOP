using NUnit.Framework;

namespace _2DCollisionOOP
{
    public class RectangleCollisionTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestCollision()
        {
            RectangleCollision collision = new RectangleCollision();
            Assert.Pass();
        }
    }
}