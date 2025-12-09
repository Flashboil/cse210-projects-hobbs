class Card : Tile
{
    private string _name;
    private int _power;
    private int _health;
    private int _cost;

    public Card(string name, int power, int health, int cost)
    {
        _visual = new List<string> {"┌───┐",$"|{power}/{health}|","└───┘"};
        _power = power;
        _health = health;
        _cost = cost;
        _name = name;
    }

    public int GetPower()
    {
        return _power;
    }

    public bool TakeDamage(int damage)
    {
        _health -= damage;

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