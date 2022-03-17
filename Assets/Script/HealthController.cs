using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Script
{
    [Serializable]
    public static class HealthController
    {
        public static int NumOfHeart { get; set; } = 3;
        
        public static void HealthDecreased(int num)
        {
            NumOfHeart--;
        }
        public static void RunOutOfHearts()
        {
            if(NumOfHeart == 0)
            {
                NumOfHeart = 3;
            }
        }
    }
}
