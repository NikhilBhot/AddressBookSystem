using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookSystem
{
    public class AddressBook
    {
        private List<Contact> contacts;
        private Dictionary<string, List<Contact>> cityDictionary;
        private Dictionary<string, List<Contact>> stateDictionary;
        public AddressBook()
        {
            contacts = new List<Contact>();
            cityDictionary = new Dictionary<string, List<Contact>>();
            stateDictionary = new Dictionary<string, List<Contact>>();
        }

        /*UC-02-Ability to add a new
        Contact to Address Book
        - Use Console to add person details from AddressBookMain class
        - Use Object Oriented Concepts to manage relationship between AddressBook and Contact
            Person
        */
        public void AddContact(Contact contact)
        {
            /*Ability to ensure there is no Duplicate Entry of the same Person in a particular Address Book 
            - Duplicate Check is done on Person Name while adding person to Address Book.
            -Use Collection Methods to Search Person by Name for Duplicate Entry
            - Override equals method to check for Duplicate */
            contacts.Add(contact);

            if (!cityDictionary.ContainsKey(contact.City))
            {
                cityDictionary[contact.City] = new List<Contact>();
            }
            cityDictionary[contact.City].Add(contact);

            if (!stateDictionary.ContainsKey(contact.State))
            {
                stateDictionary[contact.State] = new List<Contact>();
            }
            stateDictionary[contact.State].Add(contact);

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

        public void DisplayContactsByCity(string city)
        {
            if (cityDictionary.ContainsKey(city))
            {
                List<Contact> contactsInCity = cityDictionary[city];
                Console.WriteLine($"Contacts in {city}:");
                foreach (var contact in contactsInCity)
                {
                    contact.Display();
                }
            }
            else
            {
                Console.WriteLine($"No contacts found in {city}.");
            }
        }

        public void DisplayContactsByState(string state)
        {
            if (stateDictionary.ContainsKey(state))
            {
                List<Contact> contactsInState = stateDictionary[state];
                Console.WriteLine($"Contacts in {state}:");
                foreach (var contact in contactsInState)
                {
                    contact.Display();
                }
            }
            else
            {
                Console.WriteLine($"No contacts found in {state}.");
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

        public List<Contact> SearchByCity(string city)
        {
            List<Contact> searchResults = new List<Contact>();
            foreach (var contact in contacts)
            {
                if (contact.MatchesCity(city))
                {
                    searchResults.Add(contact);
                }
            }
            return searchResults;
        }

        /*
            Ability to search Person in a City or State across the multiple Address Book 
                - Search Result can show multiple person in the city or state
         */
        public List<Contact> SearchByState(string state)
        {
            List<Contact> searchResults = new List<Contact>();
            foreach (var contact in contacts)
            {
                if (contact.MatchesState(state))
                {
                    searchResults.Add(contact);
                }
            }
            return searchResults;
        }

        public int GetContactCountByCity(string city)
        {
            if (cityDictionary.ContainsKey(city))
            {
                List<Contact> contactsInCity = cityDictionary[city];
                return contactsInCity.Count;
            }
            else
            {
                return 0;
            }
        }

        public int GetContactCountByState(string state)
        {
            if (stateDictionary.ContainsKey(state))
            {
                List<Contact> contactsInState = stateDictionary[state];
                return contactsInState.Count;
            }
            else
            {
                return 0;
            }
        }

        public void SortContactsByName()
        {
            contacts.Sort();
        }

        public override string ToString()
        {
            // Return a string representation of all the contacts in the address book
            string result = string.Empty;
            foreach (var contact in contacts)
            {
                result += contact.ToString();
            }
            return result;
        }
    }
}
