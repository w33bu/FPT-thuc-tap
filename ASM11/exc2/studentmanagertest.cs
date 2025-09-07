using exc2;
using NUnit.Framework;
using System;

[TestFixture]
public class StudentManagerTests
{
    private StudentManager studentManager;

    [SetUp]
    public void SetUp()
    {
        studentManager = new StudentManager();
    }

    [Test]
    public void AddStudent_ValidStudent_StudentAdded()
    {
        // Arrange
        var student = new Student { StudentId = 1, Name = "John Wick", GPA = 3.5 };

        // Act
        studentManager.AddStudent(student);

        // Assert
        Assert.AreEqual(1, studentManager.GetAllStudents().Count);
    }

    [Test]
    public void AddStudent_DuplicateStudent_ThrowsException()
    {
        // Arrange
        var student = new Student { StudentId = 1, Name = "John Wick", GPA = 3.5 };
        studentManager.AddStudent(student);

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => studentManager.AddStudent(student));
    }

    // Similarly, write tests for other methods (RemoveStudent, UpdateStudent, FindStudentById, GetSortedStudents, GetAllStudents).
}
