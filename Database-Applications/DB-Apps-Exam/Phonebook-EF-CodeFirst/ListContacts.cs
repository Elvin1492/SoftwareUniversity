namespace Phonebook_EF_CodeFirst
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Data.Entity;
    using System.Linq;
    using System.Runtime.InteropServices.ComTypes;
    using System.Text;
    using System.Threading;

    using Migrations;
    using Models;

    public class ListContacts
    {
        public static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<PhonebookContext, Configuration>());

            var db = new PhonebookContext();

            var contacts = db.Contacts
                .Include(c => c.Emails)
                .Include(c => c.Phones)
                .Select(c => new
                {
                   contactInfo = c,
                   emails = c.Emails.Select(e => e.EmailAddress).ToList(),
                   phones = c.Phones.Select(p => p.PhoneNumber).ToList(),
                })
                .ToList();

            foreach (var contact in contacts)
            {
                Console.WriteLine("Name: {0}\n Position: {1}\n Cpmpany: {2}\n Emails: {3}\n Phones: {4}\n Url: {5}\n Notes: {6}\n",
                    contact.contactInfo.Name,
                    contact.contactInfo.Position != null ? contact.contactInfo.Position : "N/A",
                    contact.contactInfo.Company != null ? contact.contactInfo.Company : "N/A",
                    contact.emails != null ? string.Join(", ", contact.emails.ToList()) : "N/A",
                    contact.phones != null ? string.Join(", ", contact.phones.ToList()) : "N/A",
                    contact.contactInfo.Url != null ? contact.contactInfo.Url: "N/A",
                    contact.contactInfo.Notes != null ? contact.contactInfo.Notes : "N/A"
                    );
                Console.WriteLine();
            }
        }
    }
}
