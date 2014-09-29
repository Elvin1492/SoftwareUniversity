using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApp
{
    public class StudentSpecialty
    {
        private Specialties specialty;
        private int facultyNumber;

        public Specialties Specialty
        {
            get { return this.specialty; }
            set { this.specialty = value; }
        }

        public int FacultyNumber
        {
            get { return this.facultyNumber; }
            set
            {
                if (value.ToString().Length != 6)
                {
                    throw new ArgumentException("FacultyNumber should be 6 a six digit number");
                }

                this.facultyNumber = value;
            }
        }

        public StudentSpecialty(Specialties specialty, int facultyNumber)
        {
            this.Specialty = specialty;
            this.FacultyNumber = facultyNumber;
        }
    }
}
