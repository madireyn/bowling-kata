using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGame
{
    public class Game
    {
        List<Frame> GameFrames = new List<Frame>();
        private const int PerfectGameScore = 300;
        private const int NumberOfBowlingFrames = 10;


        public void Roll(int firstRoll, int secondRoll)
        {
            Frame frame = new Frame(firstRoll, secondRoll);
            GameFrames.Add(frame);
        }

        public int Score()
        {
            int Total = 0;
            for (int i = 0; i < NumberOfBowlingFrames; i++)
            {
                Total += GameFrames[i].FirstRoll + GameFrames[i].SecondRoll;
                if (IsSpare(GameFrames[i]) && i < GameFrames.Count - 1)
                {
                    Total += GameFrames[i + 1].FirstRoll;
                } else if (IsStrike(GameFrames[i]) && i < GameFrames.Count - 1)
                {
                    Total += GameFrames[i + 1].FirstRoll + GameFrames[i + 1].SecondRoll;
                    if (IsStrike(GameFrames[i + 1]) &&  i < GameFrames.Count - 2)
                    {
                        Total += GameFrames[i + 2].FirstRoll;
                    }
                } 
            }
            return Total;
        }

        public bool IsStrike(Frame frame)
        {
            return frame.FirstRoll == 10;
        }

        public bool IsSpare(Frame frame)
        {
            return frame.FirstRoll != 10 && frame.FirstRoll + frame.SecondRoll == 10;
        }
    }
}
