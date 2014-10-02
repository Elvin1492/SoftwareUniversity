
namespace School
{
    using System;
    using System.Collections.Generic;
    
    // test the program
    public class Program
    {
        static void Main(string[] args)
        {
            List<Student> studentsList = new List<Student>
            {
                new Student("Pesho", 204014, "some details"),
                new Student("Gosho",234314),
                new Student("Maria",152314),
            };

            var disciplinesList = new List<Disciplines>
            {
                new Disciplines("OOP",140, studentsList, "some details"),
                new Disciplines("JavaScript", 100, studentsList),
                new Disciplines("Structures and Algorithms", 120, studentsList),
            };

            List<Teacher> teachersList = new List<Teacher>
            {
                new Teacher("Gosho", disciplinesList, "some details"),
                new Teacher("Ivan", disciplinesList),
                new Teacher("Stoyan",disciplinesList),
            };

            Classes firstClass = new Classes("OOP", teachersList, "some details");
        }     
    }
}
