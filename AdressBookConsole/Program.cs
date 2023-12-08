
using AdressBookConsole.Interfaces;
using AdressBookConsole.Models;
using AdressBookConsole.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

namespace AdressBookConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var builder = Host.CreateDefaultBuilder().ConfigureServices(services =>
            {
                services.AddSingleton<IContactService, ContactService>();
                services.AddSingleton<IMenuService, MenuService>();
                services.AddSingleton<IFileService, FileService>();
                services.AddSingleton<MainMenu>();

            }).Build();
            
            builder.Start();
            Console.Clear();
            
            var contactService = builder.Services.GetRequiredService<IContactService>();
            var mainMenu = builder.Services.GetRequiredService<MainMenu>();
            contactService.Deserializer();
            mainMenu.ShowMainMenu();
        }
    }
}
