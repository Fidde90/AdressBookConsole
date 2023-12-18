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

        /// <summary>
        /// Adds a contact to the list.
        /// </summary>
        /// <param name="contact">IContact</param>
        /// <returns>true if the contact's email does not match anyone else's in the list, otherwise false</returns>
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

        /// <summary>
        /// Checks if the list contains any values.
        /// </summary>
        /// <returns>returns the list of contacts if true, else null</returns>
        public ICollection<IContact> GetAllContactsFromList()
        {
            if (_contactList.Any())
                return _contactList;
            else
                return null!;
        }

        /// <summary>
        /// Shows all information of the chosen contact.
        /// </summary>
        /// <param name="email">the email value of the contact(string)</param>
        public void GetContactFromList(string email)
        {
            Console.Clear();
            for (int i = 0; i < _contactList.Count; i++)
            {
                if (_contactList[i].Email == email)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\n------------------------------------------------------------------------------------");
                    Console.WriteLine($"\t{_contactList[i].FirstName} {_contactList[i].LastName}");
                    Console.WriteLine($"\t{_contactList[i].Email}, {_contactList[i].PhoneNumber}");
                    Console.WriteLine($"\t{_contactList[i].Street}, {_contactList[i].ZipCode}");
                    Console.WriteLine($"\t{_contactList[i].City}, {_contactList[i].Country}");
                    Console.WriteLine("------------------------------------------------------------------------------------");
                }
            }
        }

        /// <summary>
        /// Checks if the contact excists via its email and delete him/her from the list.
        /// Then the file on the computer gets updated with the modified list.
        /// </summary>
        /// <param name="email">the eamil value(string) of the contact</param>
        /// <returns>true om the contact was deleted, false if the contact dosent excist</returns>
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

        /// <summary>
        /// Deserializes the Json object to a .Net type using JsonSerializerSettings.
        /// </summary>
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
 