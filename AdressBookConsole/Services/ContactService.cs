using AdressBookConsole.Interfaces;

namespace AdressBookConsole.Models
{
    public class ContactService : IContactService
    {
        private readonly List<IContact> _contactList = new List<IContact>();

        public void AddContactToList(IContact contact)
        {
            throw new NotImplementedException();
        }

        IEnumerable<IContact> IContactService.GetAllContacts()
        {
            throw new NotImplementedException();
        }

        public Contact GetContact(string email)
        {
            throw new NotImplementedException();
        }

        public void DeleteContact()
        {
            throw new NotImplementedException();
        }  
    }
}
