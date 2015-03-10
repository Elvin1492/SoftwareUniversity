namespace StudentsSystem.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Homework
    {
        public int HomeworkId { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public ContentType Type { get; set; }

        public int? StudentId { get; set; }

        public virtual Student Student { get; set; }

        public int? CourseId { get; set; }

        public virtual Course Course { get; set; }

        public override string ToString()
        {
            return string.Format("Homework ID: {0}\n---------------------------\n Content: {1}\n" +
            " Content type: {2}\n ",
                this.HomeworkId,
                this.Content,
                this.Type.ToString()
                );
        }
    }
}
