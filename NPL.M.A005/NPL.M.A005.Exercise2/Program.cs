using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        Console.WriteLine("Please enter an email address:");
        string inputEmail = Console.ReadLine();

        if (IsEmail(inputEmail))
        {
            Console.WriteLine("Email address is valid.");
        }
        else
        {
            Console.WriteLine("Email address is not valid.");
        }
    }

    static bool IsEmail(string email)
    {
        string emailPattern = @"^[A-Za-z0-9!#$%&'*+\-/=?^_`{|}~]+(\.[A-Za-z0-9!#$%&'*+\-/=?^_`{|}~]+)*" +
                              @"@[A-Za-z0-9]+([-.][A-Za-z0-9]+)*\.[A-Za-z]{2,}$";

        if (Regex.IsMatch(email, emailPattern))
        {
            if (email.IndexOf('.') != -1)
            {
                int firstDotIndex = email.IndexOf('.');
                int lastDotIndex = email.LastIndexOf('.');

                if (firstDotIndex != 0 && lastDotIndex != email.Length - 1 && firstDotIndex == lastDotIndex)
                {
                    return true;
                }
            }
        }

        return false;
    }
}
