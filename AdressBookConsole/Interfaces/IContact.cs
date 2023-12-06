
namespace AdressBookConsole.Interfaces;

public interface IContact
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public int PhoneNumber { get; set; }

    public string Email { get; set; }

    public string Street { get; set; }

    public int PostalCode { get; set; }

    public string City { get; set; }
}
