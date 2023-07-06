namespace AddressBookSystem
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Wel-Come To Address Book System");
            AddressBook addressBook = new AddressBook();

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
                Console.WriteLine("3. Exit");
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
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}