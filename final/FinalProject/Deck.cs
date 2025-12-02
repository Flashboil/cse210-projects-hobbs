class Deck
{
    private List<Card> _library;
    private List<Card> _hand;
    private List<Card> _discard;
    private List<Card> _vessels;

    public Deck()
    {
        
    }

    public void AddToDeck(Card card)
    {
        _library.Add(card);
    }
}