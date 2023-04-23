namespace Konzole{
    
    class Enemy
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
class CarGame
    {
        private Player player;
        private int obstacleX, obstacleY;
        private bool gameover;

        public CarGame()
        {
            player = new Player
            {
                X = Console.WindowWidth / 2,
                Y = Console.WindowHeight / 2,
            };
            obstacleX = Console.WindowWidth - 1;
            obstacleY = 0;
            gameover = false;
        }

        public void Play()
{
    Console.Clear();
    Console.CursorVisible = false;
    Console.BackgroundColor = ConsoleColor.Gray;
    Console.ForegroundColor = ConsoleColor.Black;

    DateTime startTime = DateTime.Now;
    TimeSpan elapsedTime;
    int timeLimit = 10;

    while (!gameover)
    {
        Console.SetCursorPosition(player.X, player.Y);
        Console.Write(".-'--`-._");
        Console.SetCursorPosition(player.X, player.Y+1);
        Console.Write("'-O---O--'");

        if (Console.KeyAvailable)
        {
            ConsoleKeyInfo key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.UpArrow && player.Y > 1)
                player.Y--;
            else if (key.Key == ConsoleKey.DownArrow && player.Y < Console.WindowHeight - 1)
                player.Y++;
        }

        
        obstacleX--;
        if (obstacleX == player.X && obstacleY == player.Y)
        {
            gameover = true;
            Console.SetCursorPosition(Console.WindowWidth / 2 - 5, Console.WindowHeight / 2);
            Console.Write("Game Over");
        }
        if (obstacleX == 0)
        {
            obstacleX = Console.WindowWidth - 1;
            obstacleY = new Random().Next(Console.WindowHeight);
        }
        TimeSpan timeElapsed = DateTime.Now - startTime;
        Console.SetCursorPosition(Console.WindowWidth - 11, 0);
        Console.Write($"Time: {timeElapsed:mm\\:ss}");
        
        Thread.Sleep(30);
        Console.Clear();
        
        elapsedTime = DateTime.Now - startTime;
        
        if (elapsedTime.TotalSeconds >= 10)
        {
            Console.SetCursorPosition(Console.WindowWidth / 2 - 5, Console.WindowHeight / 2);
            Console.Clear();
            Console.Write("You Win!");
            Thread.Sleep(1000);
            gameover = true;
        }
        Console.SetCursorPosition(obstacleX, obstacleY);
        Console.Write("🚗");
    }
}

        
    }
}

