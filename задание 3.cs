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

            // Регулярное выражение для поиска предложений с знаками препинания
            string pattern = @"[^.!?]*[,.!?;:][^.!?]*[.!?]";
            Regex regex = new Regex(pattern);

            // Поиск совпадений
            MatchCollection matches = regex.Matches(input);

            // Вывод найденных предложений
            if (matches.Count > 0)
            {
                Console.WriteLine("\nНайденные предложения содержащие знаки препинания:");
                foreach (Match match in matches)
                {
                    Console.WriteLine(match.Value.Trim());
                }
            }
            else
            {
                Console.WriteLine("\nВ тексте нет предложений с знаками препинания.");
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
