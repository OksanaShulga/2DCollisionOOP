using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DCollisionOOP
{
    public class Scene
    {
        
        Person person;
        Rectangle personRectangle;
        Block block;
        List<Block> blocks = new List<Block>();
        int totalBlocks;
        int hitingBlocks;
        public float spawnProbability = 0.01f;
        Random random = new Random();

        

        public Scene(Person person, Block block)
        {
            
            this.person = person;
            this.block = block;
        }

        public void Update(GameTime gameTime)
        {
            person.Hit = false;
            SpawnBlock();

            UpdateBlockList(gameTime);

            person.Update(gameTime);

            personRectangle = new Rectangle((int)person.position.X, (int)person.position.Y, person.texture.Width, person.texture.Height);

            RectangleCollision();

            //if (person.Hit)
            //    hitingBlocks++;
      
            
            

        }

        private void SpawnBlock()
        {
           if (random.NextDouble() < spawnProbability)
            {
                var blockClone = block.Clone() as Block;
                blockClone.position.X = (float)random.NextDouble() * (Game1.instance.GraphicsDevice.Viewport.Width - block.texture.Width);
                blocks.Add(blockClone);
            }
        }

        private void UpdateBlockList(GameTime gameTime)
        {
            for (var i = 0; i < blocks.Count; i++)
            {
                blocks[i].Update(gameTime);
                
                if (blocks[i].isRemoved)
                {
                    totalBlocks++;
                    blocks.RemoveAt(i);
                    i--;
                }
            }
        }



        private void RectangleCollision()
        {
            for (var i = 0; i < blocks.Count; i++)
                if (personRectangle.Intersects(new Rectangle((int)blocks[i].position.X, (int)blocks[i].position.Y, blocks[i].texture.Width, blocks[i].texture.Height)))
                {
                    person.Hit = true;
                    return;
                }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (person.Hit)
                Game1.instance.GraphicsDevice.Clear(Color.Red);
            else
                Game1.instance.GraphicsDevice.Clear(Color.CornflowerBlue);

            person.Draw(spriteBatch);

            foreach (var block in blocks)
            {
                block.Draw(spriteBatch);
            }

            //Draw table
            //spriteBatch.DrawString(font, String.Format("DODGED BLOCKS  {0} : {1} ALL BLOCKS", (allBlocks - hitingBlocks).ToString(), allBlocks.ToString()), new Vector2(0, 0), Color.Black);
            spriteBatch.DrawString(Game1.instance.font, String.Format("TOTAL BLOCKS  {0}", totalBlocks.ToString()), new Vector2(0, 0), Color.Black);
        }
    }
}
