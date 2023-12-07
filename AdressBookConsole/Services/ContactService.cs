using AdressBookConsole.Interfaces;
using Newtonsoft.Json;
using System.Diagnostics;

namespace AdressBookConsole.Models
{
    public class ContactService : IContactService
    {
        private readonly List<IContact> _contactList = new List<IContact>();

        private readonly IFileService _fileService;

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
                        bool res = _fileService.WriteToFile(JsonConvert.SerializeObject(_contactList));
                      
                        if (res == true)
                        {                    
                            return true;
                        }                           
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
