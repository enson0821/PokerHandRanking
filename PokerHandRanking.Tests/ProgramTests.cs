using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace PokerHandRanking.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void Evaluate_RoyalFlush_CorrectResult()
        {
            // Arrange

            var hand = new List<string>() { "10h", "Jh", "Qh", "Ah", "Kh" };

            // Act

            var result = Program.PokerHandRanking(hand);

            // Assert

            Assert.AreEqual("Royal Flush", result);
        }

        [TestMethod()]
        public void Evaluate_HighCard_CorrectResult()
        {
            // Arrange

            var hand = new List<string>() { "3h", "5h", "Qs", "9h", "Ad" };

            // Act

            var result = Program.PokerHandRanking(hand);

            // Assert

            Assert.AreEqual("High Card", result);
        }

        [TestMethod()]
        public void Evaluate_FourOfAKind_CorrectResult()
        {
            // Arrange

            var hand = new List<string>() { "10s", "10c", "8d", "10d", "10h" };

            // Act

            var result = Program.PokerHandRanking(hand);

            // Assert

            Assert.AreEqual("Four of a Kind", result);
        }
    }
}