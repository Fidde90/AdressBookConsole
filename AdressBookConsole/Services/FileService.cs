
using AdressBookConsole.Interfaces;
using System.Diagnostics;

namespace AdressBookConsole.Services
{
    public class FileService : IFileService
    {
        private readonly string _filePath = @"C:\AdressBookCsharp\AdressBookConsole\Test.json";

        public bool WriteToFile(string list)
        {
            try
            {
                if (!string.IsNullOrEmpty(list))
                {
                    using (StreamWriter writer = new StreamWriter(_filePath))
                    {
                        writer.WriteLine(list);
                        return true;
                    }
                }
            }
            catch (Exception e) { Debug.WriteLine(e); }
            return false;
        }

        public string ReadFromFile()
        {
            try
            {

                if (File.Exists(_filePath))
                {
                    using (StreamReader reader = new StreamReader(_filePath))
                    {
                        return reader.ReadToEnd();

                    }
                }


            }
            catch(Exception e) { Debug.WriteLine(e);}
            return null;
        }
    }
}
