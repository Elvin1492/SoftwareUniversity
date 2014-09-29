using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApp 
{
    public class Student
    {
        private string firstName;
        private string lastName;
        private int age;
        private int facultyNumber;
        private string phone;
        private string email;
        private List<int> marks;
        private int groupNumber;
        public GroupName groupName;

        public string FirstName
        {
            get { return this.firstName;}
            set
            {
                if (value.Length < 2)
                {
                    throw new ArgumentException("First name can not be less than 2 charachters");
                }

                this.firstName = value;
            }
        }

        public string LastName
        {
            get { return this.lastName;}
            set
            {
                if (value.Length < 2)
                {
                    throw new ArgumentException("Last name can not be less than 2 charachters");
                }

                this.lastName = value;
            }
        }

        public int Age
        {
            get { return this.age;}
            set
            {
                if (value < 7 || value > 150)
                {
                    throw new ArgumentOutOfRangeException("Age", "Age should be in the range [7..150]");
                }

                this.age = value;
            }
        }

        public int FacultyNumber
        {
            get { return this.facultyNumber;}
            set
            {
                if (value.ToString().Length != 6)
                {
                    throw new ArgumentException("FacultyNumber should be 6 a six digit number");
                }

                this.facultyNumber = value;
            }
        }

        public string Phone
        {
            get { return this.phone;}
            set
            {
                if (value.Length != 10 )
                {
                    throw new ArgumentException("Phone number should be a 10 digit number in the foramt 08XX XXX XXX");
                }

                this.phone = value;
            }
        }

        public string Email
        {
            get { return this.email;}
            set
            {
                var addr = new System.Net.Mail.MailAddress(value);
                if (!(addr.Address == value))
                {
                    throw new ArgumentException("Email addres is invalid.Email should be in the format user@host.domain");
                }

                this.email = value;
            }
        }

        public IList<int> Marks
        {
            get { return this.marks; }
            set
            {
                foreach (var item in value)
                {
                    if (item > 6 || item < 2)
                    {
                        throw new ArgumentOutOfRangeException("Mark","Marks sould be in the range [2..6]");
                    }
                }

               this.marks = new List<int>(value);
            }
        }

        public int GroupNumber
        {
            get { return this.groupNumber; }
            set
            {
                if (value < 1 || value > 100)
                {
                    throw new ArgumentOutOfRangeException("Group Number", "Group Number shoul be in the range [1..100]");
                }

                this.groupNumber = value;
            }
        }

        public GroupName GroupName
        {
            get { return this.groupName;}
            set { this.groupName = value; }
        }

        public Student(string firstName, string lastName, int age, int facultyNumber, string phone, 
            string email, List<int> marks, int groupNumber, GroupName groupName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.FacultyNumber = facultyNumber;
            this.Phone = phone;
            this.Email = email;
            this.Marks = marks;
            this.GroupNumber = groupNumber;
            this.GroupName = groupName;
        }

        public override string ToString()
        {
            string marks = "(";
            this.marks.ForEach(mark => marks += mark + " " );
            marks += ")";

            return String.Format("{0} {1} {2} {3} {4} {5} {6} {7} {8}",
                this.firstName, this.lastName, this.age, this.facultyNumber,
                this.phone, this.email, marks, this.groupNumber, this.GroupName);
        }

    }
}
