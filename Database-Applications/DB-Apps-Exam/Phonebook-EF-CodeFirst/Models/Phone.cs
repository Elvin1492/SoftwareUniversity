namespace Phonebook_EF_CodeFirst.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Diagnostics;

    public class Phone
    {
        public int Id { get; set; }

        [Required]
        public string PhoneNumber { get; set; }
    }
}
