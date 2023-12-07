
using AdressBookConsole.Interfaces;
using AdressBookConsole.Models;
using System.Diagnostics;

namespace AdressBookConsole.Services
{
    public class MenuService : IMenuService
    {
        private readonly IContactService _contactService;

        public MenuService(IContactService contactService)
        {
            _contactService = contactService;
        }

        public void AddContactDialogue()
        {
            IContact newContact = new Contact();

            Console.Clear();

            Console.Write("\nEnter first name: ");
            newContact.FirstName = Console.ReadLine()!;

            Console.Write("\nEnter last name: ");
            newContact.LastName = Console.ReadLine()!;

            Console.Write("\nEnter phone number (not mandatory): ");
            newContact.PhoneNumber = Console.ReadLine()!;

            Console.Write("\nEnter e-mail: ");
            newContact.Email = Console.ReadLine()!;

            Console.Write("\nEnter street: ");
            newContact.Street = Console.ReadLine()!;

            Console.Write("\nEnter zip code: ");
            newContact.ZipCode = Console.ReadLine()!;

            Console.Write("\nEnter city: ");
            newContact.City = Console.ReadLine()!;

            Console.Write("\nEnter country ");
            newContact.Country = Console.ReadLine()!;

            if (newContact != null)
            {
                bool res = _contactService.AddContactToList(newContact);

                if (res)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nContact added!");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nContact already excists!");
                }
            }
        }

        public void DeleteDialogue()
        {
            throw new NotImplementedException();
        }

        public void ExitDialogue()
        {
            Console.WriteLine("Are you sure you want to exit? (y/n)");
            string yesNo = Console.ReadLine() ?? "";

            if (yesNo.ToLower() == "y")
                Environment.Exit(0);
            else
                return;
        }

        public void ShowAllContacts()
        {
            try
            {
                var contacts = _contactService.GetAllContactsFromList();
              
                if (!contacts.Any())
                {
                    Console.WriteLine("The list was empty..");
                }
                else
                {
                    foreach (var contact in contacts)
                    {
                        Console.WriteLine($"{contact.FirstName} {contact.LastName} {contact.City}");
                    }                
                }
            }
            catch (Exception e) { Debug.WriteLine(e); }   
        }

        public void ContactDetailsDialogue()
        {
            throw new NotImplementedException();
        }
    }
}
