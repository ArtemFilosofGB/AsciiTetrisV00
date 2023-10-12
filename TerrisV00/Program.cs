// New start 12.10.23

using System;

class TetrisGame
{
    //========================================================



    //========================================================
    static int FieldWidth = 10; //Размер игрального поля
    static int FieldHeight = 20;
    private static int[,] matrix = new int[FieldHeight, FieldWidth];
    static int CurrentShapeX = FieldWidth / 2; //Старт падения фигуры
    static int CurrentShapeY = 0;
    private static int currentX = FieldWidth / 2;//координаты курсора
    private static int currentY = 0;

    static int[,] CurrentShape = new int[4, 4]; //вид игрового кубика
    static int Score = 0;

    static void Main(string[] args)
    {

        // version 0.2
        Console.Title = "ASCII Tetris";
        Console.CursorVisible = false;

        bool isRunning = true;

        //Основной цикл
        while (isRunning)
        {
            ResetShape();//v0.2
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
        Console.WriteLine("Счёт игры: " + Score);
        Console.ReadLine();
    }
    //~~~~~~~~~~~~~~~~~~~~~~Конец main основной программы~~~~~~~~~~~~~~~~~~~~~~~~

    //================переключатель фигур
    static void ResetShape()
    {
        CurrentShapeX = FieldWidth / 2;
        CurrentShapeY = 0;

        Random random = new Random();
        int shapeIndex = random.Next(1, 8);

        switch (shapeIndex)
        {
            case 1:
                CurrentShape = new int[,]
                {
                    { 1, 1, 1, 1 }
                };
                break;
            case 2:
                CurrentShape = new int[,]
                {
                    { 1, 1 },
                    { 1, 1 }
                };
                break;
            case 3:
                CurrentShape = new int[,]
                {
                    { 1, 1, 1 },
                    { 0, 1, 0 }
                };
                break;
            case 4:
                CurrentShape = new int[,]
                {
                    { 1, 1, 1 },
                    { 1, 0, 0 }
                };
                break;
            case 5:
                CurrentShape = new int[,]
                {
                    { 1, 1, 0 },
                    { 0, 1, 1 }
                };
                break;
            case 6:
                CurrentShape = new int[,]
                {
                    { 0, 1, 1 },
                    { 1, 1, 0 }
                };
                break;
            case 7:
                CurrentShape = new int[,]
                {
                    { 1, 1, 1 },
                    { 0, 0, 1 }
                };
                break;
        }
    }
    //=============конец переключатель фигур========

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
                    if (i==0 || j==0 || i==matrix.GetLength(0)-1 || j==matrix.GetLength(1)-1)
                    {
                         Console.Write("█");
                    }
                    else
                    // Console.WriteLine(".");
                    Console.Write(matrix[i, j]);
                }
            }

            Console.WriteLine();
        }
    }

    private static ConsoleKeyInfo GetInput()
    {
        Console.Write("ASCII Tetris Ввод: ");
        ConsoleKeyInfo keyInfo = Console.ReadKey();
        Console.WriteLine($"");
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
/*
using System;
using System.Threading;

namespace Tetris
{
    class Program
    {
        static int FieldWidth = 10;
        static int FieldHeight = 20;
        static int[,] Field = new int[FieldHeight, FieldWidth];
        static int CurrentShapeX = FieldWidth / 2;
        static int CurrentShapeY = 0;
        static int[,] CurrentShape = new int[4, 4];
        static int Score = 0;

        static void Main(string[] args)
        {
            Console.Title = "Console Tetris";
            Console.CursorVisible = false;

            while (true)
            {
                ResetShape();
                while (CanMove(CurrentShapeX, CurrentShapeY + 1))
                {
                    DrawField();
                    MoveShape(Console.ReadKey(true).Key);
                }
                MergeShape();
                CheckLines();
                if (!CanMove(CurrentShapeX, CurrentShapeY))
                {
                    Console.Clear();
                    Console.WriteLine("Game Over!");
                    Console.WriteLine("Your score: " + Score);
                    Console.ReadKey();
                    ResetField();
                    Score = 0;
                }
            }
        }

        static bool CanMove(int x, int y)
        {
            for (int i = 0; i < CurrentShape.GetLength(0); i++)
            {
                for (int j = 0; j < CurrentShape.GetLength(1); j++)
                {
                    if (CurrentShape[i, j] != 0)
                    {
                        int newX = x + j;
                        int newY = y + i;
                        if (newX < 0 newX >= FieldWidth newY >= FieldHeight || Field[newY, newX] != 0)
                            return false;
                    }
                }
            }
            return true;
        }

        static void MergeShape()
        {
            for (int i = 0; i < CurrentShape.GetLength(0); i++)
            {
                for (int j = 0; j < CurrentShape.GetLength(1); j++)
                {
                    if (CurrentShape[i, j] != 0)
                        Field[CurrentShapeY + i, CurrentShapeX + j] = CurrentShape[i, j];
                }
            }
        }

        static void ResetShape()
        {
            CurrentShapeX = FieldWidth / 2;
            CurrentShapeY = 0;

            Random random = new Random();
            int shapeIndex = random.Next(1, 8);

            switch (shapeIndex)
            {
                case 1:
                    CurrentShape = new int[,]
                    {
                        { 1, 1, 1, 1 }
                    };
                    break;
                case 2:
                    CurrentShape = new int[,]
                    {
                        { 1, 1 },
                        { 1, 1 }
                    };
                    break;
                case 3:
                    CurrentShape = new int[,]
                    {
                        { 1, 1, 1 },
                        { 0, 1, 0 }
                    };
                    break;
                case 4:
                    CurrentShape = new int[,]
                    {
                        { 1, 1, 1 },
                        { 1, 0, 0 }
                    };
                    break;
                case 5:
                    CurrentShape = new int[,]
                    {
                        { 1, 1, 0 },
                        { 0, 1, 1 }
                    };
                    break;
                case 6:
                    CurrentShape = new int[,]
                    {
                        { 0, 1, 1 },
                        { 1, 1, 0 }
                    };
                    break;
                case 7:
                    CurrentShape = new int[,]
                    {
                        { 1, 1, 1 },
                        { 0, 0, 1 }
                    };
                    break;
            }
        }
*/