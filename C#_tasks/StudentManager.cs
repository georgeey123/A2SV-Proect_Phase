using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;


class Student
{
    public string Name { get; set; }
    public int Age { get; set; }
    public readonly int RollNumber;
    public string Grade {get; set;}

    public Student()
    {

    }

    public Student(string name, int rollnumber, string grade)
    {
        Name = name;
        RollNumber = rollnumber;
        Grade = grade;
    }

    public override string ToString()
    {
        return $"Name: {Name}, Age: {Age}, Roll Number: {RollNumber}, Grade: {Grade}";
    }
}

class StudentList<T>
{
    private List<T> students = new List<T>();

    public void Add(T student)
    {
        students.Add(student);
    }

    public void Remove(T student)
    {
        students.Remove(student);
    }

    public IEnumerable<T> Search(Func<T, bool> predicate)
    {
        return students.Where(predicate);
    }

    public void Print()
    {
        foreach (var student in students)
        {
            Console.WriteLine(student.ToString());
        }
    }

    public void SerializeToJson(string fileName)
    {
        JsonSerializerOptions jsonOptions = new JsonSerializerOptions { WriteIndented = true };
        string jsonString = JsonSerializer.Serialize(students, jsonOptions);
        File.WriteAllText(fileName, jsonString);
    }


    public void DeserializeFromJson(string fileName)
    {
        string jsonString = File.ReadAllText(fileName);
        students = JsonSerializer.Deserialize<List<T>>(jsonString);
    }

}


class Program
{
    static void Main(string[] args)
    {
        StudentList<Student> studentList = new StudentList<Student>();

        studentList.Add(new Student("Haqq", 1, "B"){Age = 20});
        studentList.Add(new Student("George", 2,  "A"){Age = 21});
        studentList.Add(new Student("Eben", 3, "C"){Age = 22});

        // Search for a student by name
        string searchName = "Haqq";
        var resultByName = studentList.Search(student => student.Name == searchName);
        foreach (var student in resultByName)
        {
            Console.WriteLine(student);
        }

        // Search for a student by roll number
        int searchRollNumber = 2;
        var resultByRollNumber = studentList.Search(student => student.RollNumber == searchRollNumber);
        foreach (var student in resultByRollNumber)
        {
            Console.WriteLine(student);
        }

        Console.WriteLine("Seriazling Students...");
        studentList.SerializeToJson("students.json");
        Console.WriteLine("Done seriazling students to students.json");


        StudentList<Student> deserializedStudentList = new StudentList<Student>();
        deserializedStudentList.DeserializeFromJson("students.json");
        Console.WriteLine("Deserializing Students...");
        deserializedStudentList.Print();
    }
}
