
using Microsoft.Extensions.Hosting;

namespace AdressBookConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var builder = Host.CreateDefaultBuilder().ConfigureServices(services =>
            {

            });

            builder.Start();
            Console.Clear();
        }
    }
}
