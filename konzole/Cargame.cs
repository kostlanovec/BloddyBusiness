namespace Konzole{
    
using System;
using System.Collections.Generic;
using System.Threading;

namespace Konzole
{

    class CarGame
    {

        
        private Player player;
        private List<Obstacle> obstacles;
        private bool gameover;

        public CarGame()
        {
            player = new Player
            {
                X = Console.WindowWidth / 2,
                Y = Console.WindowHeight / 2,
            };
            obstacles = new List<Obstacle>();
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
    int spawnInterval = 40;
    int spawnTimer = 0;
    int obstacleSpeed = 1;

    while (!gameover)
    {
        Console.SetCursorPosition(player.X, player.Y);
        Console.Write(".-'--`-._");
        Console.SetCursorPosition(player.X, player.Y + 1);
        Console.Write("'-O---O--'");

        if (Console.KeyAvailable)
        {
            ConsoleKeyInfo key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.UpArrow && player.Y > 1)
                player.Y--;
            else if (key.Key == ConsoleKey.DownArrow && player.Y < Console.WindowHeight - 1)
                player.Y++;
        }

        spawnTimer++;
        if (spawnTimer == spawnInterval)
        {
            Random random = new Random();
            int rand = random.Next(0, 10);
            if (rand < 5)
            {
                Obstacle newObstacle = new Obstacle(
                    0,
                    random.Next(Console.WindowHeight - 2) + 1,
                    GetRandomObstacleSymbol(),
                    obstacleSpeed
                );
                obstacles.Add(newObstacle);
            }
            else // spawn obstacle from the right
            {
                Obstacle newObstacle = new Obstacle(
                    Console.WindowWidth - 1,
                    random.Next(Console.WindowHeight - 2) + 1,
                    GetRandomObstacleSymbol(),
                    -obstacleSpeed // negative speed will move the obstacle to the left
                );
                obstacles.Add(newObstacle);
            }
            spawnTimer = 0;
            if (spawnInterval > 1) spawnInterval--;
        }
        
        foreach (Obstacle obstacle in obstacles)
        {
            Console.SetCursorPosition(obstacle.X, obstacle.Y);
            Console.Write(obstacle.Symbol);
            obstacle.X += obstacle.Speed;
            if ((obstacle.X == player.X && obstacle.Y == player.Y) || (obstacle.X == player.X + 1 && obstacle.Y == player.Y + 1))
            {
                gameover = true;
                Console.SetCursorPosition(Console.WindowWidth / 2 - 5, Console.WindowHeight / 2);
                Console.Clear();
                Console.Write("Game Over");
                Thread.Sleep(1000);
                break;
            }
        }
        obstacles.RemoveAll(o => o.X < 0 || o.X >= Console.WindowWidth);

        TimeSpan timeElapsed = DateTime.Now - startTime;
        Console.SetCursorPosition(Console.WindowWidth - 11, 0);
        Console.Write($"Time: {timeElapsed:mm\\:ss}");

        Thread.Sleep(50);
        Console.Clear();

        elapsedTime = DateTime.Now - startTime;

        if (elapsedTime.TotalSeconds >= 60)
        {
            Console.SetCursorPosition(Console.WindowWidth / 2 - 5, Console.WindowHeight / 2);
            Console.Clear();
            Console.Write("You Win!");
            Thread.Sleep(1000);
            gameover = true;
        }
    }
}
        public string GetRandomObstacleSymbol()
        {
            string[] symbols = { "🌲", "🚓", "🪿", "🏳️‍🌈" };
            Random rnd = new Random();
            int index = rnd.Next(0, symbols.Length);
            return symbols[index];
        }
    }
}

}

