using NPL.M.A008.Exercise;

namespace NPL.M.A008.Exercise
{
    class Student
    {
        public string Name { get; set; }
        public string Class { get; set; }
        public string Gender { get; set; }
        public string Relationship { get; set; }
        public DateTime EntryDate { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public decimal Mark { get; set; }
        public string Grade { get; set; }
        public Student(string name, string className, string gender, int age, string relationship = "Single", decimal mark = 0, string grade = "F")
        {
            Name = name;
            Class = className;
            Gender = gender;
            Age = age;
            Relationship = relationship;
            Mark = mark;
            Grade = grade;
        }
        public void Graduate(double gradePoint = 0)
        {
            if (gradePoint >= 4.0)
            {
                Grade = "A";
            }
            else if (gradePoint >= 3.7 && gradePoint<4.0)
            {
                Grade = "A-";
            }
            else if (gradePoint >= 3.3 && gradePoint < 3.7)
            {
                Grade = "B+";
            }
            else if (gradePoint >= 3.0 && gradePoint < 3.3)
            {
                Grade = "B";
            }
            else if (gradePoint >= 2.7 && gradePoint < 3.0)
            {
                Grade = "B-";
            }
            else if (gradePoint >= 2.3 && gradePoint < 2.7)
            {
                Grade = "C+";
            }
            else if (gradePoint >= 2.0 && gradePoint < 2.3)
            {
                Grade = "C";
            }
            else if (gradePoint >= 1.0 && gradePoint < 2.0)
            {
                Grade = "D";
            }
            else if (gradePoint < 1.0)
            {
                Grade = "F(Fail)";
            }
            else
            {
                Console.WriteLine("invalid grade, please recheck");
            }
        }
        public string ToString(string name, string className, string gender, string relationship,
                       int age, string grade)
        {
            return $"Name: {name}, Class: {className}, Gender: {gender}, Relationship: {relationship}, Age: {age}, Grade: {grade}";
        }

    }
}
class Program
{
    static void Main(string[] args)
    {
        Student student1 = new Student(name: "John", className: "ClassA", gender: "Male", age: 20, relationship: "Single", mark: 85, grade: "A");
        student1.Graduate(4.1);

        string studentInfo1 = student1.ToString(student1.Name, student1.Class, student1.Gender,
            student1.Relationship, student1.Age, student1.Grade);

        Console.WriteLine(studentInfo1);

        Student student2 = new Student(name: "Alice", className: "ClassB", gender: "Female", age:21);
        student2.Graduate();

        string studentInfo2 = student2.ToString(student2.Name, student2.Class, student2.Gender,
            student2.Relationship, student2.Age, student2.Grade);

        Console.WriteLine(studentInfo2);
    }
}
