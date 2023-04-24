namespace Konzole;

public class Enemy
{
    public int X { get; set; }
    public int Y { get; set; }
    public string Symbol { get; set; }

    public Enemy(int x, int y, string symbol = "🐍")
    {
        X = x;
        Y = y;
        Symbol = symbol;
    }
}