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
            int[] values = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 0, 15 };
            var bb = new Game(values);
            int enter;
            bool controlMenu = false;
 
            bb.OutPutMatrix();
            Console.WriteLine();
           
            do
            {
                Console.Clear();
                Console.WriteLine("Enter the number which you want to move.\n");
                Console.WriteLine("Enter 0 to leave.");
                bb.OutPutMatrix();
                bb.FullSetTest();

                enter = int.Parse(Console.ReadLine());
                switch (enter)
                {
                    case 0:
                        controlMenu = true;
                        break;

                    default:
                        bb.Shift(enter);
                        break;

                }

            } while (!controlMenu);
        }
    }
}