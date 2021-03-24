using System;
using TotoshkaClasses;
using System.IO;
using System.Collections.Generic;

namespace TotoshkaRecovery
{
    class Program
    {
        static void Main(string[] args)
        {
            // Инициализирум массив улиц.
            List<Street> streets = new List<Street>();

            string[] lines = File.ReadAllLines("./../../../../Totoshka/bin/Debug/netcoreapp3.1/out.txt");
            // Заполняем массив улиц.
            for (; streets.Count < lines.Length; streets.Add(new Street(lines[streets.Count].Split(' ', StringSplitOptions.RemoveEmptyEntries)))) { }
            // Выводим содержимое на экран:
            Array.ForEach(streets.ToArray(), (Street street) => Console.Write((~street % 2 == 0) && (+street) ? street.ToString() + "\n" : ""));
            Console.WriteLine("All such streets were written!");
        }
    }
}
