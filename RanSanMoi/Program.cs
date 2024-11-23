using System;
using System.Threading.Tasks;
using System.Threading;

namespace RanSanMoi
{
    class Program
    {
        static bool isGameOver = false;

        static int n = 20;
        static int m = 30;
        static int score = 0;   
        static int speed = 500;
        static string direction = Direction.DIRECTION_RIGHT;
        
        static string[,] board = new string[n, m];
        static Snake snake = new Snake();
        static Food food = new Food();

        private static void calcWall()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if(i == 0 || i == (n-1) || j == 0 || j == (m-1)){
                        board[i, j] = "#";
                    }
                }
            }
        }

        private static void printBoard()
        {
            Console.WriteLine($"Score: {score}");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    string value = board[i, j];
                    if(value.Equals("#")){
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.Write(value);
                        Console.ResetColor();
                    }else{
                        Console.Write(value);
                    }
                }
                Console.WriteLine();
            }
        }

        private static void resetBoard()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    board[i, j] = " ";
                }
            }
        }

        private static void calcFood(){
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if(i == food.Point.Row && j == food.Point.Column){
                        board[i, j] = "@";
                    }
                }
            }
        }

        private static void calcSnake(){
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    //Đầu rắn
                    int row = snake.Head.Row;
                    int col = snake.Head.Column;

                    if(i == row && j == col){
                        board[i, j] = "0";
                    }
                    //Thân rắn
                    List<Point> body = snake.Body;
                    for(int k =0; k < body.Count; k++){
                        Point element = body[k];
                        if(i == element.Row && j == element.Column){
                            board[i, j] = "o";
                        }
                    }
                }
            }
        }

        static void ListenKey(){
            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();

                if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    if (direction != Direction.DIRECTION_DOWN)
                    {
                        direction = Direction.DIRECTION_UP;
                    }
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    if (direction != Direction.DIRECTION_UP)
                    {
                        direction = Direction.DIRECTION_DOWN;
                    }
                }
                else if (keyInfo.Key == ConsoleKey.LeftArrow)
                {
                    if (direction != Direction.DIRECTION_RIGHT)
                    {
                        direction = Direction.DIRECTION_LEFT;
                    }
                }
                else if (keyInfo.Key == ConsoleKey.RightArrow)
                {
                    if (direction != Direction.DIRECTION_LEFT)
                    {
                        direction = Direction.DIRECTION_RIGHT;
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            bool started = true;
            while (started){
                //di chuyển rắn
                isGameOver = false;
                snake = new Snake();
                Thread thread = new Thread(Program.ListenKey);
                thread.Start();

                food.RandomPoint(snake,n,m);

                while(!isGameOver){
                    
                    Console.Clear();
                    //Tạo khoảng trống trong tường
                    resetBoard();
                    //Vẽ tường
                    calcWall();
                    //vẽ food
                    calcFood();
                    //Di chuyển rắn
                    snake.move(direction, n, m);
                    //Tạo đầu rắn
                    calcSnake();
                    //Tô màu tường
                    printBoard();
                    //Ăn thức ăn và dài thân
                    if(snake.Head.Row == food.Point.Row && snake.Head.Column == food.Point.Column){
                        snake.Body.Add(new Point(-1, -1));
                        score++;                   
                        food.RandomPoint(snake, n, m);
                    }

                    //Đầu va vào thân sẽ Game over
                    if(snake.IsHeadTouchBody()){
                        Console.WriteLine("GAME OVER");
                        isGameOver = true;
                        break;
                    }
                    Task.Delay(speed).Wait();
                }
                Task.Delay(2000).Wait();
                bool started1 = true;

                while (started1)
                {
                    if (isGameOver)
                    {
                        Console.WriteLine("Do you want to continue? (input: Y or N)");
                        string c = Console.ReadLine();

                        if (c.Equals("Y", StringComparison.OrdinalIgnoreCase)){
                            started = true;
                            started1 = false;
                        } else {
                            if (c.Equals("N", StringComparison.OrdinalIgnoreCase)){
                                started = false;
                                started1 = false; 
                            } else{
                                Console.WriteLine("Your input is wrong. Let's try again!");
                            }
                        }
                    }
                }
            }
            // Kết thúc chương trình khi người dùng chọn "N"
            Console.WriteLine("Exiting game...");
            Environment.Exit(0);
        }
    }
}
