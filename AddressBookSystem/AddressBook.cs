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
    }
}
