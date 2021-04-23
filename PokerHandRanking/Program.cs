using System;
using System.Collections.Generic;
using System.Linq;

namespace PokerHandRanking
{
    public static class Program
    {
        public static void Main()
        {
        }

        public static string PokerHandRanking(List<string> hand)
        {
            var handCards = new Hand(hand.ConvertAll(x => new Card(x)));

            return handCards.Evaluate();
        }
    }
}
