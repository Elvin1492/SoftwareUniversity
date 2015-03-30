namespace ImportContactsFromJson
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    // using System.Data.Entity;
    using System.IO;
    using System.Linq;
    using System.Runtime.InteropServices.ComTypes;
    using System.Text;
    using System.Threading;
    using System.Web;
    using System.Web.Services;
    using System.Web.Script.Serialization;

    using Newtonsoft.Json.Linq;

    using Phonebook_EF_CodeFirst;
    using Phonebook_EF_CodeFirst.Migrations;
    using Phonebook_EF_CodeFirst.Models;

    public class ImportCotacts
    {
        public static void Main()
        {
            string contactsJson = File.ReadAllText("../../contacts.json");
            var contacts = JArray.Parse(contactsJson);

            foreach (var contact in contacts)
            {
                try
                {
                    ImportContact(contact);
                    Console.WriteLine("Contact {0} imported", contact["name"]);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }

        private static void ImportContact(JToken contactObj)
        {
            var context = new PhonebookContext();
            var contact = new Contact();

            // Parse contact name
            if (contactObj["name"] == null)
            {
                throw new Exception("Name is required.");
            }

            contact.Name = contactObj["name"].Value<string>();
            if (contactObj["position"] != null)
            {
                contact.Position = contactObj["position"].Value<string>();
            }

            if (contactObj["company"] != null)
            {
                contact.Company = contactObj["company"].Value<string>();
            }

            if (contactObj["site"] != null)
            {
                contact.Url = contactObj["site"].Value<string>();
            }

            if (contactObj["notes"] != null)
            {
                contact.Notes = contactObj["notes"].Value<string>();
            }
           
             // Parse emails
            var emails = contactObj["emails"];
            if (emails != null)
            {
                foreach (var email in emails)
                {
                    contact.Emails.Add(new Email() { EmailAddress = email.Value<string>() });
                }
            }
         
            // Parse contacts
            var phones = contactObj["phones"];
            if (phones != null)
            {
                foreach (var phone in phones)
                {
                    contact.Phones.Add(new Phone() { PhoneNumber = phone.Value<string>()});
                }
            }
     
            context.Contacts.Add(contact);
            context.SaveChanges();
        }
    }
}
