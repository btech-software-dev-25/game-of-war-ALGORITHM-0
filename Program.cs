using GameOfWar;

// Create and set up the game
GameState state = new GameState();
state.CardDeck.Shuffle();
state.PlayerDeck.PushCards(state.CardDeck.Deal(26));
state.ComputerDeck.PushCards(state.CardDeck.Deal(26));

// PlayCards function
static bool PlayCards(GameState state, int playerCardIndex)
{
    Card playerCard = state.PlayerDeck.PullCardAtIndex(playerCardIndex);
    Card computerCard = state.ComputerDeck.PullCardAtIndex(0);

    if (playerCard > computerCard)
    {
        // Player wins - gets both cards and any table cards
        state.PlayerDeck.PushCard(playerCard);
        state.PlayerDeck.PushCard(computerCard);
        state.PlayerDeck.PushCards(state.TableDeck.PullAllCards());
    }
    else if (computerCard > playerCard)
    {
        // Computer wins - gets both cards and any table cards
        state.ComputerDeck.PushCard(playerCard);
        state.ComputerDeck.PushCard(computerCard);
        state.ComputerDeck.PushCards(state.TableDeck.PullAllCards());
    }
    else
    {
        // Tie - both cards go to the table
        state.TableDeck.PushCard(playerCard);
        state.TableDeck.PushCard(computerCard);
    }

    // Check for winner
    if (state.ComputerDeck.Count == 0)
    {
        state.Winner = "Player";
    }
    else if (state.PlayerDeck.Count == 0)
    {
        state.Winner = "Computer";
    }

    return true;
}

// Run the game
Lib.RunGame(state, PlayCards);

namespace GameOfWar
{
    public class GameState
    {
        public Deck CardDeck { get; set; }
        public Deck PlayerDeck { get; set; }
        public Deck ComputerDeck { get; set; }
        public Deck TableDeck { get; set; }
        public string Winner { get; set; }

        public GameState()
        {
            Winner = string.Empty;
            CardDeck = new Deck();
            PlayerDeck = new Deck(null, true);
            ComputerDeck = new Deck(null, true);
            TableDeck = new Deck(null, true);
        }
    }
}