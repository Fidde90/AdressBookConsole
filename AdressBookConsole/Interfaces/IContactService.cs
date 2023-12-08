
using AdressBookConsole.Models;
using System.Text.Json.Nodes;

namespace AdressBookConsole.Interfaces
{
    public interface IContactService
    {
        bool AddContactToList(IContact contact);

        ICollection<IContact> GetAllContactsFromList();

        Contact GetContactFromList(string email);

        bool DeleteContact(string email);

        void Deserializer();
    }
}
