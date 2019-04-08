using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DCollisionOOP
{
    public class Scene
    {
        public float timer;
              

        public void Update (GameTime gameTime, List<Sprite> sprites)
        {
            timer += (float)gameTime.ElapsedGameTime.Milliseconds;

            foreach (var sprite in sprites)
                sprite.Update(gameTime, sprites);

            SpawnBlock(sprites);

            AccelerateBlock();

            RemoveBlock(sprites);
        }

        private void AccelerateBlock()
        {
            var step = 0.1f;
            if (timer >= 5000)
            {
                Block.acceleration += step;

                timer = 0;
            }
        }


        //remove fallen off blocks
        private void RemoveBlock(List<Sprite>sprites)
        {
            for (var i = 0; i < sprites.Count; i++)
            {
                if (sprites[i].isRemoved)
                {
                    sprites.RemoveAt(i);
                    i--;
                }
            }
        }

        
        private void SpawnBlock(List<Sprite> sprites)
        {
            var multiplicator = 2; //multiplicator to increase spawnProbability
            //var index = Game1.random.Next(0, Game1.blockTextures.Count); //choose type of block randomly
            if (Game1.random.NextDouble() < new Block(Game1.blockTextures[Game1.random.Next(0, Game1.blockTextures.Count)]).spawnProbability * Block.acceleration * multiplicator)
            {
                sprites.Add(new Block(Game1.blockTextures[Game1.random.Next(0, Game1.blockTextures.Count)])
                {
                    speed = 2f
                });
                ScoreCounter.Total++;
            }

            if (Game1.random.NextDouble() < new Present(Game1.instance.presentTexture).spawnProbability * Block.acceleration * multiplicator)
            {
                sprites.Add(new Present(Game1.instance.presentTexture)
                {
                    speed = 2f
                });
                ScoreCounter.Total++;
            }
        }

    }
}
