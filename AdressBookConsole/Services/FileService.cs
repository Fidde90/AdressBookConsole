
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
            ///<summary>
            ///Takes a list of "IContact" in the parameter and converts it to Json format and writes it to a file on the computer.
            ///If the task does not succeed it will return a boolen value of false.
            /// <summary>
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
            ///<summary>
            ///If the file excists at the enterd filepath, the streamreader reads the file and returns the content.
            ///else it return a valye of null or a empty string.
            /// </summary>
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
