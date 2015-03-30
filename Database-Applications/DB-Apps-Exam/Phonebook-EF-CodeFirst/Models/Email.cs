namespace Phonebook_EF_CodeFirst.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Diagnostics;

    public class Email
    {
        public int Id { get; set; }

        [Required]
        public string EmailAddress { get; set; }
    }
}
