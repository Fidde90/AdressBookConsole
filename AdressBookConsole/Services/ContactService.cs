using AdressBookConsole.Interfaces;

namespace AdressBookConsole.Models
{
    public class ContactService : IContactService
    {
        private readonly IFileService _fileService;

        private readonly List<IContact> _contactList = new List<IContact>();


        public ContactService(IFileService fileService)
        {
            _fileService = fileService;
        }


        public bool AddContactToList(IContact contact)
        {
            throw new NotImplementedException();
        }

        IEnumerable<IContact> IContactService.GetAllContactsFromList()
        {
            throw new NotImplementedException();
        }

        public Contact GetContactFromList(string email)
        {
            throw new NotImplementedException();
        }

        public bool DeleteContact(string email)
        {
            throw new NotImplementedException();
        }  
    }
}
