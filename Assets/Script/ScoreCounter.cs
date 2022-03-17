using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Script
{
    [Serializable]
    public class ScoreCounter
    {
        public static int Counter { get; set; }

        public static event Action ScoreDoublePlus
        {
            add
            {
                DoublePlus();
            }
            remove
            {
                DoublePlus();
            }
        }

        public static event Action ScorePlus
        {
            add
            {
                Plus();
            }
            remove
            {
                Plus();
            }
        }

        public static event Action ScoreToZero
        {
            add
            {
                ToZero();
            }
            remove
            {
                ToZero();
            }
        }

        public static void Plus()
        {                      
            Counter++;
        }

        public static void ToZero()
        { 
            Counter = 0;
        }

        public static void DoublePlus()
        {
            Counter += 2;
        }
    }
}
