
namespace AdressBookConsole.Interfaces
{
    public interface IFileService
    {
        bool WriteToFile(List<IContact> contactList);

        string ReadFromFile();
    }
}
