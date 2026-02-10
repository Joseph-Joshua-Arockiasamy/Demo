using DemoApp.Interfaces;
using DemoApp.Models;

namespace DemoApp.Services;

/// <summary>
/// Implementation of student service - demonstrates collections, LINQ, and business logic
/// </summary>
public class StudentService : IStudentService
{
    private readonly List<Student> _students = new();
    private int _nextId = 1;

    public void AddStudent(Student student)
    {
        student.Id = _nextId++;
        _students.Add(student);
    }

    public Student? GetStudentById(int id)
    {
        return _students.FirstOrDefault(s => s.Id == id);
    }

    public List<Student> GetAllStudents()
    {
        return _students;
    }

    public bool UpdateStudent(Student student)
    {
        var existingStudent = GetStudentById(student.Id);
        
        if (existingStudent == null)
        {
            return false;
        }

        existingStudent.Name = student.Name;
        existingStudent.Age = student.Age;
        existingStudent.Grade = student.Grade;
        return true;
    }

    public bool DeleteStudent(int id)
    {
        var student = GetStudentById(id);
        
        if (student == null)
        {
            return false;
        }

        return _students.Remove(student);
    }

    public List<Student> GetStudentsByGrade(string grade)
    {
        return _students.Where(s => s.Grade.Equals(grade, StringComparison.OrdinalIgnoreCase)).ToList();
    }

    public double CalculateAverageAge()
    {
        if (_students.Count == 0)
        {
            return 0;
        }

        return _students.Average(s => s.Age);
    }
}
