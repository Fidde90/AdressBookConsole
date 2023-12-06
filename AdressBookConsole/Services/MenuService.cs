
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
            throw new NotImplementedException();
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
