namespace StudentsSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Course
    {
        private ICollection<Student> students;
        private ICollection<Resource> resouces;
        private ICollection<Homework> homeworks;

        public Course()
        {
            this.students = new HashSet<Student>();
            this.resouces = new HashSet<Resource>();
            this.homeworks = new HashSet<Homework>();
        }

        public int CourseId { get; set; }

        [Required]
        public string Name { get; set; }
        
        public string Desciption { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public bool HasTeamwork { get; set; }

        public virtual ICollection<Student> Students 
        {
            get { return this.students; }
            set { this.students = value; }
        }

        public virtual ICollection<Resource> Resources
        {
            get { return this.resouces; }
            set { this.Resources = value; }
        }

        public virtual ICollection<Homework> Homeworks
        {
            get { return this.homeworks; }
            set { this.homeworks = value;  }
        }

        public override string ToString()
        {
            string description = this.Desciption != null ? this.Desciption : "N/A";
            string endDate = this.EndDate != null ? this.EndDate.ToString() : "N/A";
            string hasTeamwork = this.HasTeamwork ? "Yes" : "No";

            return string.Format(" Course name: {0}\n-----------------------------\n Description {1}\n" +
                " Start date: {2}\n End date: {3}\n Price: {4:0.00}\n Teamwork: {5}\n",
                this.Name,
                description,
                this.StartDate.ToShortDateString(),
                endDate,
                this.Price,
                hasTeamwork
                );
        }
    }
}
