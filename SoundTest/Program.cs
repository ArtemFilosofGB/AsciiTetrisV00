
using System;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("Press any key to play a sound or 'q' to quit.");

        // Start a new thread to play the melody
        Thread melodyThread = new Thread(PlayMelody);
        melodyThread.Start();

        // Listen for key presses
        Console.WriteLine("Press ESC to stop");
        int countTemp = 0;
        do
        {
            while (!Console.KeyAvailable)
            {
                // Do something
                Console.SetCursorPosition(0, 3);
                switch (countTemp)
                {
                    case 0: Console.Write("_"); break;
                    case 1: Console.Write("-"); break;
                    case 2: Console.Write("~"); break;
                    case 3: countTemp = 0; break;

                }
                Thread.Sleep(100);
                countTemp++;

                //Console.Clear();
            }
        } while (Console.ReadKey(true).Key != ConsoleKey.Escape);


        while (true)
        {
            var key = Console.ReadKey(true);
            if (key.KeyChar == 'q')
                break;

            // Play a sound
            Console.Beep();
        }
    }

    int[,] CreateMatrixRndInt(int rows, int colums, int min, int max)
    {
        int[,] matrix = new int[rows, colums];
        Random rnd = new Random();

        for (int i = 0; i < rows; i++) // matrix.GetLength(0)
        {
            for (int j = 0; j < colums; j++) // matrix.GetLength(1)
            {
                matrix[i, j] = rnd.Next(min, max);
                //matrix[i,j] = i+j;  
            }
        }
        return matrix;
    }

    static void PlayMelody()
    {
        // Change the notes and durations as desired
        int[] notes = { 262, 294, 330, 349, 392, 440, 494, 523 };
        int[] durations = { 500, 500, 500, 500, 500, 500, 500, 500 };
        Random rnd = new Random();


        for (int i = 0; i < notes.Length; i++)
        {
            durations[i] = rnd.Next(10, 300);
            notes[i] = rnd.Next(262, 523);
        }
        for (int i = 0; i < 9; i++)//количество аовторов
        {
            for (int j = 0; j < 8; j++)
                Console.Beep(notes[j], durations[j]);
            Thread.Sleep(1000);
            Console.SetCursorPosition(5, 5);
            Console.WriteLine(i);
            // Console.WriteLine($"~{notes[j]}={durations[j]}~");
        }


    }
}