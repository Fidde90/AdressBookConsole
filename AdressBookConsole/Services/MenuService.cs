
using AdressBookConsole.Interfaces;
using AdressBookConsole.Models;

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

            Console.WriteLine("|----| Add Contact |----|\n");

            Console.Write("\nEnter first name: ");
            newContact.FirstName = Console.ReadLine()!;

            Console.Write("\nEnter last name: ");
            newContact.LastName = Console.ReadLine()!;

            Console.Write("\nEnter phone number: ");
            newContact.PhoneNumber = Console.ReadLine()!;

            Console.Write("\nEnter e-mail: ");
            newContact.Email = Console.ReadLine()!;

            Console.Write("\nEnter street: ");
            newContact.Street = Console.ReadLine()!;

            Console.Write("\nEnter zipcode number: ");
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

        public void ShowAllContacts()
        {
            Console.Clear();
            if (_contactService.GetAllContactsFromList() == null)
                emptyList();
            else
            {
                var c = _contactService.GetAllContactsFromList().ToArray();
                showContacts("Contacts", c);
            }
        }

        public void ContactDetailsDialogue()
        {
            Console.Clear();

            if (_contactService.GetAllContactsFromList() == null)
                emptyList();
            else
            {
                var c = _contactService.GetAllContactsFromList().ToArray();
                int seeDetails;

                showContacts("Details", c);

                do
                {
                    Console.Write("\nEnter index number for more details: ");
                    _ = int.TryParse(Console.ReadLine(), out seeDetails);
                } while (seeDetails > c.Length || seeDetails < 1);

                _contactService.GetContactFromList(c[seeDetails - 1].Email);
            }
        }

        public void DeleteDialogue()
        {
            Console.Clear();

            if (_contactService.GetAllContactsFromList() == null)
                emptyList();
            else
            {
                var c = _contactService.GetAllContactsFromList().ToArray();
                int remove;
                showContacts("Remove contact", c);

                do
                {
                    Console.Write("\nEnter index number to remove from list: ");
                    _ = int.TryParse(Console.ReadLine(), out remove);
                } while (remove > c.Length || remove < 1);

                bool res = _contactService.DeleteContact(c[remove - 1].Email);

                if (res)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nContact removed!");
                }
            }
        }

        public void ExitDialogue()
        {
            Console.Clear();
            Console.WriteLine("|----| Exit |----|\n");
            Console.Write("Are you sure you want to exit? (y/n): ");
            string yesNo = Console.ReadLine() ?? "";

            if (yesNo.ToLower() == "y")
                Environment.Exit(0);
            else
                return;
        }

        private void showContacts(string title, IContact[] c)
        {
            Console.Clear();
            Console.WriteLine($"|----|{title}|----|\n");

            for (var i = 0; i < c.Count(); i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("----------------------------------");
                Console.WriteLine($"{i + 1}: {c[i].FirstName} {c[i].LastName}, {c[i].City}");
                Console.WriteLine("----------------------------------");
            }
        }

        private void emptyList()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("\nThe list was empty..");
        }
    }
}
