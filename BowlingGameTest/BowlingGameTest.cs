using System;
using NUnit.Framework;
using BowlingGame;

namespace BowlingGameTest
{
    [TestFixture]
    public class BowlingGameTest
    {
        private Game g;

        [SetUp]
        protected void SetUp()
        {
            g = new Game();
        }

        [Test]
        public void TestGutterGame()
        {
            RollFrame(0 ,0, 10);

            Assert.AreEqual(g.Score(), 0);
        }

        private void RollFrame(int firstRoll, int secondRoll, int numberOfFrames)
        {
            for (int i = 0; i < numberOfFrames; i++)
                g.Roll(firstRoll, secondRoll);
        }

        [Test]
        public void TestAllOnes()
        {
            RollFrame(1, 1, 10);
            Assert.AreEqual(20, g.Score());
        }

        [Test]
        public void TestOneSpare()
        {
            g.Roll(5, 5);
            g.Roll(3, 1);
            RollFrame(1, 1, 8);
            Assert.AreEqual(33, g.Score());
        }

        private void RollStrike()
        {
            g.Roll(10, 0);
        }

        [Test]
        public void TestOneStrike()
        {
            RollStrike();
            g.Roll(3, 1);
            g.Roll(4, 2);
            RollFrame(1, 1, 7);
            Assert.AreEqual(38, g.Score());
        }

        [Test]
        public void TestPerfectGame()
        {
            RollFrame(10, 0, 12);
            Assert.AreEqual(300, g.Score());
        }
    }
}
