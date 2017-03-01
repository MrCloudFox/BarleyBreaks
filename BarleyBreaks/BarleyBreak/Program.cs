using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BarleyBreak
{
    class Program
    {
        static void Main(string[] args)
        {

            //var bb = new Game(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 0, 15);
            
            var bb = Game.FromCSV("test1.csv");
            int enter;
            bool controlMenu = false;

            OutPutMatrix(bb);
            Console.WriteLine();
           
            do
            {
                Console.Clear();
                Console.WriteLine("Enter the number which you want to move.\n");
                Console.WriteLine("Enter 0 to leave.");
                OutPutMatrix(bb);
                bb.FullSetTest();

                enter = int.Parse(Console.ReadLine());
                switch (enter)
                {
                    case 0:
                        controlMenu = true;
                        Console.Beep();
                        break;

                    default:
                        bb.Shift(enter);
                        Console.Beep();
                        break;

                }

            } while (!controlMenu);
        }


        public static void OutPutMatrix(Game bb)
        {
            for (int i = 0; i < bb.side; i++)
            {
                for (int j = 0; j < bb.side; j++)
                {
                    Console.Write(String.Format("{0,2} ", bb[i, j]));
                }
                Console.WriteLine();
            }
        }


    }
}