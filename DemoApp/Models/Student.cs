namespace DemoApp.Models;

/// <summary>
/// Represents a student entity - demonstrates properties and constructors
/// </summary>
public class Student
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; }
    public string Grade { get; set; } = string.Empty;

    // Default constructor
    public Student() { }

    // Parameterized constructor
    public Student(int id, string name, int age, string grade)
    {
        Id = id;
        Name = name;
        Age = age;
        Grade = grade;
    }

    // Override ToString for display purposes
    public override string ToString()
    {
        return $"ID: {Id}, Name: {Name}, Age: {Age}, Grade: {Grade}";
    }
}
