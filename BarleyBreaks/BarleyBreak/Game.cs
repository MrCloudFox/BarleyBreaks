﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace BarleyBreak
{
    class Game
    {
        
        private double side;
        private int[,] matrix;
        private Dictionary<int, string> coordinate = new Dictionary<int, string>();

        public Game(params int[] value)
        {

            double side = Math.Sqrt(value.Length);
            bool haveZero = false;
            bool repeat;
            String coordStr;

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
                throw new Exception("Incorrect number of values or not available 0.");
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
                        coordStr = i + " " + j;
                        if (coordinate.ContainsKey(value[position]))
                            throw new Exception("Value is repeated.");
                        else coordinate.Add(value[position], coordStr);
                        position++;
                    }
                }
            }


        }


        public int this[int i, int j]
        {
            get { return matrix[i, j]; }

        }


        public String GetLocation(int value)
        {
            return coordinate[value];

        }


        private void swap(int a, int b)
        {
            int x1, y1;
            int x2, y2;
            int temp;

            String[] coord1 = GetLocation(a).Split(new char[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries);
            x1 = Int32.Parse(coord1[0]);
            y1 = Int32.Parse(coord1[1]);

            String[] coord2 = GetLocation(b).Split(new char[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries);
            x2 = Int32.Parse(coord2[0]);
            y2 = Int32.Parse(coord2[1]);

            temp = matrix[x1, y1];
            matrix[x1, y1] = matrix[x2, y2];
            matrix[x2, y2] = temp;

            coordinate.Remove(matrix[x1, y1]);
            coordinate.Remove(matrix[x2, y2]);
            coordinate.Add(matrix[x1, y1], (x1 + " " + y1));
            coordinate.Add(matrix[x2, y2], (x2 + " " + y2));

        }


        public void Shift(int value)
        {
            int x, y;
            String[] coord = GetLocation(value).Split(new char[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries);
            x = Int32.Parse(coord[0]);
            y = Int32.Parse(coord[1]);

            if(x < (side - 1) && y < (side - 1) && x != 0 && y != 0)
            {
                if (this[x + 1, y] == 0 || this[x - 1, y] == 0 ||
                    this[x, y + 1] == 0 || this[x, y - 1] == 0) swap(value, 0);
                else
                    throw new Exception("Selected incorrect value.");
            }
            else
            if(x == (side - 1) && y < (side - 1) && y > 0)
            {
                if (this[x, y + 1] == 0 || this[x - 1, y] == 0 ||
                    this[x, y - 1] == 0) swap(value, 0);
                else
                    throw new Exception("Selected incorrect value.");
            }
            else
            if(x < (side - 1) && x > 0 && y == (side - 1))
            {
                if (this[x, y - 1] == 0 || this[x + 1, y] == 0 ||
                    this[x - 1, y] == 0)
                swap(value, 0);
                else
                    throw new Exception("Selected incorrect value.");
            }
            else
            if(x == 0 && y > 0 && y < (side - 1))
            {
                if (this[x, y + 1] == 0 || this[x + 1, y] == 0 ||
                    this[x, y - 1] == 0) swap(value, 0);
                else
                    throw new Exception("Selected incorrect value.");
            }
            else
            if(x > 0 && x < (side - 1) && y == 0)
            {
                if (this[x + 1, y] == 0 || this[x - 1, y] == 0 ||
                    this[x, y + 1] == 0) swap(value, 0);
                else
                    throw new Exception("Selected incorrect value.");
            }
            else
            if(x == 0 && y == 0)
            {
                if (this[x, y + 1] == 0 || this[x + 1, y] == 0)
                    swap(value, 0);
                else
                    throw new Exception("Selected incorrect value.");
            }
            else
            if(x == (side - 1) && y == (side - 1))
            {
                if (this[x, y - 1] == 0 || this[x - 1, y] == 0)
                    swap(value, 0);
                else
                    throw new Exception("Selected incorrect value.");
            }
            else
            if(x == 0 && y == (side - 1))
            {
                if (this[x + 1, y] == 0 || this[x, y - 1] == 0)
                    swap(value, 0);
                else
                    throw new Exception("Selected incorrect value.");
            }
            else
            if(x == (side - 1) && y == 0)
            {
                if (this[x, y + 1] == 0 || this[x - 1, y] == 0)
                    swap(value, 0);
                else
                    throw new Exception("Selected incorrect value.");
            }

        }


        public void OutPutMatrix()
        {
            for(int i = 0; i < side; i++)
            {
                for(int j = 0; j < side; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }


        public void FullSetTest()
        {
            int value = 1;
            int fullSet = 0;

            for(int i = 0; i < side; i++)
            {
                for( int j = 0; j < side; j++)
                {
                    if (matrix[i, j] == value)
                        fullSet++;
                    else fullSet--;
                    value++;
                }
            }

            if (fullSet == Math.Pow(side, 2) - 2)
                Console.WriteLine("You WIN !");
        }
         

    }
}
