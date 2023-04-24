namespace Konzole;

public class Obstacle
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string Symbol { get; set; }
        public int Speed { get; set; }

        public Obstacle(int x, int y, string symbol, int speed)
        {
            X = x;
            Y = y;
            Symbol = symbol;
            Speed = speed;
        }

        public void Draw()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(Symbol);
        }

        public void Move()
        {
            X -= Speed;
        }

        public bool CollidesWith(Player player)
        {
            return X == player.X && Y == player.Y;
        }
    }