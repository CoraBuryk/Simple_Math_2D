using System;

namespace Assets.Script
{
    [Serializable]
    public class Numbers
    {
        public int Result { get; private set; }
        public int Num1 { get; set; }
        public int Num2 { get; set; }
        public int X { get; set; }
        public string MathExample { get; private set; }

        public void LevelOne()
        {
            Random random = new Random();
            Num1 = random.Next(1, 100);
            Num2 = random.Next(0, Num1);
            Result = Num1 - Num2;
        }

        public void DoLevelOne()
        {
            do
            {
                LevelOne();
            } while (Result >= 4 || Result == 0);

            MathExample = $"{Num1} - {Num2} = ?";
            LevelOne();
        }

        public void LevelTwo()
        {
            Random random = new Random();
            Num1 = random.Next(1, 100);
            Num2 = random.Next(1, Num1);
            if(Num1%Num2 == 0 && Num1 * 1 == Num2 || Num2 * 2 == Num1 || Num2 * 3 == Num1)
            {
                Result = Num1 / Num2;
            } else Result = 0;  
        }

        public void DoLevelTwo()
        {
            do
            {
                LevelTwo();
            } while (Result >= 4 || Result == 0);

            MathExample = $"{Num1} / {Num2} = ?";
            LevelTwo();
        }

        public void LevelThree()
        {
            Random random = new Random();
            Num1 = random.Next(1, 50);
            Num2 = random.Next(1, Num1);

            if ((Num1 - Num2) % 2 == 0 && 2 * 1 == (Num1 - Num2) || 2 * 2 == (Num1 - Num2) || 2 * 3 == (Num1 - Num2))
            {
                Result = (Num1 - Num2) / 2;
            }   
            else Result = 0;
        }

        public void DoLevelThree()
        {
            do
            {
                LevelThree();
            } while (Result >= 4 || Result == 0);

            MathExample = $"({Num1} - {Num2}) / 2 = ?";
            LevelThree();
        }

        public void LevelFour()
        {
            Random random = new Random();
            Num1 = random.Next(1, 50);
            Num2 = random.Next(1, Num1);
            X = random.Next(0, 3);
            Result = (Num1 - Num2) * X;
        }

        public void DoLevelFour()
        {
            do
            {
                LevelFour();
            } while (Result >= 4 || Result == 0);

            MathExample = $" ({Num1} - {Num2}) * {X} = ?";
            LevelFour();
        }
    }
}

