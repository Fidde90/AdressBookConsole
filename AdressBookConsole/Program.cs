
using AdressBook_Library.Interfaces;
using AdressBookConsole.Interfaces;
using AdressBookConsole.Models;
using AdressBook_Library.Services;
using AdressBookConsole.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AdressBookConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ///<suammry>
            /// all files that are dependent on each other(this is the dependency injection)
            /// </suammry>
            var builder = Host.CreateDefaultBuilder().ConfigureServices(services =>
            {
                services.AddSingleton<IPersonService, PersonService>();
                services.AddSingleton<IMenuService, MenuService>();
                services.AddSingleton<IFileService, FileService>();
                services.AddSingleton<MainMenu>();

            }).Build();
            
            builder.Start();
            Console.Clear();
            
            var PersonService = builder.Services.GetRequiredService<IPersonService>();
            var mainMenu = builder.Services.GetRequiredService<MainMenu>();
            mainMenu.ShowMainMenu();
        }
    }
}
