using System;
using System.Diagnostics;

namespace Tic_Tac_toe
{
    class Program
    {
        public event EventHandler Closed;
        static void DrawCross(int x, int y, int size)
        {
            for (int i = x; i <= x + size; i++)
            {
                for (int j = y; j <= y + size; j++)
                {
                    if (i - j == x - y || i + j == y + x + size)
                    {
                        Console.SetCursorPosition(i, j);
                        Console.Write("#");
                    }
                }
            }
        }
        static void DrawRectangle(int x, int y, int size)
        {
            for (int i = x; i <= x + size; i++)
            {
                for (int j = y; j <= y + size; j++)
                {
                    if (i == x || i == x + size || j == y || j == y + size)
                    {
                        Console.SetCursorPosition(i, j);
                        Console.Write("#");
                    }
                }
            }
        }
        static void DrawField(int widht, int height, int сellSize)
        {
            for (int y = 0; y <= height; y += сellSize)
            {
                for (int x = 0; x < widht; x++)
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write("▓");
                }
            }

            for (int x = 0; x <= widht; x += сellSize)
            {
                for (int y = 0; y <= height; y++)
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write("▓");
                }
            }
            Console.SetCursorPosition(2, 1);
            Console.Write("№1");
            Console.SetCursorPosition(13, 1);
            Console.Write("№2");
            Console.SetCursorPosition(24, 1);
            Console.Write("№3");
            Console.SetCursorPosition(2, 12);
            Console.Write("№4");
            Console.SetCursorPosition(13, 12);
            Console.Write("№5");
            Console.SetCursorPosition(24, 12);
            Console.Write("№6");
            Console.SetCursorPosition(2, 23);
            Console.Write("№7");
            Console.SetCursorPosition(13, 23);
            Console.Write("№8");
            Console.SetCursorPosition(24, 23);
            Console.Write("№9");
        }
        static void Main()
        {
            Console.SetWindowSize(90, 34);
            Console.SetBufferSize(90, 34);

            DrawField(33, 33, 11);

            int win = -1;
            int input;
            int c1, c2, c3, c4, c5, c6, c7, c8, c9; // cross - 0 rectangle = 1 null - <= -1
            c1 = -1; c2 = -2; c3 = -3; c4 = -4; c5 = -5; c6 = -6; c7 = -7; c8 = -8; c9 = -9;

            //Главный цикл игры
            for (int i = 0; i < 9; i++)
            {
                Console.SetCursorPosition(35, 0);
                Console.Write("                                                  ");
                Console.SetCursorPosition(35, 0);
                Console.Write("Введи номер клетки:");

                //Проверка корректности ввода

                bool errorInput = !int.TryParse(Console.ReadLine(), out input);

                if (input < 1 || input > 9) errorInput = true;
                if (input == 1 && c1 >= 0) errorInput = true;
                if (input == 2 && c2 >= 0) errorInput = true;
                if (input == 3 && c3 >= 0) errorInput = true;
                if (input == 4 && c4 >= 0) errorInput = true;
                if (input == 5 && c5 >= 0) errorInput = true;
                if (input == 6 && c6 >= 0) errorInput = true;
                if (input == 7 && c7 >= 0) errorInput = true;
                if (input == 8 && c8 >= 0) errorInput = true;
                if (input == 9 && c9 >= 0) errorInput = true;

                if (errorInput == true)
                {
                    i--;
                    continue;
                }

                if (input == 1) c1 = i % 2;
                if (input == 2) c2 = i % 2;
                if (input == 3) c3 = i % 2;
                if (input == 4) c4 = i % 2;
                if (input == 5) c5 = i % 2;
                if (input == 6) c6 = i % 2;
                if (input == 7) c7 = i % 2;
                if (input == 8) c8 = i % 2;
                if (input == 9) c9 = i % 2;

                Console.SetCursorPosition(35, 1);
                Console.Write($"Предыдущий ход:{input}");

                //Определение куда поставить фигуру
                int x = (input - 1) % 3 * 11 + 2;
                int y = (input - 1) / 3 * 11 + 2;

                //Поределение какую фигуру рисовать и отрисовка
                if (i % 2 == 0) DrawCross(x, y, 7);
                else DrawRectangle(x, y, 7);

                //Определение победы
                if (c1 == c2 && c2 == c3) win = c1;
                if (c4 == c5 && c5 == c6) win = c4;
                if (c7 == c8 && c8 == c9) win = c7;
                if (c1 == c4 && c4 == c7) win = c1;
                if (c2 == c5 && c5 == c8) win = c2;
                if (c3 == c6 && c6 == c9) win = c3;
                if (c1 == c5 && c5 == c9) win = c1;
                if (c3 == c5 && c5 == c7) win = c3;

                if (win == 0)
                {
                    Console.Clear();
                    Console.SetCursorPosition(35, 2);
                    Console.WriteLine("Победили крестики!");
                    Console.ReadKey();
                    break;
                }
                if (win == 1)
                {
                    Console.Clear();
                    Console.SetCursorPosition(35, 2);
                    Console.WriteLine("Победили нолики!");
                    Console.ReadKey();
                    break;
                }
            }
            if (win == -1)
            {
                Console.Clear();
                Console.SetCursorPosition(35, 3);
                Console.WriteLine("Ничья!");
                Console.ReadKey();
            }
            Process.GetCurrentProcess().Kill();
        }
    }
}