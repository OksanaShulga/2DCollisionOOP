using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _2DCollisionOOP
{
    
    public class Game1 : Game
    {
        public static Game1 instance;
        
        GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;
        public SpriteFont font;
        Texture2D personTexture;
        Person person;
        Texture2D blockTexture;
        Block block;
        Scene scene;

        public Game1()
        {
            instance = this;
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
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
            person = new Person(personTexture)
            {
                speed = 5f                
            };

            blockTexture = Content.Load<Texture2D>("block");
            block = new Block(blockTexture)
            {
                speed = 2f                
            };

            scene = new Scene(person,block);
            
        }

      
        protected override void UnloadContent()
        {
            
        }

        
        protected override void Update(GameTime gameTime)
        {
            
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            scene.Update(gameTime);
            
            base.Update(gameTime);
        }

        
        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();

            scene.Draw(spriteBatch);
            
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
