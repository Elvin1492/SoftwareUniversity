namespace NewsSystem.Models
{
    using System.ComponentModel.DataAnnotations;

    public class News
    {
        public News()
        {
        }

        [ConcurrencyCheck]
        public int NewsId { get; set; }

        [Required]
        [ConcurrencyCheck]
        public string Content { get; set; }

        public override string ToString()
        {
            return string.Format("NewsId: {0}\n---------------------\nContent: {1}\n",
                this.NewsId,
                this.Content);
        }
    }
}
