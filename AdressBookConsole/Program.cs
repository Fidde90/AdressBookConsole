
using AdressBookConsole.Interfaces;
using AdressBookConsole.Models;
using AdressBookConsole.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AdressBookConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var builder = Host.CreateDefaultBuilder().ConfigureServices(services =>
            {
                services.AddSingleton<IMainMenu,MainMenu>();
                services.AddSingleton<IMenuService, MenuService>();
                services.AddSingleton<IFileService, FileService>();
                services.AddSingleton<IContactService, ContactService>();

            }).Build();

            builder.Start();
            Console.Clear();

            var mainMenu = builder.Services.GetRequiredService<IMainMenu>();
            mainMenu.ShowMainMenu();
        }
    }
}
