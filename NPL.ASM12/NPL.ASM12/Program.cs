using System;
using System.Collections.Generic;
using System.IO;
using OfficeOpenXml;

namespace StudentManagementApp
{
    class Student
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            List<Student> students = new List<Student>();

            while (true)
            {
                Console.WriteLine("1. add student");
                Console.WriteLine("2. show student list");
                Console.WriteLine("3. save list to  excel");
                Console.WriteLine("4. read list from excel");
                Console.WriteLine("5. exit");
                Console.Write("choose one of the option: ");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddStudent(students);
                        break;
                    case 2:
                        DisplayStudents(students);
                        break;
                    case 3:
                        SaveToExcel(students);
                        break;
                    case 4:
                        ReadFromExcel();
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("invalid option, choose again.");
                        break;
                }
            }
        }

        static void AddStudent(List<Student> students)
        {
            Student student = new Student();
            Console.Write("Student's First name: ");
            student.FirstName = Console.ReadLine();
            Console.Write("Student's last name: ");
            student.LastName = Console.ReadLine();
            Console.Write("Student Email: ");
            student.Email = Console.ReadLine();
            // Validate email
            if (!student.Email.EndsWith("outlook.com") && !student.Email.EndsWith("gmail.com"))
            {
                Console.WriteLine("Email invalid, must end with outlook.com or gmail.com.");
                return;
            }
            Console.Write("student's address: ");
            student.Address = Console.ReadLine();
            Console.Write("student's phone number: ");
            student.PhoneNumber = Console.ReadLine();
            // Validate phone number
            if (!student.PhoneNumber.StartsWith("84") && student.PhoneNumber.Length != 12)
            {
                Console.WriteLine("phone number invalid, must start with '84' and have 12 number.");
                return;
            }
            student.Id = Guid.NewGuid();
            students.Add(student);
            Console.WriteLine("Student added.");
        }

        static void DisplayStudents(List<Student> students)
        {
            Console.WriteLine("student list:");
            foreach (var student in students)
            {
                Console.WriteLine($"Id: {student.Id}, First and last name: {student.FirstName} {student.LastName}, Email: {student.Email}, address: {student.Address}, phone number: {student.PhoneNumber}");
            }
        }

        static void SaveToExcel(List<Student> students)
        {
            using (var package = new ExcelPackage(new FileInfo("Students.xlsx")))
            {
                var worksheet = package.Workbook.Worksheets.Add("student");

                worksheet.Cells["A1"].Value = "Id";
                worksheet.Cells["B1"].Value = "first name";
                worksheet.Cells["C1"].Value = "last name";
                worksheet.Cells["D1"].Value = "Email";
                worksheet.Cells["E1"].Value = "address";
                worksheet.Cells["F1"].Value = "phone number";

                int row = 2;
                foreach (var student in students)
                {
                    worksheet.Cells[$"A{row}"].Value = student.Id;
                    worksheet.Cells[$"B{row}"].Value = student.FirstName;
                    worksheet.Cells[$"C{row}"].Value = student.LastName;
                    worksheet.Cells[$"D{row}"].Value = student.Email;
                    worksheet.Cells[$"E{row}"].Value = student.Address;
                    worksheet.Cells[$"F{row}"].Value = student.PhoneNumber;
                    row++;
                }

                package.Save();
                Console.WriteLine("list saved to Students.xlsx.");
            }
        }

        static void ReadFromExcel()
        {
            FileInfo existingFile = new FileInfo("Students.xlsx");
            using (ExcelPackage package = new ExcelPackage(existingFile))
            {
                var worksheet = package.Workbook.Worksheets[0];
                int rowCount = worksheet.Dimension.Rows;
                for (int row = 2; row <= rowCount; row++)
                {
                    Console.WriteLine($"Id: {worksheet.Cells[row, 1].Value}, Full name: {worksheet.Cells[row, 2].Value} {worksheet.Cells[row, 3].Value}, Email: {worksheet.Cells[row, 4].Value}, address: {worksheet.Cells[row, 5].Value}, phone number: {worksheet.Cells[row, 6].Value}");
                }
            }
        }
    }
}
