class PlayerDeck : Deck
{
    public PlayerDeck() : base()
    {
        _library = new List<Card>
        {
            new Card("stoat", 1, 2, 2),
            new Card("automaton", 1, 1, 2),
            new Card("automaton", 1, 1, 2),
            new Card("wolf", 3, 2, 4),
            new Card("hound", 2, 3, 3),
            new Card("bear", 4, 6, 5)
        };
        _hand = new List<Card>();
        _discard = new List<Card>();
        _vessels = new List<Card>
        {
            new Card("vessel", 0, 1, 1),
            new Card("vessel", 0, 1, 1),
            new Card("vessel", 0, 1, 1),
            new Card("vessel", 0, 1, 1),
            new Card("vessel", 0, 1, 1)
        };
    }
}