// New start 12.10.23

using System;

class TetrisGame
{
    //========================================================
    


    //========================================================
    private static int[,] matrix = new int[30, 30];
    private static int currentX = 0;
    private static int currentY = 0;


    static void Main(string[] args)
    {
        bool isRunning = true;

        //Основной цикл
        while (isRunning)
        {
            DrawMatrix();
            ConsoleKeyInfo keyInfo = GetInput();

            switch (keyInfo.Key)
            {
                case ConsoleKey.LeftArrow:
                    MoveLeft();
                    break;
                    
                case ConsoleKey.RightArrow:
                    MoveRight();
                    break;
                    
                case ConsoleKey.DownArrow:
                    MoveDown();
                    break;
                    
                case ConsoleKey.UpArrow:
                    MoveUp();
                    break;
                    
                case ConsoleKey.Q:
                    isRunning = false;
                    break;
            }
        }
        
        Console.WriteLine("Игра окончена!");
        Console.ReadLine();
    }

    private static void DrawMatrix()
    {
        Console.Clear();

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (i == currentY && j == currentX)
                {
                    Console.Write("X");
                }
                else
                {
                   // Console.WriteLine(".");
                    Console.Write(matrix[i, j]);
                }
            }
            
            Console.WriteLine();
        }
    }

    private static ConsoleKeyInfo GetInput()
    {
        Console.Write("Ввод: ");
        ConsoleKeyInfo keyInfo = Console.ReadKey();
        Console.WriteLine($"{keyInfo}");
        Console.WriteLine();
        
        return keyInfo;
    }

    private static void MoveLeft()
    {
        if (currentX - 1 >= 0)
        {
            currentX--;
        }
    }

    private static void MoveRight()
    {
        if (currentX + 1 < matrix.GetLength(1))
        {
            currentX++;
        }
    }

    private static void MoveDown()
    {
        if (currentY + 1 < matrix.GetLength(0))
        {
            currentY++;
        }
    }

    private static void MoveUp()
    {
        if (currentY - 1 >= 0)
        {
            currentY--;
        }
    }
}