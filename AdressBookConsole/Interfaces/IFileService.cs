
namespace AdressBookConsole.Interfaces
{
    public interface IFileService
    {
        bool WriteToFile(string list);

        string ReadFromFile(string path);
    }
}
