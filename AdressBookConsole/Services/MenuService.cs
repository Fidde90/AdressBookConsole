
using AdressBookConsole.Interfaces;
using AdressBookConsole.Models;

namespace AdressBookConsole.Services
{
    public class MenuService : IMenuService
    {
        private readonly ContactService _contactService;

        public MenuService(ContactService contactService) 
        {
            _contactService = contactService;
        }

        public void AddContactDialog()
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

        public void DeleteDialog()
        {
            throw new NotImplementedException();
        }

        public void ExitDialog()
        {
            throw new NotImplementedException();
        }

        public void ShowAllContacts()
        {
            throw new NotImplementedException();
        }

        public void ContactDetailsDialog()
        {
            throw new NotImplementedException();
        }
    }
}
