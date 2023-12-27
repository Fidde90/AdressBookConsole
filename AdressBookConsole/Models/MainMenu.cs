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
            ///<summary>
            /// The program's main menu from which the user can make various choices.
            /// Various choises call on various methods that is comming from the menuService file.
            /// </summary>

            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkYellow;

                Console.WriteLine("|----| AdressBook |----|\n");
                Console.WriteLine($"{"1:",-4} Add Person");
                Console.WriteLine($"{"2:",-4} Show all Persons");
                Console.WriteLine($"{"3:",-4} Show Person details");
                Console.WriteLine($"{"4:",-4} Remove Person from list");
                Console.WriteLine($"{"5:",-4} Close application\n");
                Console.Write("\nMake a chosie by entering a number: ");
                string choise = Console.ReadLine() ?? "";

                switch (choise)
                {
                    case "1":
                        _menuService.AddPersonDialogue();
                        break;

                    case "2":
                        _menuService.ShowAllPersons();
                        break;

                    case "3":
                        _menuService.PersonDetailsDialogue();
                        break;

                    case "4":
                        _menuService.DeleteDialogue();
                        break;

                    case "5":
                        _menuService.ExitDialogue();
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
