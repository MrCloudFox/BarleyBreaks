using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;

namespace BarleyBreak
{
    class Game
    {
        
        protected double side;
        protected int[,] matrix;
        protected Dictionary<int, Tuple<int,int>> coordinate = new Dictionary<int, Tuple<int, int>>();
        protected int zeroX, zeroY;
        protected int valX, valY;

        public Game(params int[] value)
        {
            double side = Math.Sqrt(value.Length);
            bool haveZero = false;

            for(int i = 0; i < value.Length; i++)
            {
                if(value[i] == 0)
                {
                    haveZero = true;
                    break;
                }
            }


            if (side % 1 != 0 || !haveZero)
            {
                throw new ArgumentException("Incorrect number of values or not available 0.");
            }
            else
            {
                int position = 0;
                this.side = side;

                matrix = new int[Convert.ToInt32(side), Convert.ToInt32(side)];

                for (int i = 0; i < side; i++)
                {
                    for (int j = 0; j < side; j++)
                    {
                        matrix[i, j] = value[position];
                        if(value[position] == 0)
                        {
                            zeroX = i;
                            zeroY = j;
                        }
                        /*if (coordinate.ContainsKey(value[position]))
                            throw new ArgumentException("Value is repeated.");
                        else*/ coordinate.Add(value[position], Tuple.Create<int, int>(i, j));
                        position++;
                    }
                }
            }

            int val = 0;
            bool have = false;

                for (int i = 0; i < value.Length; i++)
                {
                    for(int j = 0; j < value.Length; j++)
                    {
                    if (value[j] == val)
                        have = true;
                    }

                if (!have) throw new ArgumentException("A bunch of values are not corrected.");
                have = false;
                val++;
                }
        }

        public double Side
        {
            get { return side; }
        }


        public int this[int i, int j]
        {
            get { return matrix[i, j]; }

        }


        public Tuple<int, int> GetLocation(int value)
        {
            return coordinate[value];

        }


        protected void swap(int a, int b)
        {
            int x1, y1;
            int x2, y2;
            int temp;

            x1 = GetLocation(a).Item1;
            y1 = GetLocation(a).Item2;

            x2 = GetLocation(b).Item1;
            y2 = GetLocation(b).Item2;

            temp = matrix[x1, y1];
            matrix[x1, y1] = matrix[x2, y2];
            matrix[x2, y2] = temp;

            Tuple<int, int> tupleTemp = new Tuple<int, int>(GetLocation(matrix[x1, y1]).Item1, GetLocation(matrix[x1, y1]).Item2);
            coordinate[matrix[x1, y1]] = coordinate[matrix[x2, y2]];
            coordinate[matrix[x2, y2]] = tupleTemp;

            valX = x2;
            valY = y2;
            zeroX = x1;
            zeroY = y1;

        }


        public virtual void Shift(int value)
        {
            valX = GetLocation(value).Item1;
            valY = GetLocation(value).Item2;

            if (Math.Abs(valX - zeroX) == 1 && zeroY - valY == 0 ||
                Math.Abs(valY - zeroY) == 1 && zeroX - valX == 0)
            {
                swap(value, 0);
            }
            else
            {
                throw new ArgumentException("Enter incorrect number.");
            }
        }


        public static Game FromCSV(string file)
        {
            string[] csv = File.ReadAllLines(file);
            List<int> list = new List<int>();
            for (int i = 0; i < csv.Count(); i++)
            {
                for (int j = 0; j < csv[i].Split(';').Count(); j++)
                {
                    list.Add(Convert.ToInt32(csv[i].Split(';')[j]));
                }
            }
            return new Game(list.ToArray<int>());
        }



    }
}
