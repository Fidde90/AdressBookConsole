
using AdressBook_Library.Interfaces;
using AdressBookConsole.Interfaces;
using AdressBook_Library.Models;
using System.Diagnostics;

namespace AdressBookConsole.Services
{
    public class MenuService : IMenuService
    {
        private readonly IPersonService _personService;

        public MenuService(IPersonService personService)
        {
            _personService = personService;
        }

        /// <summary>
        /// In this dialogue a new Contact get created and the user writes in all the information needed.
        /// And the contact is added to the list(in Personservice file) and saved to a file on the computer.
        /// </summary>
        /// <params name=""></params>
        /// <returns></returns>
        public void AddPersonDialogue()
        {
            IPerson newPerson = new Person();

            Console.Clear();

            Console.WriteLine("|----| Add Contact |----|\n");

            Console.Write("\nEnter first name: ");
            newPerson.FirstName = Console.ReadLine()!;

            Console.Write("\nEnter last name: ");
            newPerson.LastName = Console.ReadLine()!;

            Console.Write("\nEnter phone number: ");
            newPerson.PhoneNumber = Console.ReadLine()!;

            Console.Write("\nEnter e-mail: ");
            newPerson.Email = Console.ReadLine()!;

            Console.Write("\nEnter street: ");
            newPerson.Street = Console.ReadLine()!;

            Console.Write("\nEnter zipcode number: ");
            newPerson.ZipCode = Console.ReadLine()!;

            Console.Write("\nEnter city: ");
            newPerson.City = Console.ReadLine()!;

            Console.Write("\nEnter country: ");
            newPerson.Country = Console.ReadLine()!;

            if (newPerson != null)
            {
                bool res = _personService.AddPersonToList(newPerson);

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
        /// All Persons are fetched via a method and then saved to an Array which can then print them all out so the user can see them.
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public void ShowAllPersons()
        {
            Console.Clear();
            try
            {
                var pList = _personService.GetAllPersonsFromList().ToArray();   
                ShowPersons("Persons", pList);            
            }
            catch (Exception e)
            {
                EmptyList();
                Debug.WriteLine(e);
            }
        }

        /// <summary>
        /// In this method all Persons get fetched via a method called "GetAllPersonsFromList", if the returned value from that method 
        /// is´t Null another method get called and the value from the last method get passed in and all the Persons get displayed on screen. 
        /// Then the user choose witch contact by entering the Index number. The chosen one´s email get passed in to a method called 
        /// "GetContactFromList", and if the email match an email in the list, the Persons details pop up on the screen. 
        /// </summary>
        /// <params name=""></params>
        /// <returns></returns>
        public void PersonDetailsDialogue()
        {
            Console.Clear();
            try
            {
                var pList = _personService.GetAllPersonsFromList().ToArray();

                if (pList.Length < 1)
                {
                    EmptyList();
                    return;
                }

                int seeDetails;
                ShowPersons("Details", pList);

                do
                {
                    Console.Write("\nEnter index number for more details: ");
                    _ = int.TryParse(Console.ReadLine(), out seeDetails);
                } while (seeDetails > pList.Length || seeDetails < 1);

                var person = _personService.GetPersonFromList(pList[seeDetails - 1].Email);

                Console.Clear();
                Console.WriteLine($"\n {person.FirstName} {person.LastName}");
                Console.WriteLine($" {person.Email}, {person.PhoneNumber}");
                Console.WriteLine($" {person.Street}, {person.ZipCode}");
                Console.WriteLine($" {person.City}, {person.Country}");
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }

        /// <summary>
        /// If the variable "C" is not null, all Persons are displayed on screen and the user can then choose witch contact to delete by entering it´s indexnumber.
        /// The Persons email get passed in to another method witch compares it to all emails in the list and then delets the contact(if the contact excists).
        /// </summary>
        public void DeleteDialogue()
        {
            try
            {            
                var pList = _personService.GetAllPersonsFromList().ToArray();
                int remove;
                ShowPersons("Remove contact", pList);

                if (pList.Length < 1)
                {
                    EmptyList();
                    return;
                }

                do
                {
                    Console.Write("\nEnter index number to remove from list: ");
                    _ = int.TryParse(Console.ReadLine(), out remove);
                } while (remove > pList.Length || remove < 1);

                bool res = _personService.DeletePerson(pList[remove - 1].Email);

                if (res)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nContact removed!");
                }
            }
            catch (Exception e) { Debug.WriteLine(e); }
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

            if (yesNo?.ToLower() == "y")
                Environment.Exit(0);
            else
                return;
        }

        /// <summary>
        /// This is a method to display all Persons on screen.
        /// </summary>
        /// <param name="title">the name of the title to display</param>
        /// <param name="c">an Array of IContact</param>
        private static void ShowPersons(string title, IPerson[] p)
        {
            Console.Clear();
            Console.WriteLine($"|----|{title}|----|\n");

            for (var i = 0; i < p.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("------------------------------------------------------------------------------------");
                Console.WriteLine($"{i + 1}: {p[i].FirstName} {p[i].LastName}, {p[i].City}");
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
