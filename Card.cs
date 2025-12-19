namespace GameOfWar
{
    public class Card
    {
        public string Suit { get; private set; }

        public int Rank { get; private set; }

        public Card(string suit, int rank)
        {
            Suit = suit;
            Rank = rank;
        }

        public static bool operator >(Card left, Card right)
        {
            return left.Rank > right.Rank;
        }

        public static bool operator <(Card left, Card right)
        {
            return left.Rank < right.Rank;
        }

        public string RankString()
        {
            return Deck.RankNames[Rank];
        }
    }
}
