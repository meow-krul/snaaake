using System;

namespace boi
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            #region Vars
            
            //massive
            int[] xPosition = new int[50];
            int[] yPosition = new int[50];
            
            //snake position
            xPosition[0] = 50;
            yPosition[0] = 20;
            
            //apple position
            int appleXposition = 10;
            int appleYposition = 10;
            
            //score
            int applesEaten = 0;
            
            //wtf
            string userAction = "";
            
            //random things
            Random random = new Random();

            //visible of cursor
            Console.CursorVisible = false;
            
            //game speed
            decimal gameSpeed = 150m;
             
            //bullshit
            bool isGameOn = true;
            bool isWallHit = false;
            bool isAppleEaten = false;
            bool isStayInMenu = true;
            
            #endregion


            
            showMenu(out userAction);
            

            #region Game Setup
            
            //appearance of a snake
            Console.SetCursorPosition(xPosition[0], yPosition[0]);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("0");

            //appearance of an apple
            SetApplePositionOnScreen(random, out appleXposition, out appleYposition);
            PaintApple(appleXposition, appleYposition); 

            //we need to build the wall
            buildWall(40, 100);

            //game
            ConsoleKey command = Console.ReadKey().Key;
            
            #endregion

            
            do
            {    
                #region Direction
                //just idk
                buildWall(40, 100);
            
                //key things
                switch (command)
                {
                    case ConsoleKey.W:
                        Console.SetCursorPosition(xPosition[0], yPosition[0]);
                        Console.Write(" ");
                        yPosition[0]--;
                        break;

                    case ConsoleKey.S:
                        Console.SetCursorPosition(xPosition[0], yPosition[0]);
                        Console.Write(" ");
                        yPosition[0]++;
                        break;

                    case ConsoleKey.A:
                        Console.SetCursorPosition(xPosition[0], yPosition[0]);
                        Console.Write(" ");
                        xPosition[0]--;
                        break;

                    case ConsoleKey.D:
                        Console.SetCursorPosition(xPosition[0], yPosition[0]);
                        Console.Write(" ");
                        xPosition[0]++;
                        break;
                }
                
                #endregion

                #region Playing game
                
                //paint the snake
                paintSnake(applesEaten, xPosition, yPosition, out xPosition, out yPosition);
                
                //drawing pog snake
                Console.SetCursorPosition(xPosition[0], yPosition[0]);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("0");
                
                //check if snake hit the wall
                isWallHit = DidSnakeHitTheWall(xPosition[0], yPosition[0]);
                
                //end of the game
                if (isWallHit)
                {
                    Console.SetCursorPosition(40, 20);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("heh gg");
                    Environment.Exit(0);
                }
                
                //check if f is eaten
                isAppleEaten = determineIfAppleWasEaten(xPosition[0], yPosition[0], appleXposition, appleYposition);
                
                //apple things
                if (isAppleEaten)
                {
                    SetApplePositionOnScreen(random, out appleXposition, out appleYposition);
                    PaintApple(appleXposition, appleYposition);
                    applesEaten++;
                    gameSpeed *= .950m;
                }
                
                //new key
                if (Console.KeyAvailable)
                {
                    command = Console.ReadKey().Key;
                }

                //chilling for gameSpeed
                System.Threading.Thread.Sleep(Convert.ToInt32(gameSpeed));
                
                #endregion
                
            } while (isGameOn);
            
            
            
        }
        #region Methods

        private static void showMenu(out string userAction)
        {
            string menu1 = @"








──────▄▀▄─────▄▀▄
─────▄█░░▀▀▀▀▀░░█▄
─▄▄──█░░░░░░░░░░░█──▄▄
█▄▄█─█░░▀░░┬░░▀░░█─█▄▄█
";
            string menu2 = @"





──────▄▀▄─────▄▀▄
─────▄█░░▀▀▀▀▀░░█▄
─▄▄──█░░░░░░░░░░░█──▄▄
█▄▄█─█░░▀░░┬░░▀░░█─█▄▄█";
            string menu3 = @"




──────▄▀▄─────▄▀▄
─────▄█░░▀▀▀▀▀░░█▄
─▄▄──█░░░░░░░░░░░█──▄▄
█▄▄█─█░░▀░░┬░░▀░░█─█▄▄█";
            string menu4 = @"


──────▄▀▄─────▄▀▄
─────▄█░░▀▀▀▀▀░░█▄
─▄▄──█░░░░░░░░░░░█──▄▄
█▄▄█─█░░▀░░┬░░▀░░█─█▄▄█";
            string menu5 = @"

──────▄▀▄─────▄▀▄
─────▄█░░▀▀▀▀▀░░█▄
─▄▄──█░░░░░░░░░░░█──▄▄
█▄▄█─█░░▀░░┬░░▀░░█─█▄▄█";
            
            Console.WriteLine(menu1);
            System.Threading.Thread.Sleep(300);
            Console.Clear();
            Console.WriteLine(menu2);
            System.Threading.Thread.Sleep(300);
            Console.Clear();
            Console.WriteLine(menu3);
            System.Threading.Thread.Sleep(300);
            Console.Clear();
            Console.WriteLine(menu4);
            System.Threading.Thread.Sleep(300);
            Console.Clear();
            Console.WriteLine(menu5);
            System.Threading.Thread.Sleep(300);
            Console.Clear();
            Console.ReadKey();

            userAction = Console.ReadLine().ToLower();
        }
        private static void paintSnake(int applesEaten, int[] xPositionIn, int[] yPositionIn, out int[] xPositionOut, out int[] yPositionOut)
        {
            Console.SetCursorPosition(xPositionIn[0], yPositionIn[0]);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("o");

            for (int i = 1; i < applesEaten + 1; i++)
            {
                Console.SetCursorPosition(xPositionIn[i], yPositionIn[i]);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("o");
            }
            
            Console.SetCursorPosition(xPositionIn[applesEaten + 1], yPositionIn[applesEaten + 1]);
            Console.WriteLine(" ");

            for (int i = applesEaten + 1; i > 0; i--)
            {
                xPositionIn[i] = xPositionIn[i - 1];
                yPositionIn[i] = yPositionIn[i - 1];
            }
            
            xPositionOut = xPositionIn;
            yPositionOut = yPositionIn;
        }
        private static bool determineIfAppleWasEaten(int xPosition, int yPosition, int appleXposition, int appleYposition)
        {
            if (xPosition == appleXposition && yPosition == appleYposition)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private static void PaintApple(int appleXposition, int appleYposition)
        {
            Console.SetCursorPosition(appleXposition, appleYposition);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("F");
        }
           
        private static void SetApplePositionOnScreen(Random random, out int appleXposition, out int appleYposition)
        {
            appleXposition = random.Next(1, 99);
            appleYposition = random.Next(1, 39);
        }
     
        private static bool DidSnakeHitTheWall(int a, int b)
        {
            if (a == 1 || a == 100 || b == 1 || b == 40)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
                 
        private static void buildWall(int a, int b)
        {
            for (int i = 1; i < a; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.SetCursorPosition(0,i);
                Console.Write("#");
                Console.SetCursorPosition(b, i);
                Console.Write("#");
            }

            for (int j = 2; j < b; j++)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.SetCursorPosition(j, 1);
                Console.Write("#");
                Console.SetCursorPosition(j, a-1);
                Console.Write("#");
            }               
        }       
        
        #endregion
    }
}
