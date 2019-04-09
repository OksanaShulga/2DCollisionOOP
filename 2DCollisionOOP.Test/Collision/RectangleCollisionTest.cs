using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using NUnit.Framework;

namespace _2DCollisionOOP
{
    public class RectangleCollisionTest
    {
        ContentManager content;

        [SetUp]
        public void Setup()
        {
            //content = new ContentManager(null, "Content");
            
        }

        [Test]
        public void TestCollision()
        {
            RectangleCollision collision = new RectangleCollision();
            Sprite square = new Sprite();// content.Load<Texture2D>("shield"));
            Sprite dot = new Sprite();// content.Load<Texture2D>("dot"));
            Assert.IsTrue( collision.CollisionDetection(square, dot) );
        }
    }
}