using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Employee> employees = new List<Employee>();

        while (true)
        {
            Console.WriteLine("1. Add Salaried Employee");
            Console.WriteLine("2. Add Hourly Employee");
            Console.WriteLine("3. Display Employees");
            Console.WriteLine("4. Search Employees");
            Console.WriteLine("5. Exit");

            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    AddSalariedEmployee(employees);
                    break;
                case 2:
                    AddHourlyEmployee(employees);
                    break;
                case 3:
                    DisplayEmployees(employees);
                    break;
                case 4:
                    SearchEmployees(employees);
                    break;
                case 5:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static void AddSalariedEmployee(List<Employee> employees)
    {
        Console.Write("Enter SSN: ");
        string ssn = Console.ReadLine();

        Console.Write("Enter First Name: ");
        string firstName = Console.ReadLine();

        Console.Write("Enter Last Name: ");
        string lastName = Console.ReadLine();

        Console.Write("Enter Birth Date (dd/MM/yyyy): ");
        DateTime birthDate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

        Console.Write("Enter Phone: ");
        string phone = Console.ReadLine();

        Console.Write("Enter Email: ");
        string email = Console.ReadLine();

        Console.Write("Enter Commission Rate: ");
        decimal commissionRate = decimal.Parse(Console.ReadLine());

        Console.Write("Enter Gross Sales: ");
        decimal grossSales = decimal.Parse(Console.ReadLine());

        Console.Write("Enter Basic Salary: ");
        decimal basicSalary = decimal.Parse(Console.ReadLine());

        employees.Add(new SalariedEmployee(ssn, firstName, lastName, birthDate, phone, email, commissionRate, grossSales, basicSalary));
        Console.WriteLine("Salaried Employee added successfully.");
    }

    static void AddHourlyEmployee(List<Employee> employees)
    {
        Console.Write("Enter SSN: ");
        string ssn = Console.ReadLine();

        Console.Write("Enter First Name: ");
        string firstName = Console.ReadLine();

        Console.Write("Enter Last Name: ");
        string lastName = Console.ReadLine();

        Console.Write("Enter Birth Date (dd/MM/yyyy): ");
        DateTime birthDate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

        Console.Write("Enter Phone: ");
        string phone = Console.ReadLine();

        Console.Write("Enter Email: ");
        string email = Console.ReadLine();

        Console.Write("Enter Hourly Wage: ");
        decimal wage = decimal.Parse(Console.ReadLine());

        Console.Write("Enter Working Hours: ");
        int workingHours = int.Parse(Console.ReadLine());

        employees.Add(new HourlyEmployee(ssn, firstName, lastName, birthDate, phone, email, wage, workingHours));
        Console.WriteLine("Hourly Employee added successfully.");
    }

    static void DisplayEmployees(List<Employee> employees)
    {
        Console.WriteLine("Employee List:");
        foreach (var employee in employees)
        {
            Console.WriteLine(employee.ToString());
        }
    }

    static void SearchEmployees(List<Employee> employees)
    {
        Console.Write("Enter Employee Type (Salaried/Hourly): ");
        string employeeType = Console.ReadLine().ToLower();

        Console.Write("Enter Employee First Name: ");
        string employeeName = Console.ReadLine().ToLower();

        foreach (var employee in employees)
        {
            if (employee.GetType().Name.ToLower().Contains(employeeType) && employee.FirstName.ToLower().Contains(employeeName))
            {
                Console.WriteLine(employee.ToString());
            }
        }
    }
}
