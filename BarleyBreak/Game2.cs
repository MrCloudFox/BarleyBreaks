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
            int pos;
            List<int> vals = new List<int>();

            for(int i = 0; i < Side; i++)
            {
                for(int j = 0; j < Side; j++)
                {
                    vals.Add(matrix[i, j]);
                }
            }

            for (int i = 0; i < Side; i++)
            {
                for (int j = 0; j < Side; j++)
                {
                    pos = rand.Next(0, vals.Count);
                    matrix[i, j] = vals[pos];
                    vals.RemoveAt(pos);
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