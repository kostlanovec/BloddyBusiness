using Konzole.Konzole;
namespace Konzole
{
    class Program
    {
        static void Main()
        {
            Console.Clear();
            Console.CursorVisible = false;
            while (true)
            {
                Console.SetCursorPosition(0, 0);
                Console.Write(new string(' ', Console.WindowWidth * Console.WindowHeight));
                Console.CursorVisible = false;
                Console.Title = "Blood Business";
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.Clear();

                while (true)
                {
                    Console.WriteLine("██████╗ ██╗      ██████╗  ██████╗ ██████╗     ██████╗ ██╗   ██╗███████╗██╗███╗   ██╗███████╗███████╗███████╗");
                    Console.WriteLine("██╔══██╗██║     ██╔═══██╗██╔═══██╗██╔══██╗    ██╔══██╗██║   ██║██╔════╝██║████╗  ██║██╔════╝██╔════╝██╔════╝"); 
                    Console.WriteLine("██████╔╝██║     ██║   ██║██║   ██║██║  ██║    ██████╔╝██║   ██║███████╗██║██╔██╗ ██║█████╗  ███████╗███████╗");   
                    Console.WriteLine("██╔══██╗██║     ██║   ██║██║   ██║██║  ██║    ██╔══██╗██║   ██║╚════██║██║██║╚██╗██║██╔══╝  ╚════██║╚════██║");
                    Console.WriteLine("██████╔╝███████╗╚██████╔╝╚██████╔╝██████╔╝    ██████╔╝╚██████╔╝███████║██║██║ ╚████║███████╗███████║███████║");
                    Console.WriteLine("╚═════╝ ╚══════╝ ╚═════╝  ╚═════╝ ╚═════╝     ╚═════╝  ╚═════╝ ╚══════╝╚═╝╚═╝  ╚═══╝╚══════╝╚══════╝╚══════╝");
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
}
