
namespace StudentApp
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    class StudentAppTest 
    {
        static void Main()
        {
            // create a list of Students
            var studentList = new List<Student>()
            {
                new Student("Grozio", "Lozev", 33, 123414, "0283393665", "grozio@epich.bg",
                    new List<int>() {2, 2, 3, 3}, 3, GroupName.Varna ), 
                new Student("Grozdanka", "Kirpicheva", 24, 123514, "0883393445", "grozdanka@silikon.som",
                    new List<int>() {6, 6, 6, 5}, 2, GroupName.Sofia),
                new Student("Stamat", "Evstatiev", 45, 122413, "0283393361", "stamat@naselo.ru",
                    new List<int>() {4, 4, 4, 5}, 2, GroupName.Sofia),
                new Student("Stavrii", "Arbanasob", 25, 223512, "0882293665", "stavrii@abv.bg",
                    new List<int>() {4, 3, 2, 4}, 1, GroupName.Plovdiv),//
                new Student("Minka", "Goshkova", 19, 125413, "0883393432", "minka@gmail.com",
                    new List<int>() {6, 6, 5, 5}, 2, GroupName.Sofia), //
                new Student("Penka", "Shikerova", 21, 127413, "0883393111", "6iker4et0@barelyfits.co.uk",
                    new List<int>() {3, 2, 4, 2}, 1, GroupName.Plovdiv), //
                new Student("Zdravko", "Jelqzkov", 23, 126614, "+359293234", "2_tough@foremails.bg",
                    new List<int>() {4, 3, 5, 4}, 2, GroupName.Sofia), //
                new Student("John", "Smith", 33, 223412, "0883235665", "smith@gmail.com",
                    new List<int>() {3, 3, 2, 4}, 2, GroupName.Sofia), //
                new Student("Miumiun", "Rejep", 26, 120112, "0883327765", "salam_alikom@gmail.com",
                    new List<int>() {5, 5, 5, 5}, 3, GroupName.Varna),//
                new Student("Qsna", "Tqsna", 27, 129914, "0883391435", "qsna_coolg@abv.bg",
                    new List<int>() {5, 6, 6, 4}, 1, GroupName.Plovdiv),
            };

            // filter the students who are from group number 2, sort them by last name and print them
            var studentsFromGroup2 =
                from st in studentList
                where st.GroupNumber == 2
                orderby st.LastName
                select st;

            PrintCollection(studentsFromGroup2);

            // filter all sudens whose first name is before their last name alpabetically
            var firstNamebeforeLastStudents =
                from st in studentList
                where st.FirstName.CompareTo(st.LastName) == -1
                select st;

            PrintCollection(firstNamebeforeLastStudents);
              
            // filter all students whose age is between 18 and 24 and print only their first, last name and age
            var studentsBetween18and24 =
                from st in studentList
                where st.Age >= 18 && st.Age <= 24
                select new { st.FirstName, st.LastName, st.Age }; 

            PrintCollection(studentsBetween18and24);

            // sort the students by first and then last name using extension methods and lambda expression
            var studentsByFirstAndLastName = studentList.
                OrderByDescending(st => st.FirstName)
                .ThenByDescending(st => st.LastName)
                .Select(st => st);

            PrintCollection(studentsByFirstAndLastName);

            // the same sort with LINQ syntax
            var studentsLINQ =
                from st in studentList
                orderby st.FirstName descending, st.LastName descending
                select st;
                          
            PrintCollection(studentsLINQ);

            // print all students that have email @abv.bg using LINQ
            string search = "@abv.bg";
            var studentsByEmail =
                from st in studentList
                where st.Email.Contains(search)
                select st;

            PrintCollection(studentsByEmail);

            // print all students whose phone starts with 02 or +3592
            string search1 = "02";
            string searac2 = "+3592";
            var studentsByPhone =
                from st in studentList
                where st.Phone.StartsWith(search1) ||
                st.Phone.StartsWith(searac2)
                select st;

            PrintCollection(studentsByPhone);

            // print all students who have at least one mark 6
            var studentsWithExelence =
                from st in studentList
                where st.Marks.Contains(6)
                select new { st.FirstName, st.LastName, st.Marks };

            foreach (var item in studentsWithExelence)
            {
                Console.WriteLine(String.Format("{0} {1} {2}",
                    item.FirstName, item.LastName, string.Join(" ", item.Marks)));
            }

            // print all students with at least two poor marks
            var studentsWithPoorMarks = studentList.
                Where(st => st.Marks.Where(mark => mark == 2).Count() == 2).
                Select(st => new { st.FirstName, st.LastName, st.Marks });

            foreach (var item in studentsWithPoorMarks)
            {
                Console.WriteLine(String.Format("{0} {1} {2}",
                  item.FirstName, item.LastName, string.Join(" ", item.Marks)));
            };

            // print the students marks enrolled in 2014
            var studentsFrom2014 = studentList
                .Where(st => st.FacultyNumber.ToString().EndsWith("14"))
                .Select(st => new { st.Marks });
            
            foreach (var item in studentsFrom2014)
            {
                Console.WriteLine( string.Join(" ", item.Marks));
            }

            // print all students grouped by groupname
            var studentsByGroupName =
                from st in studentList
                group st by st.GroupName into gr
                orderby gr.Key
                select  new { gr.Key, students = gr.ToList(),};
                

            foreach (var item in studentsByGroupName)
            {
                Console.WriteLine(item.Key);
                Console.WriteLine( String.Join(" ", item.students));
            }
                
            // create a list of StudentSpecialties
            var specialties = new List<StudentSpecialty>()
            {
                new StudentSpecialty(Specialties.PHPDeveloper, 123414),
                new StudentSpecialty(Specialties.PHPDeveloper, 123514),
                new StudentSpecialty(Specialties.QAEngineer, 122413),
                new StudentSpecialty(Specialties.QAEngineer, 223512),
                new StudentSpecialty(Specialties.WEBDeveloper, 125413),//
                new StudentSpecialty(Specialties.WEBDeveloper, 127413),//
                new StudentSpecialty(Specialties.PHPDeveloper, 126614),//
                new StudentSpecialty(Specialties.QAEngineer, 223412),//
                new StudentSpecialty(Specialties.WEBDeveloper, 120112),
                new StudentSpecialty(Specialties.QAEngineer, 129914),
            };

            var querry =
                from st in studentList
                orderby st.FirstName
                join sp in specialties on st.FacultyNumber equals sp.FacultyNumber
                select new { st.FirstName, st.LastName, st.FacultyNumber, sp.Specialty };

            foreach (var item in querry)
            {
                Console.WriteLine(String.Format("{0} {1} {2} {3}",
                    item.FirstName, item.LastName, item.FacultyNumber,item.Specialty));
            }
        }

        // a method to print the students lists
        public static void PrintCollection(IEnumerable collection)
        {
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
        }

    }
}
