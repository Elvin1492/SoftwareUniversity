namespace StudentsSystem.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [ComplexType]
    public class StudentContactInfo
    {
        public string Email { get; set; }

        [Url]
        public string FacebookProfile { get; set; }

        public string SkypeAccount { get; set; }

        [Url]
        public string Website { get; set; }

        [Url]
        public string GithubProfile { get; set; }

        public override string ToString()
        {
            string email = this.Email != null ? this.Email : "N/A";
            string facebook = this.FacebookProfile != null ? this.FacebookProfile : "N/A";
            string skype = this.SkypeAccount != null ? this.SkypeAccount : "N/A";
            string website = this.Website != null ? this.Website : "N/A";
            string github = this.GithubProfile != null ? this.GithubProfile : "N/A";

             return string.Format("Contact info:\n-------------------------\n Email: {0}\n" +
                " Facebook: {1}\n Skype: {2}\n Website: {3}\n Github: {4}",
                email,
                facebook,
                skype,
                website,
                github);
        }

    }
}
