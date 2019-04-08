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
        private Scene scene;      
        
        GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;
        public SpriteFont font;

        public static Random random;

        public List<Sprite> sprites;
        public static List<Texture2D> blockTextures;

        Texture2D personTexture;
        Texture2D shieldTexture;
        public Texture2D presentTexture;

        Person person;        

        //public static int totalBlocks;        


        public Game1()
        {
            instance = this;
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            random = new Random();
            scene = new Scene();
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
            presentTexture = Content.Load<Texture2D>("present");

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
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();                        

            scene.Update(gameTime, sprites);

            base.Update(gameTime);
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
            spriteBatch.DrawString(font, String.Format("SCORE  {0}", ScoreCounter.Score.ToString()), new Vector2(0, 60), Color.Black);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
