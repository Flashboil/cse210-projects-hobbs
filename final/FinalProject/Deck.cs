class Deck
{
    protected List<Card> _library;
    protected List<Card> _hand;
    protected List<Card> _discard;
    protected List<Card> _vessels;

    public Deck()
    {
        _library = new List<Card>();
        _hand = new List<Card>();
        _discard = new List<Card>();
        _vessels = new List<Card>();
    }

    public void AddToDeck(Card card)
    {
        _library.Add(card);
    }

    public void DrawCard()
    {
        Random random = new Random(); 
        int index = random.Next(_library.Count); 
        Card randomItem = _library[index];
        
        _library.Remove(randomItem);
        _hand.Add(randomItem);
    }

    public void DrawHand()
    {
        for (int draw = 0; draw < 4; draw++)
        {  
            DrawCard();
        }
    }

    public void RenderHand()
    {
        for (int line = 0; line < 3; line++)
        {
            foreach (Tile t in _hand)
            {
                t.PrintVisual(line);
            }   
            Console.WriteLine();
        }
    }

    public Card CardFromHand(int index)
    {
        return _hand[index];
    }

    public void Discard(int index)
    {
        Card card = _hand[index];
        _hand.Remove(card);
        _discard.Add(card);
    }
}