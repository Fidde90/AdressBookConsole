
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
                services.AddSingleton<MainMenu>();
                services.AddSingleton<IMenuService,MenuService>();
                services.AddSingleton<IFileService,FileService>();           
                
            }).Build();

            builder.Start();
            Console.Clear();

            var mainMenu = builder.Services.GetRequiredService<MainMenu>();
            mainMenu.ShowMainMenu();
        }
    }
}
