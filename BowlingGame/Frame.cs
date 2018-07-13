using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGame
{
    public class Frame
    {
        public Frame(int firstRoll, int secondRoll)
        {
            FirstRoll = firstRoll;
            SecondRoll = secondRoll;
        }
        public int FirstRoll { get; set; }
        public int SecondRoll { get; set; }

        // public bool Spare => FirstRoll != 10 && FirstRoll + SecondRoll == 10;
        public bool Spare { get; }

        // public bool Strike => FirstRoll == 10;
        public bool Strike { get; }
    }
}
