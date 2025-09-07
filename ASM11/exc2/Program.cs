using exc2;
using System;

class Program
{
    static void Main(string[] args)
    {
        StudentManager studentManager = new StudentManager();

        while (true)
        {
            Console.WriteLine("1. add student");
            Console.WriteLine("2. delete student");
            Console.WriteLine("3. update student info");
            Console.WriteLine("4. find student by ID");
            Console.WriteLine("5. oder student by GPA");
            Console.WriteLine("6. student list");
            Console.WriteLine("7. exit");

            Console.Write("choose what you want to do: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Enter Sudent ID: ");
                    int studentId = int.Parse(Console.ReadLine());
                    Console.Write("Enter Sudent name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter GPA: ");
                    double gpa = double.Parse(Console.ReadLine());

                    Student newStudent = new Student { StudentId = studentId, Name = name, GPA = gpa };
                    studentManager.AddStudent(newStudent);
                    Console.WriteLine("Student added.");
                    break;
                case 2:
                    Console.Write("Enter student ID need to be deleted: ");
                    int idToRemove = int.Parse(Console.ReadLine());
                    try
                    {
                        studentManager.RemoveStudent(idToRemove);
                        Console.WriteLine("Student deleted.");
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                case 3:
                    Console.Write("Enter student ID need to be updated: ");
                    int idToUpdate = int.Parse(Console.ReadLine());
                    Student existingStudent = studentManager.FindStudentById(idToUpdate);
                    if (existingStudent != null)
                    {
                        Console.Write("new student name: ");
                        existingStudent.Name = Console.ReadLine();
                        Console.Write("new GPA: ");
                        existingStudent.GPA = double.Parse(Console.ReadLine());
                        studentManager.UpdateStudent(existingStudent);
                        Console.WriteLine("student info updated.");
                    }
                    else
                    {
                        Console.WriteLine("No student with given ID.");
                    }
                    break;
                case 4:
                    Console.Write("enter student ID: ");
                    int idToFind = int.Parse(Console.ReadLine());
                    Student foundStudent = studentManager.FindStudentById(idToFind);
                    if (foundStudent != null)
                    {
                        Console.WriteLine($"student: ID: {foundStudent.StudentId}, name: {foundStudent.Name}, GPA: {foundStudent.GPA}");
                    }
                    else
                    {
                        Console.WriteLine("\"No student with given ID.");
                    }
                    break;
                case 5:
                    var sortedStudents = studentManager.GetSortedStudents();
                    Console.WriteLine("student list order by GPA:");
                    foreach (var student in sortedStudents)
                    {
                        Console.WriteLine($"ID: {student.StudentId}, name: {student.Name}, GPA: {student.GPA}");
                    }
                    break;
                case 6:
                    var allStudents = studentManager.GetAllStudents();
                    Console.WriteLine("Danh sách sinh viên:");
                    foreach (var student in allStudents)
                    {
                        Console.WriteLine($"ID: {student.StudentId}, name: {student.Name}, GPA: {student.GPA}");
                    }
                    break;
                case 7:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("invalid choice.");
                    break;
            }
        }
    }
}
