namespace StudentsSystem.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Resource
    {

        public int ResourceId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Content{ get; set; }

        [Required]
        public ResourceType Type { get; set; }

        public int? CourseId { get; set; }

        public virtual Course Course { get; set; }

        public override string ToString()
        {
            return string.Format(" Resource: {0}\n-----------------------------------\n Content: {1}\n Type: {2}\n",
                this.Name,
                this.Content,
                this.Type.ToString()
                );
        }
    }
}
