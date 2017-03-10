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

            //var bb = new Game3(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 0, 15);
            
            var bb = Game3.FromCSV("test2.csv");
            int enter, steps;
            bool controlMenu = false;
           
            do
            {
                Console.Clear();
                Console.WriteLine("Enter the number which you want to move.\n");
                Console.WriteLine("Enter -1 to shake values.\n");
                Console.WriteLine("Enter -2 to see history.\n");
                Console.WriteLine("Enter -3 to FlashBack.\n");
                Console.WriteLine("Enter 0 to leave.\n");
                OutPutMatrix(bb);
                if (bb.FullSetTest()) Console.WriteLine("You WIN!!!");

                enter = int.Parse(Console.ReadLine());
                switch (enter)
                {
                    case 0:
                        controlMenu = true;
                        Console.Beep();
                        break;

                    case -1:
                        bb.ShakeValues();
                        break;

                    case -2:
                        for(int i = 0; i < bb.GetHistory.Count; i++)
                        {
                            Console.WriteLine("Value " + bb.GetHistory[i].value + 
                                " we moved on " + bb.GetHistory[i].valueX + " " + bb.GetHistory[i].valueY);
                        }
                        Console.WriteLine("Enter any key to continue.");
                        Console.ReadKey();
                        break;

                    case -3:
                        Console.WriteLine("How many steps you want roll back?");
                        steps = int.Parse(Console.ReadLine());
                        bb.FlashBackOnStep(steps);
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
            for (int i = 0; i < bb.Side; i++)
            {
                for (int j = 0; j < bb.Side; j++)
                {
                    Console.Write(String.Format("{0,2} ", bb[i, j]));
                }
                Console.WriteLine();
            }
        }


    }
}
