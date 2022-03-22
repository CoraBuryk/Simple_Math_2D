using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Script
{
    [Serializable]
    public static class Bonus
    {
        public static float TimeBonus { get; set; } = 0;

        public static void ScoreUpdate()
        {
            if (TimeBonus > 10)
            {
                ScoreCounter.ScoreDoublePlus += ScoreCounter.DoublePlus;
            }
            else if (TimeBonus <= 10)
            {
                ScoreCounter.ScorePlus += ScoreCounter.Plus;
            }
        }
    }
}
