using System;
using TotoshkaClasses;
using System.IO;
using System.Collections.Generic;

namespace Totoshka
{
    class Program
    {
        static void Main(string[] args)
        {
            bool checker = true;
            string[] buffer;
            List<Street> streets = new List<Street>();

            Console.WriteLine("Please, write the amount of streets to read!");
            int.TryParse(Console.ReadLine(), out int amountOfStreets);
            string[] lines = File.ReadAllLines("data.txt");
            foreach (string line in lines)
            {
                buffer = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                // Проверяем, состоит ли строка из uint + по длине проверяем.
                if ((buffer.Length <= 1) ||
                    !Array.TrueForAll(buffer, (string value) => (value == buffer[0]) ? true : uint.TryParse(value, out uint useless)))
                {
                    checker = false;
                }
            }
            // Если в строчках мусор - заполняем список рандомно сгенерированными улицами.
            if (!checker)
            {
                for (; streets.Count < amountOfStreets; streets.Add(new Street())) { }
            }
            // Иначе - заполняем список улицами, предусмотрительно ограничив счётчик улиц.
            else
            {
                amountOfStreets = Math.Min(amountOfStreets, lines.Length);
                for (; streets.Count < amountOfStreets; streets.Add(new Street(lines[streets.Count].Split(' ', StringSplitOptions.RemoveEmptyEntries)))) { }
            }
            Array.ForEach(streets.ToArray(), Console.WriteLine);
            // Выводим все строчки в файл.
            File.WriteAllLines("out.txt", Array.ConvertAll(streets.ToArray(), (Street street) => street.pureString()));
        }
    }
}
