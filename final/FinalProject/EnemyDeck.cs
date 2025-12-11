class EnemyDeck : Deck
{
    public EnemyDeck() : base()
    {
        _library = new List<Card>
        {
            new Card("stoat", 1, 2, 2),
            new Card("automaton", 1, 1, 2),
            new Card("automaton", 1, 1, 2),
            new Card("wolf", 3, 2, 4),
            new Card("wolf", 3, 2, 4),
            new Card("hound", 2, 3, 3),
        };
    }
}