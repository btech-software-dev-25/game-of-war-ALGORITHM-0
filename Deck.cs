namespace GameOfWar
{
    public class Deck
    {
        public static string[] RankNames =
        {
            "2", "3", "4", "5", "6", "7", "8", "9", "10",
            "Jack", "Queen", "King", "Ace"
        };

        public static string[] Suits =
        {
            "Hearts", "Diamonds", "Clubs", "Spades"
        };

        public int Count => _cards.Count;

        private List<Card> _cards;

        public Deck(List<Card>? cards = null, bool isEmptyDeck = false)
        {
            if (cards != null && cards.Count > 0)
            {
                _cards = cards;
            }
            else
            {
                _cards = new List<Card>();
                if (!isEmptyDeck)
                {
                    InitializeDeck();
                }
            }
        }

        private void InitializeDeck()
        {
            for (int suitIndex = 0; suitIndex < Suits.Length; suitIndex++)
            {
                for (int rankIndex = 0; rankIndex < RankNames.Length; rankIndex++)
                {
                    _cards.Add(new Card(Suits[suitIndex], rankIndex));
                }
            }
        }

        public void Shuffle()
        {
            Random rng = new Random();
            int n = _cards.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Card temp = _cards[k];
                _cards[k] = _cards[n];
                _cards[n] = temp;
            }
        }

        public Card CardAtIndex(int index)
        {
            if (index < 0 || index >= _cards.Count)
            {
                throw new IndexOutOfRangeException();
            }
            return _cards[index];
        }

        public Card PullCardAtIndex(int index)
        {
            if (index < 0 || index >= _cards.Count)
            {
                throw new IndexOutOfRangeException();
            }
            Card card = _cards[index];
            _cards.RemoveAt(index);
            return card;
        }

        public List<Card> PullAllCards()
        {
            List<Card> allCards = new List<Card>(_cards);
            _cards.Clear();
            return allCards;
        }

        public void PushCard(Card card)
        {
            _cards.Add(card);
        }

        public void PushCards(List<Card> cards)
        {
            _cards.AddRange(cards);
        }

        public List<Card> Deal(int count)
        {
            int cardsToDeal = Math.Min(count, _cards.Count);
            List<Card> dealtCards = _cards.GetRange(0, cardsToDeal);
            _cards.RemoveRange(0, cardsToDeal);
            return dealtCards;
        }
    }
}
