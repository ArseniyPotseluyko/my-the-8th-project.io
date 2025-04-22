using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        try
        {
            // Ввод текста с клавиатуры
            Console.Write("Введите текст: ");
            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentException("Текст не должен быть пустым.");
            }

            // Регулярное выражение для поиска дат в формате "дд.мм.гггг"
            string pattern = @"\b(0[1-9]|[12][0-9]|3[01])\.(0[1-9]|1[0-2])\.(\d{4})\b";
            Regex regex = new Regex(pattern);

            // Поиск всех совпадений
            MatchCollection matches = regex.Matches(input);

            // Вывод найденных дат
            if (matches.Count > 0)
            {
                Console.WriteLine("\nНайденные даты:");
                foreach (Match match in matches)
                {
                    Console.WriteLine(match.Value);
                }
            }
            else
            {
                Console.WriteLine("\nВ тексте нет дат формата дд.мм.гггг.");
            }
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Произошла ошибка: {ex.Message}");
        }
    }
}
