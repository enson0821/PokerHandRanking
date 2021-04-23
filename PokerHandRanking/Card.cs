namespace PokerHandRanking
{
    public class Card
    {
        public Suit Suit { get; }
        public Value Value { get; }

        public Card(string combination)
        {
            var cardSuit = combination.Substring(combination.Length - 1);
            switch (cardSuit)
            {
                case "s":
                    Suit = Suit.Spades;
                    break;

                case "h":
                    Suit = Suit.Hearts;
                    break;

                case "c":
                    Suit = Suit.Clubs;
                    break;

                case "d":
                    Suit = Suit.Diamonds;
                    break;

                default:
                    break;
            }

            var cardValue = combination.Remove(combination.Length - 1);
            switch (cardValue)
            {
                case "A":
                    Value = Value.Ace;
                    break;

                case "2":
                    Value = Value.Two;
                    break;

                case "3":
                    Value = Value.Three;
                    break;

                case "4":
                    Value = Value.Four;
                    break;

                case "5":
                    Value = Value.Five;
                    break;

                case "6":
                    Value = Value.Six;
                    break;

                case "7":
                    Value = Value.Seven;
                    break;

                case "8":
                    Value = Value.Eight;
                    break;

                case "9":
                    Value = Value.Nine;
                    break;

                case "10":
                    Value = Value.Ten;
                    break;

                case "J":
                    Value = Value.Jack;
                    break;

                case "Q":
                    Value = Value.Queen;
                    break;

                case "K":
                    Value = Value.King;
                    break;

                default:
                    break;
            }
        }
    }
}