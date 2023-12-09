
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
            long phoneZipNr;

            Console.Clear();

            Console.Write("\nEnter first name: ");
            newContact.FirstName = Console.ReadLine()!;

            Console.Write("\nEnter last name: ");
            newContact.LastName = Console.ReadLine()!;

            do
            {
                Console.Write("\nEnter phone number: ");
            } while (!long.TryParse(Console.ReadLine(), out phoneZipNr));

            newContact.PhoneNumber = phoneZipNr;

            Console.Write("\nEnter e-mail: ");
            newContact.Email = Console.ReadLine()!;

            Console.Write("\nEnter street: ");
            newContact.Street = Console.ReadLine()!;

            do
            {
                Console.Write("\nEnter zipcode number: ");
            }
            while (!long.TryParse(Console.ReadLine(), out phoneZipNr));

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


        }

        public void DeleteDialogue()
        {
            var contacts = _contactService.GetAllContactsFromList().ToArray();

            if (contacts.Length > 0)
            {
                int remove;

                for (var i = 0; i < contacts.Count(); i++)
                    Console.WriteLine($"{i + 1}: {contacts[i].FirstName} {contacts[i].LastName} {contacts[i].City}");

                do
                {
                    Console.Write("Enter index number to remove from list: ");
                    _ = int.TryParse(Console.ReadLine(), out remove);
                } while (remove > contacts.Length || remove < contacts.Length);

                bool res = _contactService.DeleteContact(contacts[remove - 1].Email);

                if (res)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nContact removed!");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Contact does not excist");
                }

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\nThe list was empty..");
            }
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

    }
}
