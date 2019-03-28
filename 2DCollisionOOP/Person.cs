﻿using Microsoft.Xna.Framework;
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
        
  
        public Person(Texture2D texture):base(texture)
        {
            position.X = (Game1.instance.GraphicsDevice.Viewport.Bounds.Width - texture.Width) / 2;
            position.Y = Game1.instance.GraphicsDevice.Viewport.Bounds.Height - texture.Height;            
        }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            Move();

            
            foreach (var sprite in sprites)
            {
                if (sprite is Person)
                    continue;

                if (sprite.Rectangle.Intersects(this.Rectangle))
                {
                    this.hit = true;
                    hitScore++;
                    sprite.isRemoved = true;
                }
              
            }

            position.X = MathHelper.Clamp(position.X, 0, Game1.instance.GraphicsDevice.Viewport.Bounds.Width - texture.Width);
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
    }
}
