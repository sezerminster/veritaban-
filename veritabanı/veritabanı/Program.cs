using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Student
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int Age { get; set; }

    public string Email { get; set; }

    public string School { get; set; }
}


public interface IStudentRepository
{

    IEnumerable<Student> GetAll();

    Student Get(int id);

    void Add(Student student);

    void Update(Student student);

    void Delete(int id);
}

public class StudentRepository : IStudentRepository
{

    private readonly List<Student> _students;


    public StudentRepository()
    {
        _students = new List<Student>();
    }


    public IEnumerable<Student> GetAll()
    {
        return _students;
    }

    public Student Get(int id)
    {
        return _students.FirstOrDefault(u => u.Id == id) ?? new Student();
    }

    public void Add(Student student)
    {

        student.Id = _students.Count + 1;
        _students.Add(student);
    }


    public void Update(Student student)
    {

        var existingStudent = Get(student.Id);
        existingStudent.Name = student.Name;
        existingStudent.Age = student.Age;
        existingStudent.Email = student.Email;
        existingStudent.School = student.School;

    }


    public void Delete(int id)
    {

        var student = Get(id);

        _students.Remove(student);
    }
}


class Program
{
    static void Main(string[] args)
    {

        var repository = new StudentRepository();
        repository.Add(new Student { Name = "Oguzhan", Email = "oguzhansezer14@gmail.com", Age = 25, School = "Ankara University" });
        repository.Add(new Student { Name = "Atakan", Email = "atakancevik@gmail.com", Age = 22, School = "ODTU" });
        repository.Add(new Student { Name = "Osman", Email = "osman@gmail.com", Age = 28, School = "Bahçeşehir" });
        repository.Add(new Student { Name = "Furkan", Email = "furkan@gmail.com", Age = 23, School = "Gazi" });
        var sezer = repository.Get(1);
        Console.WriteLine($"Name: {sezer.Name}, Email: {sezer.Email},Age:{sezer.Age},School:{sezer.School}");


        var allStudents = repository.GetAll();
        foreach (var student in allStudents)
        {
            Console.WriteLine($"Name: {student.Name}, Email: {student.Email},Age:{student.Age},Age:{student.School}");
        }
        repository.Update(new Student { Id = 1, Name = "Fatih", Email = "fatih1414@gmail.com", Age = 17, School = "Akdeniz Üniversitesi" });


        var osman = repository.Get(1);
        Console.WriteLine($"Name: {osman.Name}, Email: {osman.Email}, Age:{osman.Age},School:{osman.School}");
        Console.ReadLine();
    }
}