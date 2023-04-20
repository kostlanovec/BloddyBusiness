namespace Konzole
{
    class Player
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Score { get; set; }
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
                Score = 0
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
        Console.Write("█");
        
        Console.SetCursorPosition(obstacleX, obstacleY);
        Console.Write("█");
        
        if (Console.KeyAvailable)
        {
            ConsoleKeyInfo key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.UpArrow && player.Y > 0)
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
            SaveScore();
        }
        if (obstacleX == 0)
        {
            obstacleX = Console.WindowWidth - 1;
            obstacleY = new Random().Next(Console.WindowHeight);
            player.Score++;
        }
        TimeSpan timeElapsed = DateTime.Now - startTime;
        Console.SetCursorPosition(Console.WindowWidth - 10, 0);
        Console.Write($"Time: {timeElapsed:mm\\:ss}");
        
        Thread.Sleep(50);
        Console.Clear();
        
        elapsedTime = DateTime.Now - startTime;
        
        if (elapsedTime.TotalSeconds >= 10)
        {
            Console.SetCursorPosition(Console.WindowWidth / 2 - 5, Console.WindowHeight / 2);
            Console.Clear();
            Console.Write("You Win!");
            Thread.Sleep(1000);
            gameover = true;
            SaveScore();
        }
    }
}


        private void SaveScore()
        {
            string scoreFilePath = "score.txt";
            if (File.Exists(scoreFilePath))
            {
                using (StreamWriter writer = File.AppendText(scoreFilePath))
                {
                    writer.WriteLine($"{DateTime.Now}: {player.Score}");
                }
            }
            else
            {
                using (StreamWriter writer = File.CreateText(scoreFilePath))
                {
                    writer.WriteLine($"{DateTime.Now}: {player.Score}");
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            /*string musicFilePath = "music.wav";
            if (File.Exists(musicFilePath))
            {
                SoundPlayer musicPlayer = new SoundPlayer(musicFilePath);
                musicPlayer.PlayLooping();
            }*/
            Console.CursorVisible = false;
            Console.Title = "Blood Business";
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.Clear();

            while (true)
            {
                Console.WriteLine("Welcome to Blood Business!");
                Console.WriteLine("==========================");
                Console.WriteLine("1. Start new game");
                Console.WriteLine("2. Load saved game");
                Console.WriteLine("3. Settings");
                Console.WriteLine("4. Quit");

                ConsoleKeyInfo input = Console.ReadKey(true);
                switch (input.KeyChar)
                {
                    case '1':
                        Console.Clear();
                        CarGame game = new CarGame();
                        game.Play();
                        break;

                    case '2':
                        Console.Clear();
                        Console.WriteLine("Loading saved game...");
                        Console.ReadKey(true);
                        break;

                    case '3':
                        Console.Clear();
                        Console.WriteLine("Music settings:");
                        Console.WriteLine("================");
                        Console.WriteLine("1. Turn music on");
                        Console.WriteLine("2. Turn music off");

                        ConsoleKeyInfo musicInput = Console.ReadKey(true);
                        switch (musicInput.KeyChar)
                        {
                            case '1':
                                Console.WriteLine("Turning music on...");
                                Console.ReadKey(true);
                                break;

                            case '2':
                                Console.WriteLine("Turning music off...");
                                Console.ReadKey(true);
                                break;

                            default:
                                Console.WriteLine("Invalid input. Press any key to continue...");
                                Console.ReadKey(true);
                                break;
                        }
                        break;

                    case '4':
                        return;

                    default:
                        Console.WriteLine("Invalid input. Press any key to continue...");
                        Console.ReadKey(true);
                        break;
                }

                Console.Clear();
            }
        }
    }

    }
