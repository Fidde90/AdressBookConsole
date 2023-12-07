using AdressBookConsole.Interfaces;
using System.Diagnostics;

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
            try
            {
                if (contact != null)
                {
                    if (!_contactList.Any(x => x.Email == contact.Email))
                    {
                        _contactList.Add(contact);
                        return true;
                    }
                }
            }
            catch (Exception e) { Debug.WriteLine(e); }
            return false;
        }

        IEnumerable<IContact> IContactService.GetAllContactsFromList()
        {
            return _contactList;
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
