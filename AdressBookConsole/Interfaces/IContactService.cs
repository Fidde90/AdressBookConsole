
using AdressBookConsole.Models;

namespace AdressBookConsole.Interfaces
{
    public interface IContactService
    {
        bool AddContactToList(IContact contact);

        IEnumerable<IContact> GetAllContactsFromList();

        Contact GetContactFromList(string email);

        bool DeleteContact(string email);
    }
}
