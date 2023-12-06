
using AdressBookConsole.Models;

namespace AdressBookConsole.Interfaces
{
    public interface IContactService
    {
        void AddContactToList(IContact contact);

        IEnumerable<IContact> GetAllContacts();

        Contact GetContact(string email);

        void DeleteContact();
    }
}
