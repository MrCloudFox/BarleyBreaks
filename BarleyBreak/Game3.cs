using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BarleyBreak
{
    class Game3: Game2
    {
        private List<History> history = new List<History>();
        private bool RollBackFlag = false;


        public Game3(params int[] value)
           : base(value)
        {
        }


        public virtual void Shift(int value)
        {
            valX = GetLocation(value).Item1;
            valY = GetLocation(value).Item2;

            if (Math.Abs(valX - zeroX) == 1 && zeroY - valY == 0 ||
                Math.Abs(valY - zeroY) == 1 && zeroX - valX == 0)
            {
                swap(value, 0);

                if(!RollBackFlag)
                    history.Add(new History(value,GetLocation(value).Item1, GetLocation(value).Item2));
            }
            else
            {
                throw new ArgumentException("Enter incorrect number.");
            }
        }


        public void FlashBackOnStep(int value)
        {
            if (history.Count < value)
                throw new ArgumentException("Enter incorrect number of steps.");

            int counter = history.Count - 1;
            RollBackFlag = true;

            for (int i = value; i > 0; i--)
            {
                Shift(history[counter].value);
                history.RemoveAt(counter);
                counter--;
            }
            RollBackFlag = false;
        }


        public List<History> GetHistory
        {
            get
            {
                return history;
            }
        }

        new public static Game3 FromCSV(string file)
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
            return new Game3(list.ToArray<int>());
        }
    }
}
