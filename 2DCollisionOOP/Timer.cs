using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DCollisionOOP
{
    public class Timer
    {
        private float timer;
        public bool isRunning { get { return GetTimer(); } }
        private double startTime;

        public Timer(float timer)
        {
            this.timer = timer;
            startTime = DateTime.Now.TimeOfDay.TotalMilliseconds;            
        }
     
        private bool GetTimer ()
        {
            if ((DateTime.Now.TimeOfDay.TotalMilliseconds - startTime) >= timer)
                return false;
            else return true;            
        }
    }
}
