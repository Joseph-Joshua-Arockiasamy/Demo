using DemoApp.Models;

namespace DemoApp.Interfaces;

/// <summary>
/// Interface for student operations - demonstrates abstraction
/// </summary>
public interface IStudentService
{
    void AddStudent(Student student);
    Student? GetStudentById(int id);
    List<Student> GetAllStudents();
    bool UpdateStudent(Student student);
    bool DeleteStudent(int id);
    List<Student> GetStudentsByGrade(string grade);
    double CalculateAverageAge();
    List<Student> GetStudentsByEmail(string? email);
}
