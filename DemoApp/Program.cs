using DemoApp.Helpers;
using DemoApp.Interfaces;
using DemoApp.Models;
using DemoApp.Services;

// ============================================
// Student Management System - Demo Application
// ============================================
IStudentService studentService = new StudentService();

// Seed some initial data
SeedData(studentService);

bool running = true;
while (running)
{
    DisplayMenu();
    int choice = InputHelper.GetValidInteger("Enter your choice: ", 1, 7);

    switch (choice)
    {
        case 1:
            AddNewStudent(studentService);
            break;
        case 2:
            ViewAllStudents(studentService);
            break;
        case 3:
            SearchStudentById(studentService);
            break;
        case 4:
            UpdateExistingStudent(studentService);
            break;
        case 5:
            DeleteExistingStudent(studentService);
            break;
        case 6:
            ShowStatistics(studentService);
            break;
        case 7:
            running = false;
            Console.WriteLine("Thank you for using Student Management System!");
            break;
    }
}


static void DisplayMenu()
{
    Console.WriteLine("\n========== STUDENT MANAGEMENT SYSTEM ==========");
    Console.WriteLine("1. Add New Student");
    Console.WriteLine("2. View All Students");
    Console.WriteLine("3. Search Student by ID");
    Console.WriteLine("4. Update Student");
    Console.WriteLine("5. Delete Student");
    Console.WriteLine("6. Show Statistics");
    Console.WriteLine("7. Exit");
    Console.WriteLine("================================================");
}

static void SeedData(IStudentService service)
{
    service.AddStudent(new Student { Name = "Alice Johnson", Age = 20, Grade = "A" });
    service.AddStudent(new Student { Name = "Bob Smith", Age = 22, Grade = "B" });
    service.AddStudent(new Student { Name = "Charlie Brown", Age = 21, Grade = "A" });
    service.AddStudent(new Student { Name = "Diana Ross", Age = 19, Grade = "C" });
}

static void AddNewStudent(IStudentService service)
{
    Console.WriteLine("\n--- Add New Student ---");
    string name = InputHelper.GetNonEmptyString("Enter student name: ");
    int age = InputHelper.GetValidInteger("Enter student age (16-100): ", 16, 100);
    string grade = InputHelper.GetNonEmptyString("Enter student grade (A/B/C/D/F): ");

    var student = new Student(0, name, age, grade.ToUpper());
    service.AddStudent(student);
    Console.WriteLine($"Student '{name}' added successfully with ID: {student.Id}");
}

static void ViewAllStudents(IStudentService service)
{
    Console.WriteLine("\n--- All Students ---");
    var students = service.GetAllStudents();
    if (students.Count == 0)
    {
        Console.WriteLine("No students found.");
        return;
    }

    foreach (var student in students)
    {
        Console.WriteLine(student);
    }
}

static void SearchStudentById(IStudentService service)
{
    Console.WriteLine("\n--- Search Student ---");
    int id = InputHelper.GetValidInteger("Enter student ID: ", 1);
    var student = service.GetStudentById(id);

    if (student is null)
    {
        Console.WriteLine($"Student with ID {id} not found.");
    }
    else
    {
        Console.WriteLine("Student found:");
        Console.WriteLine(student);
    }
}

static void UpdateExistingStudent(IStudentService service)
{
    Console.WriteLine("\n--- Update Student ---");
    int id = InputHelper.GetValidInteger("Enter student ID to update: ", 1);
    var student = service.GetStudentById(id);

    if (student is null)
    {
        Console.WriteLine($"Student with ID {id} not found.");
        return;
    }

    Console.WriteLine($"Current details: {student}");
    string name = InputHelper.GetNonEmptyString("Enter new name: ");
    int age = InputHelper.GetValidInteger("Enter new age (16-100): ", 16, 100);
    string grade = InputHelper.GetNonEmptyString("Enter new grade (A/B/C/D/F): ");

    student.Name = name;
    student.Age = age;
    student.Grade = grade.ToUpper();

    if (service.UpdateStudent(student))
    {
        Console.WriteLine("Student updated successfully!");
    }
}

static void DeleteExistingStudent(IStudentService service)
{
    Console.WriteLine("\n--- Delete Student ---");
    int id = InputHelper.GetValidInteger("Enter student ID to delete: ", 1);

    string result = service.DeleteStudent(id) 
        ? "Student deleted successfully!" 
        : $"Student with ID {id} not found.";
    Console.WriteLine(result);
}

static void ShowStatistics(IStudentService service)
{
    Console.WriteLine("\n--- Statistics ---");
    var students = service.GetAllStudents();
    Console.WriteLine($"Total Students: {students.Count}");
    Console.WriteLine($"Average Age: {service.CalculateAverageAge():F1}");

    Console.WriteLine("\nStudents by Grade:");
    string[] grades = { "A", "B", "C", "D", "F" };
    for (int i = 0; i < grades.Length; i++)
    {
        var studentsInGrade = service.GetStudentsByGrade(grades[i]);
        Console.WriteLine($"  Grade {grades[i]}: {studentsInGrade.Count} student(s)");
    }
}
