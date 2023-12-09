
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
            showContacts();
        }

        public void ContactDetailsDialogue()
        {
            var contacts = _contactService.GetAllContactsFromList().ToArray();

            if (contacts.Length > 0)
            {
                int seeDetails;

                showContacts();

                do
                {
                    Console.Write("\nEnter index number for more details: ");
                    _ = int.TryParse(Console.ReadLine(), out seeDetails);
                } while (seeDetails > contacts.Length || seeDetails < 1);

                _contactService.GetContactFromList(contacts[seeDetails - 1].Email);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\nThe list was empty..");
            }
        }

        public void DeleteDialogue()
        {
            var contacts = _contactService.GetAllContactsFromList().ToArray();

            if (contacts.Length > 0)
            {
                int remove;
                showContacts();

                do
                {
                    Console.Write("\nEnter index number to remove from list: ");
                    _ = int.TryParse(Console.ReadLine(), out remove);
                } while (remove > contacts.Length || remove < 1);

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

        private void showContacts()
        {
            var c = _contactService.GetAllContactsFromList().ToArray();

            if (c == null)
                Console.WriteLine("List was empty");
            else
            {
                for (var i = 0; i < c.Count(); i++)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("----------------------------------");
                    Console.WriteLine($"{i + 1}: {c[i].FirstName} {c[i].LastName}, {c[i].City}");
                    Console.WriteLine("----------------------------------");
                }
            }
        }
    }
}
