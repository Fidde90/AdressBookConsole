
using AdressBookConsole.Interfaces;
using Newtonsoft.Json;
using System.Diagnostics;

namespace AdressBookConsole.Services
{
    public class FileService : IFileService
    {
        private readonly string _filePath = @"C:\AdressBookCsharp\AdressBookConsole\Test.json";

        /// <summary>
        /// Takes a list of "IContact" in the parameter and converts it to Json format and writes it to a file on the computer.
        /// </summary>
        /// <param name="contactList">A list of IContact</param>
        /// <returns>true if the task was successful, otherwise false.</returns>
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

        /// <summary>
        /// If the file excists at the enterd filepath, the streamreader reads the file, and returns the content.
        /// </summary>
        /// <returns> a string value(the text written in the file), otherwise null or a empty string</returns>
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
