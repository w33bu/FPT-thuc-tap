using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Please enter a name:");
        string inputName = Console.ReadLine();
        string normalizedName = NormalizeName(inputName);
        Console.WriteLine($"Normalized name: {normalizedName}");
    }

    static string NormalizeName(string name)
    {
        string[] words = name.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < words.Length; i++)
        {
            string word = words[i].ToLower();
            word = char.ToUpper(word[0]) + word.Substring(1);
            words[i] = word;
        }

        string normalizedName = string.Join(" ", words);
        return normalizedName;
    }
}
