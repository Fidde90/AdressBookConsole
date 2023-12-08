
using AdressBookConsole.Interfaces;
using Newtonsoft.Json;
using System.Diagnostics;

namespace AdressBookConsole.Services
{
    public class FileService : IFileService
    {
        private readonly string _filePath = @"C:\AdressBookCsharp\AdressBookConsole\Test.json";

        public bool WriteToFile(List<IContact> contactList)
        {
            string list = JsonConvert.SerializeObject(contactList, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                TypeNameHandling = TypeNameHandling.Auto
            });

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
            return null ?? "";
        }
    }
}
