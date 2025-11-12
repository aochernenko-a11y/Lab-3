using Lab3;
using System;
using System.Collections.Generic;

namespace Lab3
{
    internal class Program
    {
        private static List<BoardGame> games = new List<BoardGame>();

        private static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            int choice;
            do
            {
                Console.WriteLine("\n=== МЕНЮ ===");
                Console.WriteLine("1 – Додати гру");
                Console.WriteLine("2 – Переглянути всi iгри");
                Console.WriteLine("3 – Знайти гру");
                Console.WriteLine("4 – Продемонструвати поведiнку");
                Console.WriteLine("5 – Видалити гру");
                Console.WriteLine("0 – Вийти");
                Console.Write("Ваш вибiр: ");
                int.TryParse(Console.ReadLine(), out choice);

                switch (choice)
                {
                    case 1:
                        AddGame();
                        break;
                    case 2:
                        ShowAll();
                        break;
                    case 3:
                        FindGame();
                        break;
                    case 4:
                        Demonstrate();
                        break;
                    case 5:
                        DeleteGame();
                        break;
                    case 0:
                        Console.WriteLine("Вихiд iз програми...");
                        break;
                    default:
                        Console.WriteLine("Некоректний вибiр!");
                        break;
                }
            } while (choice != 0);
        }

        private static void AddGame()
        {
            Console.WriteLine("\n--- Додавання гри ---");
            Console.WriteLine("Оберiть конструктор:");
            Console.WriteLine("1 – Без параметрiв");
            Console.WriteLine("2 – З одним параметром");
            Console.WriteLine("3 – З трьома параметрами");
            Console.WriteLine("4 – Повна iнiцiалiзацiя");
            int c = int.Parse(Console.ReadLine());
            BoardGame g;

            switch (c)
            {
                case 1:
                    g = new BoardGame();
                    break;
                case 2:
                    Console.Write("Назва: ");
                    string t = Console.ReadLine();
                    g = new BoardGame(t);
                    break;
                case 3:
                    Console.Write("Назва: ");
                    string n = Console.ReadLine();
                    Console.Write("Жанр: ");
                    string gen = Console.ReadLine();
                    Console.Write("Цiна: ");
                    decimal pr = decimal.Parse(Console.ReadLine());
                    g = new BoardGame(n, gen, pr);
                    break;
                case 4:
                    Console.Write("Назва: ");
                    string title = Console.ReadLine();
                    Console.Write("Жанр: ");
                    string genre = Console.ReadLine();
                    Console.Write("Мiн. гравцiв: ");
                    int min = int.Parse(Console.ReadLine());
                    Console.Write("Макс. гравцiв: ");
                    int max = int.Parse(Console.ReadLine());
                    Console.Write("Тривалiсть (хв): ");
                    int dur = int.Parse(Console.ReadLine());
                    Console.Write("Вiк (вiд): ");
                    int age = int.Parse(Console.ReadLine());
                    Console.Write("Цiна: ");
                    decimal price = decimal.Parse(Console.ReadLine());
                    Console.Write("Видавець: ");
                    string pub = Console.ReadLine();
                    g = new BoardGame(title, genre, min, max, dur, age, price, pub);
                    break;
                default:
                    g = new BoardGame();
                    break;
            }

            games.Add(g);
            Console.WriteLine("Гру додано!");
        }

        private static void ShowAll()
        {
            Console.WriteLine("\n--- Список iгор ---");
            if (games.Count == 0)
            {
                Console.WriteLine("Список порожнiй!");
                return;
            }

            games.Sort((a, b) => string.Compare(a.Name, b.Name, StringComparison.OrdinalIgnoreCase));

            foreach (var g in games)
            {
                g.DisplayInfo("short");
            }
        }

        private static void FindGame()
        {
            Console.Write("\nВведiть назву гри: ");
            string search = Console.ReadLine();

            var found = games.Find(g => g.Name.Equals(search, StringComparison.OrdinalIgnoreCase));
            if (found != null)
            {
                Console.WriteLine("Знайдено гру:");
                found.DisplayInfo(true);
            }
            else
            {
                Console.WriteLine("Не знайдено.");
            }
        }

        private static void DeleteGame()
        {
            Console.Write("\nВведiть назву для видалення: ");
            string name = Console.ReadLine();
            int removed = games.RemoveAll(g => g.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (removed > 0)
                Console.WriteLine("Гру видалено!");
            else
                Console.WriteLine("Такої гри не знайдено!");
        }

        private static void Demonstrate()
        {
            Console.WriteLine("\n--- Демонстрацiя перевантажень ---");

            BoardGame demo1 = new BoardGame();
            BoardGame demo2 = new BoardGame("Монополiя");
            BoardGame demo3 = new BoardGame("Каркассон", "Стратегiя", 550);
            BoardGame demo4 = new BoardGame("Ticket to Ride", "Подорожi", 2, 5, 60, 8, 1100, "Days of Wonder");

            Console.WriteLine("\n1️ Звичайний вивiд:");
            demo3.DisplayInfo();

            Console.WriteLine("\n2️ Вивiд з видавцем:");
            demo3.DisplayInfo(true);

            Console.WriteLine("\n3️ Короткий формат:");
            demo4.DisplayInfo("short");

            Console.WriteLine("\n4️ Демонстрацiя поведiнки:");
            demo4.PlayDemo();
        }
    }
}
