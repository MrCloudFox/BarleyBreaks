using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarleyBreak
{
    class History
    {
        public readonly int value;
        public readonly int valueX;
        public readonly int valueY;

        public History(int value, int valueX, int valueY)
        {
            this.value = value;
            this.valueX = valueX;
            this.valueY = valueY;
        }
    }
}
