using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DCollisionOOP
{
    public class Shield: Sprite
    {
        private Timer timer;
        
        public bool IsActivated
            { get
                {
                    if (timer is null||!timer.isRunning)
                        return false;
                    return true;
                }
            } 
        
        public Shield(Texture2D texture):base(texture)
        {
                       
        }        

        public void Activate ()
        {
            timer = new Timer(3000);                    
        }        
    }
}
