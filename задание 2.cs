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

            // Регулярное выражение для поиска повторяющихся слов
            string pattern = @"\b(\w+)\s+\1\b";
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);

            // Поиск повторяющихся слов
            MatchCollection matches = regex.Matches(input);

            // Вывод результатов
            if (matches.Count > 0)
            {
                Console.WriteLine("\nНайденные повторяющиеся слова:");
                foreach (Match match in matches)
                {
                    Console.WriteLine(match.Groups[1].Value);
                }
            }
            else
            {
                Console.WriteLine("\nВ тексте нет слов, повторяющихся два раза подряд.");
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
