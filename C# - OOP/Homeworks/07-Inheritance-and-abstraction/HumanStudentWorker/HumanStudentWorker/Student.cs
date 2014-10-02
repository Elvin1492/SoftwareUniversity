
namespace HumanStudentWorker
{
    using System;

    // define a class Students which derives from Human
    public class Student :Human
    {
        private string facultyNumber;

        public Student(string firstName, string lastName, string facultyNumber)
            : base(firstName, lastName)
        {
            this.FacultyNumber = facultyNumber;
        }

        public string FacultyNumber 
        {
            get { return this.facultyNumber; }
            private set
            {
                if (value.Length < 5 || value.Length > 10)
                {
                    throw new ArgumentOutOfRangeException("Faculty Number",
                        "Faculty Number should be between 5-10 charachters long");
                }

                this.facultyNumber = value;
            }
        }

        // override the ToString() method
        public override string ToString()
        {
            return base.ToString() + String.Format(", Faculty Number: {0}", this.facultyNumber);
        }
    }
}
