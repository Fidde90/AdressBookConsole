
namespace AdressBookConsole.Interfaces
{
    public interface IContactService
    {
        bool AddContactToList(IContact contact);

        ICollection<IContact> GetAllContactsFromList();

        void GetContactFromList(string email);

        bool DeleteContact(string email);

        void Deserializer();
    }
}
