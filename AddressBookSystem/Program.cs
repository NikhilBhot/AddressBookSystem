using System;

namespace AddressBookSystem
{
    public class Program
    {
        /*Refactor to add multiple Address Book to the System. Each Address Book has a unique Name 
            - Use Console to add new Address Book
         */
        private static Dictionary<string, AddressBook> addressBooks;

        static Program()
        {
            addressBooks = new Dictionary<string, AddressBook>();
        }

        static void Main()
        {
            while (true)
            {
                Console.WriteLine("Address Book Menu:");
                Console.WriteLine("1. Add Address Book");
                Console.WriteLine("2. Select Address Book");
                Console.WriteLine("3. Search Contacts by City");
                Console.WriteLine("4. Search Contacts by State");
                Console.WriteLine("5. Get Contact Count by City");
                Console.WriteLine("6. Get Contact Count by State");
                Console.WriteLine("7. Exit");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter Address Book Name: ");
                        string addressBookName = Console.ReadLine();
                        if (addressBooks.ContainsKey(addressBookName))
                        {
                            Console.WriteLine($"Address Book '{addressBookName}' already exists.");
                        }
                        else
                        {
                            AddressBook newAddressBook = new AddressBook();
                            addressBooks.Add(addressBookName, newAddressBook);
                            Console.WriteLine($"Address Book '{addressBookName}' created successfully.");
                        }
                        break;

                    case "2":
                        Console.Write("Enter Address Book Name: ");
                        string selectedAddressBookName = Console.ReadLine();
                        if (addressBooks.TryGetValue(selectedAddressBookName, out AddressBook selectedAddressBook))
                        {
                            ManageAddressBook(selectedAddressBook);
                        }
                        else
                        {
                            Console.WriteLine($"Address Book '{selectedAddressBookName}' does not exist.");
                        }
                        break;

                    case "3":
                        Console.Write("Enter City to search: ");
                        string searchCity = Console.ReadLine();
                        SearchContactsByCity(searchCity);
                        break;

                    case "4":
                        Console.Write("Enter State to search: ");
                        string searchState = Console.ReadLine();
                        SearchContactsByState(searchState);
                        break;

                    case "5":
                        Console.Write("Enter City to get contact count: ");
                        string countCity = Console.ReadLine();
                        GetContactCountByCity(countCity);
                        break;

                    case "6":
                        Console.Write("Enter State to get contact count: ");
                        string countState = Console.ReadLine();
                        GetContactCountByState(countState);
                        break;

                    case "7":
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void ManageAddressBook(AddressBook addressBook)
        {
            //Console.WriteLine("Wel-Come To Address Book System");
            //AddressBook addressBook = new AddressBook();

            while (true)
            {
                Console.WriteLine("Address Book Menu:");
                /*UC-02-Ability to add a new Contact to Address Book
                    - Use Console to add person details from AddressBookMain class
                    - Use Object Oriented Concepts to manage relationship between AddressBook and Contact
                        Person
        */
                Console.WriteLine("1. Add Contact");
                Console.WriteLine("2. Display Contacts");
                Console.WriteLine("3. Edit Contact");
                Console.WriteLine("4. Delete Contact");
                Console.WriteLine("5. Exit");
                Console.WriteLine("6.Reurn To Add AddressBook Or Select Address Book");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter First Name: ");
                        string firstName = Console.ReadLine();
                        Console.Write("Enter Last Name: ");
                        string lastName = Console.ReadLine();
                        Console.Write("Enter Address: ");
                        string address = Console.ReadLine();
                        Console.Write("Enter City: ");
                        string city = Console.ReadLine();
                        Console.Write("Enter State: ");
                        string state = Console.ReadLine();
                        Console.Write("Enter Zip: ");
                        string zip = Console.ReadLine();
                        Console.Write("Enter Phone Number: ");
                        string phoneNumber = Console.ReadLine();
                        Console.Write("Enter Email: ");
                        string email = Console.ReadLine();

                        Contact newContact = new Contact(firstName, lastName, address, city, state, zip, phoneNumber, email);
                        addressBook.AddContact(newContact);
                        break;

                    case "2":
                        addressBook.DisplayContacts();
                        break;

                    case "3":
                        Console.Write("Enter First Name of the contact to edit: ");
                        string editFirstName = Console.ReadLine();
                        Console.Write("Enter Last Name of the contact to edit: ");
                        string editLastName = Console.ReadLine();
                        addressBook.EditContact(editFirstName, editLastName);
                        break;

                    case "4":
                        Console.Write("Enter First Name of the contact to delete: ");
                        string deleteFirstName = Console.ReadLine();
                        Console.Write("Enter Last Name of the contact to delete: ");
                        string deleteLastName = Console.ReadLine();
                        addressBook.DeleteContact(deleteFirstName, deleteLastName);
                        break;

                    case "5":
                        Environment.Exit(0);
                        
                        break;
                    case "6":
                        Main();
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
        static void SearchContactsByCity(string city)
        {
            List<Contact> searchResults = new List<Contact>();
            foreach (var addressBook in addressBooks.Values)
            {
                searchResults.AddRange(addressBook.SearchByCity(city));
            }

            if (searchResults.Count == 0)
            {
                Console.WriteLine("No contacts found in the specified city.");
            }
            else
            {
                Console.WriteLine($"Contacts in {city}:");
                foreach (var contact in searchResults)
                {
                    contact.Display();
                }
            }
        }

        static void SearchContactsByState(string state)
        {
            List<Contact> searchResults = new List<Contact>();
            foreach (var addressBook in addressBooks.Values)
            {
                searchResults.AddRange(addressBook.SearchByState(state));
            }

            if (searchResults.Count == 0)
            {
                Console.WriteLine("No contacts found in the specified state.");
            }
            else
            {
                Console.WriteLine($"Contacts in {state}:");
                foreach (var contact in searchResults)
                {
                    contact.Display();
                }
            }
        }
        static void DisplayContactsByCity(string city)
        {
            foreach (var addressBook in addressBooks.Values)
            {
                addressBook.DisplayContactsByCity(city);
            }
        }

        static void DisplayContactsByState(string state)
        {
            foreach (var addressBook in addressBooks.Values)
            {
                addressBook.DisplayContactsByState(state);
            }
        }
        /*
         * Ability to get number of contact persons
            i.e. count by City or State - Search Result will show count by city and by state
         */
        static void GetContactCountByCity(string city)
        {
            int totalContactCount = 0;
            foreach (var addressBook in addressBooks.Values)
            {
                int contactCount = addressBook.GetContactCountByCity(city);
                Console.WriteLine($"Contacts in {city} ({contactCount})");
                totalContactCount += contactCount;
            }
            Console.WriteLine($"Total contacts in {city}: {totalContactCount}");
        }

        static void GetContactCountByState(string state)
        {
            int totalContactCount = 0;
            foreach (var addressBook in addressBooks.Values)
            {
                int contactCount = addressBook.GetContactCountByState(state);
                Console.WriteLine($"Contacts in {state} ({contactCount})");
                totalContactCount += contactCount;
            }
            Console.WriteLine($"Total contacts in {state}: {totalContactCount}");
        }
    }
}