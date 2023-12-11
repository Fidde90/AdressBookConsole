﻿using AdressBookConsole.Interfaces;

namespace AdressBookConsole.Models
{
    public class Contact : IContact
    {
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Street { get; set; } = null!;

        public string ZipCode { get; set; } = null!;

        public string City { get; set; } = null!;

        public string Country { get; set; } = null!;


        public Contact() { }

        public Contact(string firstName, string lastName, string phoneNumber, string email, string street, string zipCode, string city, string country)
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

