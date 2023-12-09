
namespace AdressBookConsole.Interfaces
{
    public interface IContact
    {
        string FirstName { get; set; }

        string LastName { get; set; }

        long PhoneNumber { get; set; }

        string Email { get; set; }

        string Street { get; set; }

        int ZipCode { get; set; }

        string City { get; set; }

        string Country { get; set; }
    }
}

