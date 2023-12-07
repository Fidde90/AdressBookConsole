

using AdressBookConsole.Interfaces;

namespace AdressBookConsole.Models
{
    public class MainMenu : IMainMenu
    {
        private readonly IMenuService _menuService;

        public MainMenu(IMenuService menuService)
        {
            _menuService = menuService;
        }

        public void ShowMainMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkYellow;

                Console.WriteLine("|----| AdressBook |----|\n");
                Console.WriteLine($"{"1:",-4} Add contact");
                Console.WriteLine($"{"2:",-4} Show all contacts");
                Console.WriteLine($"{"3:",-4} Show contact details");
                Console.WriteLine($"{"4:",-4} Remove contact from list");
                Console.WriteLine($"{"5:",-4} Close application\n");
                Console.Write("Make a chosie by entering a number: ");
                string choise = Console.ReadLine() ?? "";

                switch (choise)
                {
                    case "1":
                        _menuService.AddContactDialogue();
                        break;

                    case "2":

                        break;

                    case "3":

                        break;

                    case "4":

                        break;

                    case "5":

                        break;

                    default:
                        Console.WriteLine("Something went wrong, please try again..");
                        break;

                }

                Console.ReadKey();
            }
        }
    }
}
