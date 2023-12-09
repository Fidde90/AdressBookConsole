using AdressBookConsole.Interfaces;

namespace AdressBookConsole.Models
{
    public class Contact : IContact
    {
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public long PhoneNumber { get; set; } 

        public string Email { get; set; } = null!;

        public string Street { get; set; } = null!;

        public int ZipCode { get; set; } 

        public string City { get; set; } = null!;

        public string Country { get; set; } = null!;


        public Contact() { }

        public Contact(string firstName, string lastName, long phoneNumber, string email, string street, int zipCode, string city, string country)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
            Street = street;
            ZipCode = zipCode;
            City = city;
            Country = country;
        }
    }
}

