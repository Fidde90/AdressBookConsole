
using AdressBookConsole.Interfaces;
using AdressBookConsole.Models;

namespace AdressBookConsole.Services
{
    public class MenuService : IMenuService
    {
        private readonly IContactService _contactService;

        public MenuService(IContactService contactService/*,IFileService fileService*/)
        {
            _contactService = contactService;
        }

        public void AddContactDialogue()
        {
            IContact newContact = new Contact();

            Console.Write("Enter first name: ");
            newContact.FirstName = Console.ReadLine()!;

            Console.Write("Enter last name: ");
            newContact.LastName = Console.ReadLine()!;

            Console.Write("Enter phone number (not mandatory): ");
            newContact.PhoneNumber = Console.ReadLine()!;

            Console.Write("Enter e-mail: ");
            newContact.Email = Console.ReadLine()!;

            Console.Write("Enter street: ");
            newContact.Street = Console.ReadLine()!;

            Console.Write("Enter zip code: ");
            newContact.Street = Console.ReadLine()!;

            Console.Write("Enter city: ");
            newContact.City = Console.ReadLine()!;

            Console.Write("Enter country ");
            newContact.Country = Console.ReadLine()!;

            if (newContact != null)
                _contactService.AddContactToList(newContact);
        }

        public void DeleteDialogue()
        {
            throw new NotImplementedException();
        }

        public void ExitDialogue()
        {
            throw new NotImplementedException();
        }

        public void ShowAllContacts()
        {
            throw new NotImplementedException();
        }

        public void ContactDetailsDialogue()
        {
            throw new NotImplementedException();
        }
    }
}
