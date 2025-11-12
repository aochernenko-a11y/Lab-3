using Lab3;
using System;
using System.Diagnostics;
using System.Xml.Linq;

namespace Lab3
{
    public sealed class BoardGame : Product
    {
        public string Genre { get; set; }
        public int MinPlayers { get; set; }
        public int MaxPlayers { get; set; }
        public int DurationMinutes { get; set; }
        public int MinAge { get; set; }
        public string Publisher { get; set; }


        //=======ПЕРЕВАНТАЖЕНi КОНСТРУКТОРИ========

        // 1. Без параметрiв
        public BoardGame()
        {
            Name = "Без назви";
            Genre = "Сімейна";
            MinPlayers = 2;
            MaxPlayers = 4;
            DurationMinutes = 30;
            MinAge = 8;
            Price = 0m;
            Publisher = "Невiдомо";
            Console.WriteLine("[Конструктор 1] Без параметрiв");
        }

        // 2. З одним параметром
        public BoardGame(string title) : this()
        {
            Name = title;
            Console.WriteLine("[Конструктор 2] З одним параметром");
        }

        // 3. З кiлькома параметрами
        public BoardGame(string title, string genre, decimal price) : this(title)
        {
            Genre = genre;
            Price = price;
            Console.WriteLine("[Конструктор 3] З кiлькома параметрами");
        }

        // 4. З усiма параметрами
        public BoardGame(string title, string genre, int minPlayers, int maxPlayers, int duration, int minAge, decimal price, string publisher)
            : this(title, genre, price)
        {
            MinPlayers = minPlayers;
            MaxPlayers = maxPlayers;
            DurationMinutes = duration;
            MinAge = minAge;
            Publisher = publisher;
            Console.WriteLine("[Конструктор 4] Повна iнiцiалiзацiя");
        }

        //========ПЕРЕВАНТАЖЕНi МЕТОДИ========

        public override void DisplayInfo()
        {
            Console.WriteLine($"Назва: {Name}");
            Console.WriteLine($"Жанр: {Genre}");
            Console.WriteLine($"Гравцiв: {MinPlayers}-{MaxPlayers}");
            Console.WriteLine($"Тривалiсть: {DurationMinutes} хв");
            Console.WriteLine($"Вiк: {MinAge}+");
            Console.WriteLine($"Цiна: {Price} грн");
        }

        // Перевантажена версiя з додатковими параметрами
        public void DisplayInfo(bool withPublisher)
        {
            DisplayInfo();
            if (withPublisher)
                Console.WriteLine($"Видавець: {Publisher}");
        }

        // Перевантажена версiя для короткого виводу
        public void DisplayInfo(string format)
        {
            if (format == "short")
                Console.WriteLine($"{Name} ({Genre}) – {Price} грн");
            else
                DisplayInfo(true);
        }

        // Метод для демонстрацiї "поведiнки"
        public void PlayDemo()
        {
            Console.WriteLine($"Гра '{Name}' розпочалась! ({MinPlayers}-{MaxPlayers} гравцiв)");
        }
    }
}
