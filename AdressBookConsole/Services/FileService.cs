
using AdressBookConsole.Interfaces;
using AdressBookConsole.Models;

namespace AdressBookConsole.Services
{
    public class FileService : IFileService
    {
        private readonly ContactService _contactService;

        public FileService(ContactService contact)
        { 
            _contactService = contact;
        }

        public string ReadFromFile(string path)
        {
            throw new NotImplementedException();
        }

        public bool WriteToFile(string list)
        {
            throw new NotImplementedException();
        }
    }
}
