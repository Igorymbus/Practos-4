using System;
using System.Collections.Generic;

namespace DailyPlanner
{
    internal class Program
    {
        internal class Task
        {
            public string Name { get; set; }
            public string Description { get; set; }

            public Task(string name, string description)
            {
                Name = name;
                Description = description;
            }
        }

        static DateTime currentDate = DateTime.Today;
        static Dictionary<DateTime, List<Task>> tasks = new Dictionary<DateTime, List<Task>>
        {
            {
                currentDate,
                new List<Task>
                {
                    new Task("Пойти в кинотеатр", "Сходить в местный кинотеатр посмотреть новый блокбастер."),
                    new Task("Пропылесосить и помыть посуду", "Чистота - залог здоровья!"),
                    new Task("Практиковаться на гитаре", "Не забывать играть на гитаре и учить рифф!"),
                    new Task("Купить новую тетрадь", "Старая тетрадь заканчивается, нужна новая для заметок."),

                }
            },
            {
                currentDate.AddDays(1),
                new List<Task>
                {
                    new Task("Купить подводную лодку", "Нужно усилить оборону."),
                    new Task("Собрать группу", "Пора объединить старых друзей для нового проекта."),
                }
            },
            {
                currentDate.AddDays(2),
                new List<Task>
                {
                    new Task("Погулять с друзьями", "Давно мы вместе не гуляли, нужно собраться всем вместе."),
                    new Task("Прочитать книгу", " Следующая книга на очереди - Жюль Верн 'Дети капитана Гранта'"),
                }
            },
            {
                currentDate.AddDays(3),
                new List<Task>
                {
                    new Task("Проснуться", "Встать в 9 часов и сделать зарядку"),
                    new Task("Сходить на тренировку", "Не забыть заниматься плаванием."),
                    new Task("Посмотреть новую серию сериала", "Должна выйти новая серия моего любимого сериала."),
                }
            },
        };
    

        static void Main(string[] args)
        {
            int position = 1;

            Display();
            while (true)
            {
                var key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        position--;
                        if (position == 0) position = tasks[currentDate].Count;
                        break;
                    case ConsoleKey.DownArrow:
                        position++;
                        if (position > tasks[currentDate].Count) position = 1;
                        break;
                    case ConsoleKey.RightArrow:
                        currentDate = currentDate.AddDays(1);
                        if (!tasks.ContainsKey(currentDate)) tasks.Add(currentDate, new List<Task>());
                        break;
                    case ConsoleKey.LeftArrow:
                        currentDate = currentDate.AddDays(-1);
                        if (!tasks.ContainsKey(currentDate)) tasks.Add(currentDate, new List<Task>());
                        break;
                    case ConsoleKey.Enter:
                        DisplayTask(position);
                        Console.ReadKey();
                        break;
                    case ConsoleKey.Escape:
                        return;
                }
                Display(position);
            }
        }

        static void Display(int position = 0)
        {
            Console.Clear();
            Console.WriteLine($"Выб: {currentDate:D}");
            for (int i = 0; i < tasks[currentDate].Count; i++)
            {
                Console.Write((i + 1) == position ? " -> " : "    ");
                Console.WriteLine($"{i + 1}. {tasks[currentDate][i].Name}");
            }
        }

        static void DisplayTask(int position)
        {
            Console.Clear();
            Console.WriteLine($"{position}. {tasks[currentDate][position - 1].Name}");
            Console.WriteLine("-----------------");
            Console.WriteLine($"Описание: {tasks[currentDate][position - 1].Description}");
            Console.WriteLine("Выбранная дата:" + currentDate.ToString("D"));
        }
    }
}
