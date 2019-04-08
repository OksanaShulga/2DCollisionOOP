using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DCollisionOOP
{
    public static class ScoreCounter
    {
        static int total;
        static int positive;
        static int negative;
        public static int Negative { get { return negative; } set { negative = value; } }
        public static int Positive { get { return positive; } set { positive = value; } }
        public static int Total { get { return total; } set { total = value; } }
        public static int Score { get {return total - negative +positive;} }
    }
}
