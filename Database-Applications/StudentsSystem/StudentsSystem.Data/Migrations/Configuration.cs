namespace StudentsSystem.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using StudentsSystem.Models;

    public sealed class Configuration : DbMigrationsConfiguration<StudentsSystemDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            this.ContextKey = "StudentsSystem.Data.StudentsSystemDbContext";
        }

        protected override void Seed(StudentsSystemDbContext context)
        {
            this.SeedStudents(context);
            this.SeedCourses(context);
            this.SeedResources(context);
            this.SeedHomeworks(context);
            
            context.SaveChanges();

            base.Seed(context);
        }

        private void SeedStudents(StudentsSystemDbContext context)
        {
            if (context.Students.Any())
            {
                return;
            };

            var studentPesho = new Student
            {
                Name = "Pesho Peshev",
                PhoneNumber = "0883333333",
                RegistrationDate = new DateTime(2013, 4, 6),
                BirthDate = new DateTime(1986, 8, 8),
                IsWorking = true,
                ContactInfo = new StudentContactInfo
                {
                    Email = "pesho@gmail.com",
                    FacebookProfile = "http://facebook.com/peshopeshev",
                    GithubProfile = "http://github.com/peshop",
                },
            };

            var studentGosho = new Student
            {
                Name = "Gosho Goshev",
                PhoneNumber = "0883666555",
                RegistrationDate = new DateTime(2014, 7, 6),
                BirthDate = new DateTime(1989, 5, 10),
                IsWorking = false,
                ContactInfo = new StudentContactInfo
                {
                    Email = "gosho@hotmail.com",
                    SkypeAccount = "gesharulz",
                    GithubProfile = "http://github.com/goshko",
                },
            };

            var studentMaria = new Student
            {
                Name = "Mariika Pencheva",
                PhoneNumber = "0883777456",
                RegistrationDate = new DateTime(2015, 1, 2),
                BirthDate = new DateTime(1993, 5, 10),
                IsWorking = false,
                ContactInfo = new StudentContactInfo
                {
                    Email = "sexy_mimi@hotmail.com",
                    SkypeAccount = "mmmariichetoXXX",
                    Website = "http://marriaXXX.com/blowjobs",
                },
            };

            context.Students.Add(studentGosho);
            context.Students.Add(studentPesho);
            context.Students.Add(studentMaria);
  
            context.SaveChanges();
        }

        private void SeedCourses(StudentsSystemDbContext context)
        {
            if (context.Courses.Any())
            {
                return;
            };

            var dataBasesCourse = new Course
            {
                Name = "Databases",
                Desciption = "Learn Oracle, SQL SERVER, MySQL, MonogoDb and Redis",
                StartDate = new DateTime(2015, 2, 2),
                EndDate = new DateTime(2015, 2, 28),
                Price = 100,
                HasTeamwork = false,
            };

            var dataBaseApplicaationsCourse = new Course
            {
                Name = "Database Applications",
                Desciption = "Learn Entity Framework Code First and Java Hibernate.",
                StartDate = new DateTime(2015, 3, 1),
                Price = 100,
                HasTeamwork = true,
            };

            var angularJsCourse = new Course
            {
                Name = "AngularJS",
                StartDate = new DateTime(2014, 11, 11),
                EndDate = new DateTime(2014, 12, 12),
                Price = 100,
                HasTeamwork = false,
            };

            context.Courses.Add(dataBasesCourse);
            context.Courses.Add(dataBaseApplicaationsCourse);
            context.Courses.Add(angularJsCourse);

            var studentPesho = context.Students.Where(s => s.Name == "Pesho Peshev").FirstOrDefault();
            studentPesho.Courses.Add(dataBaseApplicaationsCourse);
            studentPesho.Courses.Add(dataBasesCourse);

            var studentGosho = context.Students.Where(s => s.Name == "Gosho Goshev").FirstOrDefault();
            studentGosho.Courses.Add(dataBaseApplicaationsCourse);
            studentGosho.Courses.Add(angularJsCourse);

            var studentMaria = context.Students.Where(s => s.Name == "Mariika Pencheva").FirstOrDefault();
            studentMaria.Courses.Add(dataBaseApplicaationsCourse);
            studentMaria.Courses.Add(angularJsCourse);

            context.SaveChanges();
        }

        private void SeedResources(StudentsSystemDbContext context)
        {
            if (context.Resources.Any())
            {
                return;
            };

            var databaseCourseResource = new Resource
            {
                Name = "Databases Course videos.",
                Type = ResourceType.Video,
                Content = "https://www.youtube.com/watch?v=tQvXI6jOTco&list=PLlcYRzEHmgNlrfnT4D1c1MmRxJNxY3a-8",
            };

            var databaseApplicationsCourseResource = new Resource
            {
                Name = "Databases Apllications Course presentations.",
                Type = ResourceType.Presentation,
                Content = "https://softuni.bg/trainings/21/Database-Applications-Mar-2015",
            };

            var angularJsCourseResource = new Resource
            {
                Name = "Angular JS Course presentations.",
                Type = ResourceType.Document,
                Content = "https://softuni.bg/trainings/21/Database-Applications-Mar-2015",
            };

            context.Resources.Add(databaseCourseResource);
            context.Resources.Add(databaseApplicationsCourseResource);
            context.Resources.Add(angularJsCourseResource);

            var angularCourse = context.Courses.Where(c => c.Name == "AngularJS").FirstOrDefault();
            angularCourse.Resources.Add(angularJsCourseResource);

            var databaseCourse = context.Courses.Where(c => c.Name == "Databases").FirstOrDefault();
            databaseCourse.Resources.Add(databaseCourseResource);

            var databaseAppsCourse = context.Courses.Where(c => c.Name == "Database Applications").FirstOrDefault();
            databaseAppsCourse.Resources.Add(databaseApplicationsCourseResource);

            context.SaveChanges();
        }

        private void SeedHomeworks(StudentsSystemDbContext context)
        {
            if (context.Homeworks.Any())
            {
                return;
            };

            var homeworkGoshoAngularJs = new Homework
            {
                Content = "My first SPA app.",
                Type = ContentType.Application
            };

            var homeworkPeshoDatabases = new Homework
            {
                Content = "SQL SEVER performance",
                Type = ContentType.Pdf
            };

            var homeworkMariaDatabaseApps = new Homework
            {
                Content = "Entity Frameworrk Code First",
                Type = ContentType.Zip
            };

            context.Homeworks.Add(homeworkGoshoAngularJs);
            context.Homeworks.Add(homeworkPeshoDatabases);
            context.Homeworks.Add(homeworkMariaDatabaseApps);

            var studentPesho = context.Students.Where(s => s.Name == "Pesho Peshev").FirstOrDefault();
            studentPesho.Homeworks.Add(homeworkPeshoDatabases);

            var studentGosho = context.Students.Where(s => s.Name == "Gosho Goshev").FirstOrDefault();
            studentGosho.Homeworks.Add(homeworkGoshoAngularJs);

            var studentMaria = context.Students.Where(s => s.Name == "Mariika Pencheva").FirstOrDefault();
            studentMaria.Homeworks.Add(homeworkMariaDatabaseApps);

            var angularCourse = context.Courses.Where(c => c.Name == "AngularJS").FirstOrDefault();
            angularCourse.Homeworks.Add(homeworkGoshoAngularJs);

            var databaseCourse = context.Courses.Where(c => c.Name == "Databases").FirstOrDefault();
            databaseCourse.Homeworks.Add(homeworkPeshoDatabases);

            var databaseAppsCourse = context.Courses.Where(c => c.Name == "Database Applications").FirstOrDefault();
            databaseAppsCourse.Homeworks.Add(homeworkMariaDatabaseApps); 

            context.SaveChanges();
        }
    }
}
