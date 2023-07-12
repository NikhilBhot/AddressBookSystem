using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookSystem
{
    /*UC-01-Ability to create a Contacts in Address
    Book with first and last names, address,
    city, state, zip, phone number and email...
    */
    public class Contact :IComparable<Contact>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public Contact(string firstName, string lastName, string address, string city, string state, string zip, string phoneNumber, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            City = city;
            State = state;
            Zip = zip;
            PhoneNumber = phoneNumber;
            Email = email;
        }

        public void Display()
        {
            Console.WriteLine($"Name: {FirstName} {LastName}");
            Console.WriteLine($"Address: {Address}");
            Console.WriteLine($"City: {City}");
            Console.WriteLine($"State: {State}");
            Console.WriteLine($"Zip: {Zip}");
            Console.WriteLine($"Phone: {PhoneNumber}");
            Console.WriteLine($"Email: {Email}");
            Console.WriteLine();
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Contact other = (Contact)obj;
            return string.Equals(FirstName, other.FirstName, StringComparison.OrdinalIgnoreCase) &&
                   string.Equals(LastName, other.LastName, StringComparison.OrdinalIgnoreCase);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(FirstName.ToLower(), LastName.ToLower());
        }

        public bool MatchesCity(string city)
        {
            return string.Equals(City, city, StringComparison.OrdinalIgnoreCase);
        }

        public bool MatchesState(string state)
        {
            return string.Equals(State, state, StringComparison.OrdinalIgnoreCase);
        }

        public int CompareTo(Contact other)
        {
            // Compare based on the person's full name
            string fullName = $"{FirstName} {LastName}";
            string otherFullName = $"{other.FirstName} {other.LastName}";
            return string.Compare(fullName, otherFullName, StringComparison.OrdinalIgnoreCase);
        }

        public override string ToString()
        {
            // Return a string representation of the contact
            return $"{FirstName} {LastName}\nAddress: {Address}\nCity: {City}\nState: {State}\nZip: {Zip}\nPhone: {PhoneNumber}\nEmail: {Email}\n";
        }
    }
}
