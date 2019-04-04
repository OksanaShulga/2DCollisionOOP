using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace _2DCollisionOOP
{
    
    public class Game1 : Game
    {
        public static Game1 instance;
        public float timer;
        
        GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;
        public SpriteFont font;

        public static Random random;

        private List<Sprite> sprites;
        private List<Texture2D> blockTextures;

        Texture2D personTexture;
        Texture2D shieldTexture;

        Person person;        

        int totalBlocks;        


        public Game1()
        {
            instance = this;
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            random = new Random();
        }

      
        protected override void Initialize()
        {
            base.Initialize();
        }

     
        protected override void LoadContent()
        {            
            spriteBatch = new SpriteBatch(GraphicsDevice);

            font = Content.Load<SpriteFont>("MyFont");
            personTexture = Content.Load<Texture2D>("man");
            blockTextures = new List<Texture2D>() { Content.Load<Texture2D>("block"), Content.Load<Texture2D>("bomb") };
            shieldTexture = Content.Load<Texture2D>("shield");

            person = new Person(personTexture, new Shield(shieldTexture))
            {
                speed = 5f
            };           

            sprites = new List<Sprite>
            {
                person
            };
        }

      
        protected override void UnloadContent()
        {
            
        }


        protected override void Update(GameTime gameTime)
        {
            timer += (float)gameTime.ElapsedGameTime.Milliseconds;

            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            foreach (var sprite in sprites)
                sprite.Update(gameTime, sprites);

            SpawnBlock();

            AccelerateBlock();

            RemoveBlock();

            base.Update(gameTime);
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
        private void RemoveBlock()
        {            
            for (var i = 0; i < sprites.Count; i++)
            {
                if (sprites[i].isRemoved)
                {
                    sprites.RemoveAt(i);
                    i--;
                    totalBlocks++;
                }
            }
        }

        // add new block in the sprite List WHEN random.NextDouble() < spawnProbability
        private void SpawnBlock()
        {
            var multiplicator = 2; //multiplicator to increase spawnProbability
            var index = random.Next(0, blockTextures.Count); //choose type of block randomly
            if (random.NextDouble() < new Block(blockTextures[index]).spawnProbability * Block.acceleration* multiplicator)
            {
                sprites.Add(new Block(blockTextures[index])
                {
                    speed = 2f
                });
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            // Change the background to red when the person was hit by a block
            if (person.hit)
            {
                graphics.GraphicsDevice.Clear(Color.Red);
                person.hit = false;
            }
            else
                graphics.GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            //Draw sprites
            foreach (var sprite in sprites)
                sprite.Draw(spriteBatch, sprites);

            //Draw table
            spriteBatch.DrawString(font, String.Format("DODGED BLOCKS  {0} : {1} TOTAL BLOCKS", (totalBlocks - person.hitScore).ToString(), totalBlocks.ToString()), new Vector2(0, 10), Color.Black);
                                  
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
