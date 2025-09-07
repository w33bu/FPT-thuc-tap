using System;
using System.Text.RegularExpressions;

abstract class Employee
{
    private string _phone;
    private string _email;
    public string SSN { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public string Phone
        {
        get { return _phone; }
set
        {
            if (value.Length >= 7 && int.TryParse(value, out int _))
            {
    _phone = value;
}
            else
{
    throw new ArgumentException("Phone number must contain at least 7 positive integers.");
}
        }
    }

    public string Email
    {
        get { return _email; }
        set
        {
            if (IsValidEmail(value))
            {
                _email = value;
            }
            else
            {
                throw new ArgumentException("Invalid email format.");
            }
        }
    }

    public Employee(string ssn, string firstName, string lastName, DateTime birthDate, string phone, string email)
    {
        SSN = ssn;
        FirstName = firstName;
        LastName = lastName;
        BirthDate = birthDate;
        Phone = phone;
        Email = email;
    }

    private bool IsValidEmail(string email)
    {
        string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
        return Regex.IsMatch(email, emailPattern);
    }
    public abstract decimal CalculateEarnings();

    public override string ToString()
    {
        return $"{FirstName} {LastName} (SSN: {SSN})";
    }
}
