
using AdressBookConsole.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;

namespace AdressBookConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var builder = Host.CreateDefaultBuilder().ConfigureServices(services =>
            {
                services.AddSingleton<MainMenu>();
            }).Build();

            builder.Start();
            Console.Clear();

            var mainMenu = builder.Services.GetRequiredService<MainMenu>();
            mainMenu.ShowMainMenu();
        }
    }
}
