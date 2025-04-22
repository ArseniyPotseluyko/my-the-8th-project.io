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

            // Регулярное выражение для поиска телефонных номеров
            string pattern = @"\b(?:\+?\d{1,3})?[\s\-]?(?:\(?\d{3}\)?)[\s\-]?\d{3}[\s\-]?\d{2}[\s\-]?\d{2}\b";
            Regex regex = new Regex(pattern);

            // Поиск совпадений
            MatchCollection matches = regex.Matches(input);

            // Вывод найденных номеров
            if (matches.Count > 0)
            {
                Console.WriteLine("\nНайденные номера телефонов:");
                foreach (Match match in matches)
                {
                    Console.WriteLine(match.Value);
                }
            }
            else
            {
                Console.WriteLine("\nВ тексте не найдено номеров телефонов.");
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
