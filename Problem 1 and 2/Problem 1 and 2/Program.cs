using System;
using System.Collections.Generic;
using System.Linq;

public class StudentManager
{
    // Dictionary to store students and their subjects by class name
    private Dictionary<string, Dictionary<string, HashSet<string>>> studentData;

    public StudentManager()
    {
        studentData = new Dictionary<string, Dictionary<string, HashSet<string>>>();

        // Sample data initialization
        AddEntry("Aisha Khan", "Computer Science", new HashSet<string> { "English", "Math", "Programming" });
        AddEntry("Luca Rossi", "Computer Science", new HashSet<string> { "English", "Math", "Programming" });
        AddEntry("Emiko Tanaka", "Computer Science", new HashSet<string> { "English", "Math", "Programming" });
        AddEntry("Mateo Garcia", "Computer Science", new HashSet<string> { "English", "Math", "Programming" });

        AddEntry("Zara Patel", "Mechanical", new HashSet<string> { "English", "Math", "Drawing" });
        AddEntry("Ethan Williams", "Mechanical", new HashSet<string> { "English", "Math", "Drawing" });

        AddEntry("Leila Muller", "Bio Medical", new HashSet<string> { "English", "Biology" });
    }

    // Adding a new student entry
    public void AddEntry(string student, string className, HashSet<string> subjects)
    {
        if (!studentData.ContainsKey(className))
        {
            studentData[className] = new Dictionary<string, HashSet<string>>();
        }

        studentData[className][student] = subjects;
    }

    // Query for counting how many students are studying English
    public int CountStudentsStudyingSubject(string subject)
    {
        return studentData.Values.SelectMany(classDict => classDict.Values).Count(subjects => subjects.Contains(subject));
    }

    // Query for counting how many students are studying either Programming or Drawing
    public int CountStudentsStudyingSubjects(List<string> subjects)
    {
        return studentData.Values.SelectMany(classDict => classDict.Values)
            .Count(studiedSubjects => subjects.Any(subject => studiedSubjects.Contains(subject)));
    }

    // Check if student exists
    public bool IsStudentPresent(string student)
    {
        return studentData.Values.Any(classDict => classDict.ContainsKey(student));
    }

    // Check if student is studying a specific subject
    public bool IsStudentStudyingSubject(string student, string subject)
    {
        return studentData.Values.Any(classDict =>
            classDict.ContainsKey(student) && classDict[student].Contains(subject));
    }

    public static void Main(string[] args)
    {
        StudentManager manager = new StudentManager();

        // Problem 1 queries
        Console.WriteLine("Number of students studying English: " + manager.CountStudentsStudyingSubject("English"));
        Console.WriteLine("Number of students studying Programming or Drawing: " + manager.CountStudentsStudyingSubjects(new List<string> { "Programming", "Drawing" }));

        // Adding a new student
        manager.AddEntry("Sophia Brown", "Bio Medical", new HashSet<string> { "Math", "Biology" });

        // Problem 2 queries
        Console.WriteLine("Is Luca Rossi present: " + manager.IsStudentPresent("Luca Rossi"));
        Console.WriteLine("Is Luca Rossi studying Biology: " + manager.IsStudentStudyingSubject("Luca Rossi", "Biology"));
    }
}