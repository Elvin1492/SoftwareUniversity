namespace StudentsSystem.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Data.Entity;
    using System.Linq;
    using System.Runtime.InteropServices.ComTypes;
    using System.Text;
    using System.Threading;

    using StudentsSystem.Data;
    using StudentsSystem.Data.Migrations;
    using StudentsSystem.Data.Repositories;
    using StudentsSystem.Models;

    public class ConsoleClient
    {
        public static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentsSystemDbContext,Configuration>());

            Console.WriteLine("Waiting for seed to populate database ...\n");

            Thread.Sleep(000);
            // activating database
            var dbContext = new StudentsSystemDbContext();
            var students = dbContext.Students.Count();
            Thread.Sleep(5000);

            AllStudentsWithHomeworks(dbContext);
            AllCousesWithResources(dbContext);

            var javaScriptCourse = new Course
            {
                Name = "JavaScript",
                Desciption = "Learn to code in JavaScript",
                StartDate = new DateTime(2014, 8, 9),
                EndDate = new DateTime(2014, 9, 14),
                Price = 100,
                HasTeamwork = true,
            };

            var javaScriptCourseResource = new Resource
            {
                Name = "JavaScript Course presentations.",
                Type = ResourceType.Presentation,
                Content = "https://softuni.bg/trainings/1101/JavaScript-Basics-Mar-2015",
            };

         AddNewCourseWithResources(javaScriptCourse, javaScriptCourseResource, dbContext);

            var studentStavrii = new Student
            {
                Name = "Stavrii Stavrev",
                PhoneNumber = "0886123456",
                RegistrationDate = new DateTime(2015, 1, 2),
                BirthDate = new DateTime(1933, 3, 3),
                IsWorking = false,
            };
//
           AddNewStudent(studentStavrii, dbContext);

            var reflectionResource = new Resource
            {
                Name = "C# Reflection presentation",
                Content = "Learn how to make your app do fancy stuff at run-time.",
                Type = ResourceType.Presentation,
            };

          AddNewResource(reflectionResource, dbContext);
        }

        private static void AddNewResource(Resource resource, IStudentsSystemDbContext dbContext)
        {
            var sb = new StringBuilder();

            sb.AppendLine("-------------------------------------------\n    ADDING NEW RESOURCE\n" +
            "-------------------------------------------\n");

            var resourcesDb = new GenericRepository<Resource>(dbContext);

            resourcesDb.Add(resource);
            resourcesDb.SaveChanges();

            var addedResource = resourcesDb.FindBy(r => r.Name == resource.Name).FirstOrDefault();

            sb.AppendLine("Resource successfully added.\n---------------------------------------\n");
            sb.AppendLine(addedResource.ToString());

            Console.WriteLine(sb);
        }

        private static void AddNewStudent(Student student, StudentsSystemDbContext dbContext)
        {
            var sb = new StringBuilder();

            sb.AppendLine("-------------------------------------------\n    ADDING NEW STUDENT\n" +
            "-------------------------------------------\n");

            var studentsDb = new GenericRepository<Student>(dbContext);

            studentsDb.Add(student);
            studentsDb.SaveChanges();

            var addedStudent = studentsDb.FindBy(s => s.Name == student.Name).FirstOrDefault();

            sb.AppendLine("Student successfully added.\n---------------------------------------\n");
            sb.AppendLine(addedStudent.ToString());

            Console.WriteLine(sb);
        }

        private static void AddNewCourseWithResources(
            Course course,
            Resource resource,
            StudentsSystemDbContext dbContext)
        {
            var sb = new StringBuilder();

            sb.AppendLine("-------------------------------------------\n    ADDING COURSE WITH RESOURCES\n" +
            "-------------------------------------------\n");

            var coursesDb = new GenericRepository<Course>(dbContext);

            coursesDb.Add(course);
            coursesDb.SaveChanges();

            course.Resources.Add(resource);
            coursesDb.SaveChanges();

            var addedCourse = coursesDb.FindBy(c => c.Name == course.Name).FirstOrDefault();
            var addedResource = addedCourse.Resources.FirstOrDefault();
            sb.AppendLine("Course successfully added.\n---------------------------------------\n");
            sb.AppendLine(addedCourse.ToString());
            sb.AppendLine("Couse resouces:\n------------------------------\n");
            sb.AppendLine(addedResource.ToString());

            Console.WriteLine(sb);
        }

        private static void AllCousesWithResources(StudentsSystemDbContext dbContext)
        {
            var coursesDb = new GenericRepository<Course>(dbContext);

            var sb = new StringBuilder();

            sb.AppendLine("-------------------------------------------\n    COURSES WITH RESOURCES\n" +
            "-------------------------------------------\n");

            foreach (var course in coursesDb.All().Include(c => c.Resources).ToList())
            {
                sb.AppendLine(course.ToString());
                sb.AppendLine("Course resouces: \n-----------------------");

                foreach (var resource in course.Resources.ToList())
                {
                    sb.AppendLine(resource.ToString());
                }

                sb.AppendLine("--------------------------------\n");
            }

            Console.WriteLine(sb);
        }

        private static void AllStudentsWithHomeworks(IStudentsSystemDbContext dbContext)
        {
            var studentsDb = new GenericRepository<Student>(dbContext);

            var sb = new StringBuilder();

            sb.AppendLine("-------------------------------------------\n    STUDENTS WITH HOMEWORK SUBMISSIONNS\n" +
            "-------------------------------------------\n");

            foreach (var students in studentsDb.All().Include(s => s.Homeworks).ToList())
            {
                sb.AppendLine(students.ToString());
                sb.AppendLine("Student's homeworks: \n-----------------------");

                foreach (var homework in students.Homeworks.ToList())
                {
                    sb.AppendLine(homework.ToString());
                }

                sb.AppendLine("--------------------------------\n");
            }

            Console.WriteLine(sb);
        }
    }
}
