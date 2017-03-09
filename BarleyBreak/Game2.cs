using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BarleyBreak
{
    class Game2 : Game
    {

        public Game2(params int[] value)
            : base(value)
        {
        }


        public void ShakeValues()
        {
            Random rand = new Random();
            int count;
            int valX, valY;
            int tempInd;
            int[] a = {-1, 1};
            
            count = rand.Next(500, 1000);

            for (int i = 0; i < count; i++)
            {
                tempInd = rand.Next(-1, 2);
                valY = zeroY + tempInd;

                if (tempInd == 0) valX = zeroX + a[rand.Next(2)];
                else valX = zeroX;

                if (valX < Side && valY < Side && valX >= 0 && valY >= 0)
                {
                    Shift(this[valX, valY]);
                }
            }
        }

        public void FullSetTest()
        {
            int value = 1;
            int fullSet = 0;

            for (int i = 0; i < Side; i++)
            {
                for (int j = 0; j < Side; j++)
                {
                    if (matrix[i, j] == value)
                        fullSet++;
                    else fullSet--;
                    value++;
                }
            }

            if (fullSet == Math.Pow(Side, 2) - 2)
                Console.WriteLine("You WIN!");
        }


    }
}