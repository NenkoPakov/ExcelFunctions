using System;
using System.Linq;
using System.Collections.Generic;

namespace Excel_Functions
{
    class Program
    {
        static void Main(string[] args)
        {
            var rows = int.Parse(Console.ReadLine());

            var header = Console.ReadLine().Split(", ");

            var table = new string[rows][];

            table[0] = new string[header.Length];

            for (int i = 0; i < header.Length; i++)
            {
                table[0][i] = header[i];
            }

            for (int row = 1; row < table.GetLength(0); row++)
            {
                var input = Console.ReadLine().Split(", ");

                table[row] = new string[header.Length];

                for (int col = 0; col < header.Length; col++)
                {
                    table[row][col] = input[col];
                }
            }

            var command = Console.ReadLine().Split();

            if (command[0] == "sort")
            {
                var indexOfParameter = Array.IndexOf(table[0], command[1]);
                table = table.Skip(1).OrderBy(x => x[indexOfParameter]).ToArray();

                Console.WriteLine(string.Join(" | ", header));

                for (int row = 0; row < table.Length; row++)
                {
                    Console.WriteLine(string.Join(" | ", table[row]));
                }
            }
            else if (command[0] == "hide")
            {
                var indexOfParameter = Array.IndexOf(table[0], command[1]);

                for (int row = 0; row < table.Length; row++)
                {
                    var tableToList = new List<string>(table[row]);

                    tableToList.RemoveAt(indexOfParameter);

                    Console.WriteLine(string.Join(" | ", tableToList));

                    table[row] = tableToList.ToArray();
                }
            }
            else if (command[0] == "filter")
            {
                var indexOfParameter = Array.IndexOf(table[0], command[1]);

                table = table.Where(x => x[0]== command[2]).ToArray();

                Console.WriteLine(string.Join(" | ", header));

                for (int row = 0; row < table.Length; row++)
                {
                    Console.WriteLine(string.Join(" | ", table[row]));
                }

            }

        }
    }
}
