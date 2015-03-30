namespace Phonebook_EF_CodeFirst.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Models;

    public sealed class Configuration : DbMigrationsConfiguration<PhonebookContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(PhonebookContext context)
        {
            if (context.Contacts.Any())
            {
                return;
            }
            // first contact
            var emailPeter = new Email() { EmailAddress = "peter@gmail.com" };
            var emailPeterIvanov = new Email() { EmailAddress = "peter_ivanov@yahoo.com" };

            var phoneFirst = new Phone() { PhoneNumber = "+359 2 22 22 22" };
            var phoneSecond = new Phone() { PhoneNumber = "+359 88 77 88 99" };

            var contactOne = new Contact()
            {
                Name = "Peter Ivanov",
                Position = "CTO",
                Company = "Smart Ideas",
                Url = "http://blog.peter.com",
                Notes = "Friend from school"
            };

            contactOne.Phones.Add(phoneFirst);
            contactOne.Phones.Add(phoneSecond);

            contactOne.Emails.Add(emailPeter);
            contactOne.Emails.Add(emailPeterIvanov);

            context.Contacts.Add(contactOne);
            context.SaveChanges();

            // second contact
            var phoneSecondContact = new Phone() { PhoneNumber = "+359 22 33 44 55" };

            var contactTwo = new Contact()
            {
                Name = "Maria",
            };

            contactTwo.Phones.Add(phoneSecondContact);

            context.Contacts.Add(contactTwo);
            context.SaveChanges();

            // third contact
            var thirdContactEail = new Email() { EmailAddress = "info@angiestanton.com" };

            var contactThree = new Contact()
            {
                Name = "Angie Stanton",
                Url = "http://angiestanton.com",
            };

            contactThree.Emails.Add(thirdContactEail);
            context.Contacts.Add(contactThree);
            context.SaveChanges();
        }
    }
}
