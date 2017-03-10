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
            int count = rand.Next(Convert.ToInt32(Side) * 10, Convert.ToInt32(Side) * 20); ;
            int valX, valY;
            int tempInd;
            int[] a = {-1, 1};
            int[] coordRandom = new int[2];
            int coord1, coord2;

            for (int i = 0; i < count; i++)
            {

                tempInd = rand.Next(-1, 2);
                valY = zeroY + tempInd;

                if (tempInd == 0) valX = zeroX + a[rand.Next(2)];
                else valX = zeroX;

                coordRandom[0] = valX;
                coordRandom[1] = valY;
                coord1 = coordRandom[rand.Next(1)];
                if (coord1 == valX) coord2 = valY;
                else coord2 = valX;

                if (valX < Side && valY < Side && valX >= 0 && valY >= 0)
                {
                    Shift(this[coord1, coord2]);
                }
            }
        }


        public bool FullSetTest()
        {
            int value = 1;
            bool flag = true;
            if(matrix[Convert.ToInt32(Side) - 1, Convert.ToInt32(Side) - 1] != 0)
                return false;

            for (int i = 0; i < Side; i++)
            {
                for (int j = 0; j < Side; j++)
                {
                    if (matrix[i, j] != value)
                    {
                        flag = false;
                        break;
                    }
                        value++;
                }
                if (!flag) break;
            }

            if (value == Side * Side)
                return true;

            return flag;
        }


    }
}