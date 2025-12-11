class Card : Tile
{
    private string _name;
    private int _power;
    private int _health;
    private int _cost;

    public Card(string name, int power, int health, int cost)
    {
        _visual = new List<string> {$"{cost}───┐",$"|{power}/{health}|","└───┘"};
        _power = power;
        _health = health;
        _cost = cost;
        _name = name;
    }

    public int GetCost()
    {
        return _cost;
    }
    public override int GetPower()
    {
        return _power;
    }

    public bool TakeDamage(int damage)
    {
        _health -= damage;

        UpdateVisual(new List<string> {$"{_cost}───┐",$"|{_power}/{_health}|","└───┘"});

        if (_health <= 0)
        {
            return false;
        }
        else
        {
            return true;
        }

    }
}