using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DCollisionOOP
{
    public class Person:Sprite
    {
        public bool hit;
        public int hitScore;
        public Timer timerToMakePlayerInvincible;
        private Shield shield;
       

        public Person(Texture2D texture, Shield shield):base(texture)
        {
            position.X = (Game1.instance.GraphicsDevice.Viewport.Bounds.Width - texture.Width) / 2;
            position.Y = Game1.instance.GraphicsDevice.Viewport.Bounds.Height - texture.Height;
            this.shield = shield;            
        }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Space)&&!shield.IsActivated)
            {
                shield.Activate();
                shield.position.X = this.position.X - 10;
                shield.position.Y = this.position.Y;                
            }

            if (!shield.IsActivated)
            { 
                if (timerToMakePlayerInvincible is null || !timerToMakePlayerInvincible.isRunning)
                {
                    Move();

                    CheckForCollision(sprites);
                }
            }

            position.X = MathHelper.Clamp(position.X, 0, Game1.instance.GraphicsDevice.Viewport.Bounds.Width - texture.Width);
        }

        private void CheckForCollision(List<Sprite> sprites)
        {
            foreach (var sprite in sprites)
            {
                if (sprite is Person)
                    continue;

                if (new PerPixelCollision().CollisionDetection(this, sprite))
                {
                    this.hit = true;
                    timerToMakePlayerInvincible = new Timer(3000); //timer to freeze Player for set time in miliseconds
                    hitScore++;
                    sprite.isRemoved = true;
                }
            }
        }

        private void Move()
        {
            // Move the Object left and right with arrow keys or d-pad
            if (Keyboard.GetState().IsKeyDown(Keys.Left) || GamePad.GetState(PlayerIndex.One).DPad.Left == ButtonState.Pressed)
            {
                position.X -= speed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right) || GamePad.GetState(PlayerIndex.One).DPad.Right == ButtonState.Pressed)
            {
                position.X += speed;
            }
        }

       
        public override void Draw (SpriteBatch spriteBatch, List<Sprite> sprites)
        {
            spriteBatch.Draw(texture, position, Color.White);
            
            if(shield.IsActivated)
                spriteBatch.Draw(shield.texture, shield.position, Color.White);
        }
    }
}
