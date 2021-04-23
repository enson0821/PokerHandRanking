using System.Collections.Generic;
using System.Linq;

namespace PokerHandRanking
{
    public class Hand
    {
        public IEnumerable<Card> Cards { get; }

        public bool Contains(Value value)
        {
            return Cards.Any(x => x.Value == value);
        }

        public bool IsPair
        {
            get
            {
                return Cards.GroupBy(x => x.Value)
                    .Count(x => x.Count() == 2) == 1;
            }
        }

        public bool IsTwoPair
        {
            get
            {
                return Cards.GroupBy(x => x.Value)
                    .Count(x => x.Count() == 2) == 2;
            }
        }

        public bool IsThreeOfAKind
        {
            get
            {
                return Cards.GroupBy(x => x.Value)
                    .Any(x => x.Count() == 3);
            }
        }

        public bool IsFourOfAKind
        {
            get
            {
                return Cards.GroupBy(x => x.Value)
                    .Any(x => x.Count() == 4);
            }
        }

        public bool IsFlush
        {
            get
            {
                return Cards.GroupBy(x => x.Suit).Count() == 1;
            }
        }

        public bool IsFullHouse
        {
            get
            {
                return IsPair && IsThreeOfAKind;
            }
        }

        public bool IsStraight
        {
            get
            {
                // If there is an Ace, we have to handle the 10,J,Q,K,A case, which isn't handled by the code
                // below because Ace is normally 0
                if (Contains(Value.Ace) &&
                    Contains(Value.King) &&
                    Contains(Value.Queen) &&
                    Contains(Value.Jack) &&
                    Contains(Value.Ten))
                {
                    return true;
                }

                var ordered = Cards.OrderBy(h => h.Value).ToArray();
                var straightStart = (int)ordered.First().Value;
                for (var i = 1; i < ordered.Length; i++)
                {
                    if ((int)ordered[i].Value != straightStart + i)
                        return false;
                }

                return true;
            }
        }

        public bool IsStraightFlush
        {
            get
            {
                return IsStraight && IsFlush;
            }
        }

        public bool IsRoyalFlush
        {
            get
            {
                return IsStraightFlush && Contains(Value.Ace) && Contains(Value.King);
            }
        }

        public Hand(IEnumerable<Card> cards)
        {
            Cards = cards;
        }

        public string Evaluate()
        {
            if (IsRoyalFlush)
                return "Royal Flush";

            if (IsStraightFlush)
                return "Straight Flush";

            if (IsFourOfAKind)
                return "Four of a Kind";

            if (IsFullHouse)
                return "Full House";

            if (IsFlush)
                return "Flush";

            if (IsStraight)
                return "Straight";

            if (IsThreeOfAKind)
                return "Three of a Kind";

            if (IsTwoPair)
                return "Two Pair";

            if (IsPair)
                return "Pair";

            return "High Card";
        }
    }
}