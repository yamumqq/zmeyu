﻿using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SnakeGame;

namespace dispetcher
{
    class Program
    {
        static void Main(string[] args)
        {
            int windowWidth = 110, windowHeight = 36;
            Map map = new Map(windowWidth, windowHeight);
            Snake snake = new Snake('O');
            Food food = new Food(windowWidth, windowHeight);
            ConsoleKeyInfo key = new ConsoleKeyInfo();
            map.Draw();
            long Score = 0;
            Console.SetCursorPosition(1, 35);
            Console.WriteLine("w a s d для передвижения");
            bool isInc = false;
            while (snake.GetAlive() == true)
            {
                if (Console.KeyAvailable == true)
                {
                    key = Console.ReadKey(true);
                }
                snake.IsAlive(windowWidth, windowHeight);
                snake.Update(key);
                isInc = food.Draw(snake.GetCoordsX(), snake.GetCoordsY());
                if (isInc)
                {
                    snake.IncLength();
                    Score += 20;
                }
                if (snake.IsIntersected() == true) { snake.SetAlive(false); }
                map.PrintScore(Score);
                Score++;
                Thread.Sleep(80);
                if (snake.GetAlive() == false) break;
            }

            snake.Clear();
            map.Draw();
            map.GameOverPrint(windowWidth, windowHeight);
            Console.ReadKey();
            Console.SetCursorPosition(windowWidth / 4, (windowHeight / 5) + 20);
        }
    }
}