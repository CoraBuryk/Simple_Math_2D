using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Script
{
    [System.Serializable]
    public class Numbers
    {
        public int Result { get; set; }
        public int Num1 { get; set; }
        public int Num2 { get; set; }
        public string MathExample { get; set; }

        public void Subtraction()
        {
            Random random = new Random();
            Num1 = random.Next(1, 100);
            Num2 = random.Next(0, Num1);
            Result = Num1 - Num2;
        }

        public void DoSubtraction()
        {
            do
            {
                Subtraction();
            } while (Result >= 4 || Result == 0);

            MathExample = $"{Num1} - {Num2} = ?";
            Subtraction();
        }

        public void Division()
        {
            Random random = new Random();
            Num1 = random.Next(2, 100);
            Num2 = random.Next(2, Num1);
            if(Num1%Num2 == 0 && Num2 * 1 == Num1 || Num2 * 2 == Num1 || Num2 * 3 == Num1)
            {
                Result = Num1 / Num2;
            } else Result = 0;  
        }

        public void DoDivision()
        {
            do
            {
                Division();
            } while (Result >= 4 || Result == 0);

            MathExample = $"{Num1} / {Num2} = ?";
            Division();
        }

        public void SubtractionUp()
        {
            Random random = new Random();
            Num1 = random.Next(100, 1000);
            Num2 = random.Next(100, Num1);
            Result = Num1 - Num2;
        }

        public void DoSubtractionUp()
        {
            do
            {
                SubtractionUp();
            } while (Result >= 4 || Result == 0);

            MathExample = $"{Num1} - {Num2} = ?}";
            SubtractionUp();
        }

        public void DivisionUp()
        {
            Random random = new Random();
            Num1 = random.Next(50, 500);
            Num2 = random.Next(50, Num1);
            if (Num1 % Num2 == 0 && Num2 * 1 == Num1 || Num2 * 2 == Num1 || Num2 * 3 == Num1)
            {
                Result = Num1 / Num2;
            }else Result = 0;
        }

        public void DoDivisionUp()
        {
            do
            {
                DivisionUp();
            } while (Result >= 4 || Result == 0);

            MathExample = $"{Num1} / {Num2} = ?";
            DivisionUp();
        }
    }
}

