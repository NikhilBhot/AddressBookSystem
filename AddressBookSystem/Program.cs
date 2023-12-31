﻿using System;

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
                Console.WriteLine("7. Sort Contacts by Name");
                Console.WriteLine("8. Sort Contacts by City");
                Console.WriteLine("9. Sort Contacts by State");
                Console.WriteLine("10. Sort Contacts by Zip");
                Console.WriteLine("11. Exit");
                Console.WriteLine("12. Exit");
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
                        Console.Write("Enter Address Book Name to sort contacts: ");
                        string sortAddressBookName = Console.ReadLine();
                        SortContactsByName(sortAddressBookName);
                        break;

                    case "8":
                        Console.Write("Enter Address Book Name to sort contacts by city: ");
                        string sortAddressBookByCityName = Console.ReadLine();
                        SortContactsByCity(sortAddressBookByCityName);
                        break;

                    case "9":
                        Console.Write("Enter Address Book Name to sort contacts by state: ");
                        string sortAddressBookByStateName = Console.ReadLine();
                        SortContactsByState(sortAddressBookByStateName);
                        break;

                    case "10":
                        Console.Write("Enter Address Book Name to sort contacts by ZIP: ");
                        string sortAddressBookByZipName = Console.ReadLine();
                        SortContactsByZip(sortAddressBookByZipName);
                        break;

                    case "11":
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
                Console.WriteLine("5. Write to File");
                Console.WriteLine("6. Read from File");
                Console.WriteLine("7. Write to CSV File");
                Console.WriteLine("8. Read from CSV File");
                Console.WriteLine("9. Exit");
                Console.WriteLine("10.Reurn To Add AddressBook Or Select Address Book");
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
                        //Console.Write("Enter file path to write: ");
                        string writeFilePath = "E:\\Bridgelabs\\AddressBookSystem\\AddressBookSystem\\Contact.txt";
                        addressBook.WriteToFile(writeFilePath);
                        break;

                    case "6":
                        //Console.Write("Enter file path to read: ");
                        string readFilePath = "E:\\Bridgelabs\\AddressBookSystem\\AddressBookSystem\\Contact.txt";
                        addressBook.ReadFromFile(readFilePath);
                        break;
                    case "7":
                        //Console.Write("Enter file path to write: ");
                        string writeCSVFilePath = "E:\\Bridgelabs\\AddressBookSystem\\AddressBookSystem\\Contact.csv";
                        addressBook.WriteToFile(writeCSVFilePath);
                        break;

                    case "8":
                        //Console.Write("Enter file path to read: ");
                        string readCSVFilePath = "E:\\Bridgelabs\\AddressBookSystem\\AddressBookSystem\\Contact.csv";
                        addressBook.ReadFromFile(readCSVFilePath);
                        break;
                    case "9":
                        Environment.Exit(0);
                        
                        break;
                    case "10":
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

        static void SortContactsByName(string addressBookName)
        {
            if (addressBooks.TryGetValue(addressBookName, out AddressBook addressBook))
            {
                addressBook.SortContactsByName();
                Console.WriteLine($"Contacts in Address Book '{addressBookName}' sorted by name.");
            }
            else
            {
                Console.WriteLine($"Address Book '{addressBookName}' does not exist.");
            }
        }

        static void SortContactsByCity(string addressBookName)
        {
            if (addressBooks.TryGetValue(addressBookName, out AddressBook addressBook))
            {
                addressBook.SortContactsByCity();
                Console.WriteLine($"Contacts in Address Book '{addressBookName}' sorted by city.");
            }
            else
            {
                Console.WriteLine($"Address Book '{addressBookName}' does not exist.");
            }
        }

        static void SortContactsByState(string addressBookName)
        {
            if (addressBooks.TryGetValue(addressBookName, out AddressBook addressBook))
            {
                addressBook.SortContactsByState();
                Console.WriteLine($"Contacts in Address Book '{addressBookName}' sorted by state.");
            }
            else
            {
                Console.WriteLine($"Address Book '{addressBookName}' does not exist.");
            }
        }
        /*Ability to sort the entries in the address book by City, State, or Zip 
          - Write functions to sort person by City, State or Zip
         */
        static void SortContactsByZip(string addressBookName)
        {
            if (addressBooks.TryGetValue(addressBookName, out AddressBook addressBook))
            {
                addressBook.SortContactsByZip();
                Console.WriteLine($"Contacts in Address Book '{addressBookName}' sorted by ZIP.");
            }
            else
            {
                Console.WriteLine($"Address Book '{addressBookName}' does not exist.");
            }
        }
    }
}