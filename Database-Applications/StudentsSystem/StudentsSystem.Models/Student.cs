namespace StudentsSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Student
    {
        private ICollection<Course> courses;
        private ICollection<Homework> homeworks;

        public Student()
        {
            this.courses = new HashSet<Course>();
            this.homeworks = new HashSet<Homework>();
            this.ContactInfo = new StudentContactInfo();
        }

        public int StudentId { get; set; }

        [Required]
        public string Name { get; set; }

        [MaxLength(10)]
        public string PhoneNumber { get; set; }

        [Required]
        public DateTime RegistrationDate { get; set; }

        public DateTime? BirthDate { get; set; }

        public bool IsWorking { get; set; }

        public StudentContactInfo ContactInfo { get; set; }

        public virtual ICollection<Course> Courses
        {
            get { return this.courses; }
            set { this.courses = value; }
        }

        public virtual ICollection<Homework> Homeworks
        {
            get { return this.homeworks; }
            set { this.homeworks = value; }
        }

        public override string ToString()
        {
            string phoneNumber = this.PhoneNumber != null ? this.PhoneNumber : "N/A";
            string birthDate = this.BirthDate != null ? this.BirthDate.ToString() : "N/A";
            string IsWorking = this.IsWorking ? "Yes" : "No";

            return String.Format(" StudentID: {0}\n---------------------\n Name: {1}\n Registration Date: {2}\n" +
            " Date of birth: {3}\n Phone: {4}\n Working: {5}\n\n {6}\n\n",
                this.StudentId,
                this.Name,
                this.RegistrationDate.ToShortDateString(),
                birthDate,
                phoneNumber,
                IsWorking,
                this.ContactInfo.ToString()
                );
        }
    }
}
