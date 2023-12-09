using AdressBookConsole.Interfaces;
using Newtonsoft.Json;
using System.Diagnostics;

namespace AdressBookConsole.Models
{
    public class ContactService : IContactService
    {
        private List<IContact> _contactList = new List<IContact>();

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
                        bool res = _fileService.WriteToFile(_contactList);

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

        public ICollection<IContact> GetAllContactsFromList()
        {
            if (_contactList.Any())
                return _contactList;
            else
                return null!;
        }

        public void GetContactFromList(string email)
        {

            for (int i = 0; i < _contactList.Count; i++)
            {
                if (_contactList[i].Email == email)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\n---------------------------------------------------------");
                    Console.WriteLine($"\t{_contactList[i].FirstName} {_contactList[i].LastName}");
                    Console.WriteLine($"\t{_contactList[i].Email}, {_contactList[i].PhoneNumber}");
                    Console.WriteLine($"\t{_contactList[i].Street}, {_contactList[i].ZipCode}");
                    Console.WriteLine($"\t{_contactList[i].City}, {_contactList[i].Country}");
                    Console.WriteLine("---------------------------------------------------------");
                }
            }
        }

        public bool DeleteContact(string email)
        {
            for (int i = 0; i < _contactList.Count; i++)
            {
                if (_contactList[i].Email == email)
                {
                    _contactList.RemoveAt(i);
                    _fileService.WriteToFile(_contactList);
                    return true;
                }
            }
            return false;
        }

        public void Deserializer()
        {
            try
            {
                var fileContent = _fileService.ReadFromFile();

                if (!string.IsNullOrEmpty(fileContent))
                {
                    _contactList = JsonConvert.DeserializeObject<List<IContact>>(fileContent, new JsonSerializerSettings
                    {
                        TypeNameHandling = TypeNameHandling.Auto
                    })!;
                }
            }
            catch (Exception e) { Debug.WriteLine(e); }
        }
    }
}
