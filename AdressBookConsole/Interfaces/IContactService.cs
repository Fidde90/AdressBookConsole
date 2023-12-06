
using AdressBookConsole.Models;

namespace AdressBookConsole.Interfaces
{
    public interface IContactService
    {
        public void AddContact(IContact contact);

        public void GetAllContacts();

        public Contact GetContact(string email);

        public void DeleteContact();
    }
}
