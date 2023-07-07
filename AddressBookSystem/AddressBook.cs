using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookSystem
{
    public class AddressBook
    {
        private List<Contact> contacts;

        public AddressBook()
        {
            contacts = new List<Contact>();
        }

        /*UC-02-Ability to add a new
        Contact to Address Book
        - Use Console to add person details from AddressBookMain class
        - Use Object Oriented Concepts to manage relationship between AddressBook and Contact
            Person
        */
        public void AddContact(Contact contact)
        {
            contacts.Add(contact);
            Console.WriteLine("Contact added successfully.");
        }

        public void DisplayContacts()
        {
            if (contacts.Count == 0)
            {
                Console.WriteLine("No contacts found.");
                return;
            }

            Console.WriteLine("Contacts:");
            foreach (var contact in contacts)
            {
                contact.Display();
            }
        }
        //Ability to edit existing contact person using their name
        public void EditContact(string firstName, string lastName)
        {
            Contact contact = FindContact(firstName, lastName);
            if (contact != null)
            {
                Console.WriteLine("Enter new details for the contact:");
                Console.Write("Enter Address: ");
                contact.Address = Console.ReadLine();
                Console.Write("Enter City: ");
                contact.City = Console.ReadLine();
                Console.Write("Enter State: ");
                contact.State = Console.ReadLine();
                Console.Write("Enter Zip: ");
                contact.Zip = Console.ReadLine();
                Console.Write("Enter Phone Number: ");
                contact.PhoneNumber = Console.ReadLine();
                Console.Write("Enter Email: ");
                contact.Email = Console.ReadLine();
                Console.WriteLine("Contact updated successfully.");
            }
            else
            {
                Console.WriteLine("Contact not found.");
            }
        }

        /*
         *Ability to delete  person using person's name - Use Console to delete a person
         */
        public void DeleteContact(string firstName, string lastName)
        {
            Contact contact = FindContact(firstName, lastName);
            if (contact != null)
            {
                contacts.Remove(contact);
                Console.WriteLine("Contact deleted successfully.");
            }
            else
            {
                Console.WriteLine("Contact not found.");
            }
        }

        private Contact FindContact(string firstName, string lastName)
        {
            return contacts.Find(c => c.FirstName == firstName && c.LastName == lastName);
        }
    }
}
