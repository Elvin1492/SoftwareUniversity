
namespace HumanStudentWorker
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    // test the program
    public class Program
    {
        static void Main()
        {
            // initialize a list of 10 students
           var studentsList = new List<Student>()
            {            
                new Student("Boris", "Chernev","sf123m0914"),
                new Student("Pesho", "Goshev","sf123m1014"),
                new Student("Minka", "Prodanova","sf122f1414"),
                new Student("Petya", "Fastykova","pl130f0414"),
                new Student("Misho", "Grozev","pl122m1114"),
                new Student("Grezdi", "Bliznakov","sf120m5614"),
                new Student("Tichinka", "Grudkova","sf124f0014"),
                new Student("Petyo", "Kiuchukov","sf112m0914"),
                new Student("Filipka", "Kiflarska","sf126f0114"),
                new Student("Tredafilka", "Nemska","pl133f1514"),
            };

            // sort the students by facultyNumber in descending order and print them 
           var studentsByFacNum = studentsList
               .OrderByDescending(st => st.FacultyNumber)
               .Select(st => st);

           foreach (var student in studentsByFacNum)
           {
               Console.WriteLine(student);
           }

           Console.WriteLine();

           // initialize a list of 10 workers
           var workersList = new List<Worker>()
            {
                new Worker("Misho", "Topchiev",200, 6),
                new Worker("Valia", "Minkova", 300, 8),
                new Worker("Petka", "Prokopieva",250, 8),
                new Worker("Shefket", "Sharapova",360, 8),
                new Worker("Pencho", "Penev", 400, 8),
                new Worker("Kiril", "Mutafov",220, 6),
                new Worker("Boiko", "Kolarov",300, 8),
                new Worker("Stefka", "Miteva",400, 8),
                new Worker("Nihal", "Kamal", 180, 4),
                new Worker("Chapai", "Kurtev", 600, 8),
            };

            //sort the students by payment per hour in descending order and print them
           var workersByPayment = workersList
               .OrderByDescending(wr => wr.MoneyPerHour())
               .Select(wr => wr);

           foreach (var worker in workersByPayment)
           {
               Console.WriteLine(worker);
           }

           Console.WriteLine();

           // mege the two list sort them by first and last name, and print them
           var mergedList = new List<Human>(studentsList.Count + workersList.Count);
           mergedList.AddRange(studentsList);
           mergedList.AddRange(workersList);

           var mergeListSortedByName = mergedList
               .OrderBy(hm => hm.FirstName)
               .ThenBy(hm => hm.LastName)
               .Select(hm => hm);

           foreach (var human in mergeListSortedByName)
           {
               Console.WriteLine(human);
           }
         
        }  
    }
}
