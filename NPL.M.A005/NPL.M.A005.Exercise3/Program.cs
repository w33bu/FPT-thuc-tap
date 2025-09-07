using System;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.WriteLine("Please enter a list of full names separated by commas:");
        string input = Console.ReadLine();
        string[] names = input.Split(',').Select(name => name.Trim()).ToArray();

        SortName(names);

        Console.WriteLine("Sorted Names:");
        foreach (string name in names)
        {
            Console.WriteLine(name);
        }
    }

    static void SortName(string[] arr)
    {
        Array.Sort(arr, (x, y) =>
        {
            string[] nameX = x.Split(' ');
            string[] nameY = y.Split(' ');

            string lastNameX = nameX.Length > 1 ? nameX[nameX.Length - 1] : nameX[0];
            string lastNameY = nameY.Length > 1 ? nameY[nameY.Length - 1] : nameY[0];

            return string.Compare(lastNameX, lastNameY);
        });
    }
}
