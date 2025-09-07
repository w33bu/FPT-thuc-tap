using exc2;
using System;
using System.Collections.Generic;
using System.Linq;

public class StudentManager
{
    private List<Student> students;

    public StudentManager()
    {
        students = new List<Student>();
    }

    public void AddStudent(Student student)
    {
        if (students.Any(s => s.StudentId == student.StudentId))
        {
            throw new InvalidOperationException("Student ID already exist.");
        }
        students.Add(student);
    }

    public void RemoveStudent(int studentId)
    {
        var studentToRemove = students.FirstOrDefault(s => s.StudentId == studentId);
        if (studentToRemove != null)
        {
            students.Remove(studentToRemove);
        }
        else
        {
            throw new InvalidOperationException("can't find student with that ID.");
        }
    }

    public void UpdateStudent(Student student)
    {
        var existingStudent = students.FirstOrDefault(s => s.StudentId == student.StudentId);
        if (existingStudent != null)
        {
            existingStudent.Name = student.Name;
            existingStudent.GPA = student.GPA;
        }
        else
        {
            throw new InvalidOperationException("can't find student with that ID.");
        }
    }

    public Student FindStudentById(int studentId)
    {
        return students.FirstOrDefault(s => s.StudentId == studentId);
    }

    public List<Student> GetSortedStudents()
    {
        return students.OrderBy(s => s.GPA).ToList();
    }

    public List<Student> GetAllStudents()
    {
        return students;
    }
}
