
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

        /// <summary>
        /// In this dialogue a new Contact get created and the user writes in all the information needed.
        /// And the contact is added to the list(in contactService file) and saved to a file on the computer.
        /// </summary>
        /// <params name=""></params>
        /// <returns></returns>
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

            Console.Write("\nEnter country: ");
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
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nContact already excists!");
                }
            }
        }

        /// <summary>
        /// All contacts are fetched via a method and then saved to an Array which can then print them all out so the user can see them.
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public void ShowAllContacts()
        {
            Console.Clear();
            try
            {
                var c = _contactService.GetAllContactsFromList().ToArray();
                ShowContacts("Contacts", c);
            }
            catch (Exception e) 
            {
                EmptyList();
                Debug.WriteLine(e);
            }     
        }

        /// <summary>
        /// In this method all contacts get fetched via a method called "GetAllContactsFromList", if the returned value from that method 
        /// is´t Null another method get called and the value from the last method get passed in and all the contacts get displayed on screen. 
        /// Then the user choose witch contact by entering the Index number. The chosen one´s email get passed in to a method called 
        /// "GetContactFromList", and if the email match an email in the list, the contacts details pop up on the screen. 
        /// </summary>
        /// <params name=""></params>
        /// <returns></returns>
        public void ContactDetailsDialogue()
        {
            Console.Clear();
            try
            {
                var c = _contactService.GetAllContactsFromList().ToArray();
                int seeDetails;
                ShowContacts("Details", c);

                do
                {
                    Console.Write("\nEnter index number for more details: ");
                    _ = int.TryParse(Console.ReadLine(), out seeDetails);
                } while (seeDetails > c.Length || seeDetails < 1);

                _contactService.GetContactFromList(c[seeDetails - 1].Email);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                EmptyList();
            }         
        }


        /// <summary>
        /// If the variable "C" is not null, all contacts are displayed on screen and the user can then choose witch contact to delete by entering it´s indexnumber.
        /// The contacts email get passed in to another method witch compares it to all emails in the list and then delets the contact(if the contact excists).
        /// </summary>
        public void DeleteDialogue()
        {
            Console.Clear();
            try
            {
                var c = _contactService.GetAllContactsFromList().ToArray();
                int remove;
                ShowContacts("Remove contact", c);

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
            catch (Exception e) 
            {
                Debug.WriteLine(e);
                EmptyList(); 
            }
        }

        /// <summary>
        /// The get asked if he/she really wants to exit the app, and if so, the program is turned of.
        /// </summary>
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

        /// <summary>
        /// This is a method to display all contacts on screen.
        /// </summary>
        /// <param name="title">the name of the title to display</param>
        /// <param name="c">an Array of IContact</param>
        private static void ShowContacts(string title, IContact[] c)
        {
            Console.Clear();
            Console.WriteLine($"|----|{title}|----|\n");

            for (var i = 0; i < c.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n------------------------------------------------------------------------------------");
                Console.WriteLine($"{i + 1}: {c[i].FirstName} {c[i].LastName}, {c[i].City}");
                Console.WriteLine("------------------------------------------------------------------------------------");
            }
        }

        /// <summary>
        /// Changes the color of the text to dark red and says the list is empty.
        /// </summary>
        private static void EmptyList()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("\nThe list was empty..");
        }
    }
}
