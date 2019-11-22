using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace Data.DataService
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly string _folderName = "data";
        private readonly string _fileName = "contacts.json";
        private StorageFolder _newFolder;
        private StorageFile _file;

        public GenericRepository()
        {
            createContactFile();
        }

        public async void createContactFile()
        {
            _newFolder = await Windows.Storage.ApplicationData.Current.LocalFolder.CreateFolderAsync(_folderName, CreationCollisionOption.ReplaceExisting);
            _file = await _newFolder.CreateFileAsync(_fileName, CreationCollisionOption.ReplaceExisting);
        }

        public void Delete(object contact)
        {
            string[] linesJSON = null;

            if (_file != null)
            {
                linesJSON = System.IO.File.ReadAllLines(@_file.Path);
                List<T> all = new List<T>();
                for (int i = 0; linesJSON != null && i < linesJSON.Length; i++)
                {
                    T deserializedObject = JsonConvert.DeserializeObject<T>(linesJSON[i]);
                    if( !deserializedObject.ToString().ToLower().Equals(contact.ToString().ToLower()) )
                        all.Add(deserializedObject);
                }

                File.WriteAllText(_file.Path, "");

                all.ForEach(delegate (T obj)
                {
                    Insert(obj);
                });
            }
        }

        public IEnumerable<T> GetAll()
        {
            string[] linesJSON = null;
            List<T> all = new List<T>();

            if (_file != null)
            {
                linesJSON = System.IO.File.ReadAllLines(@_file.Path);
                for (int i = 0; linesJSON != null && i < linesJSON.Length; i++)
                {
                    T deserializedIDataRecord = JsonConvert.DeserializeObject<T>(linesJSON[i]);
                    all.Add(deserializedIDataRecord);
                }
            }

            return all;
        }

        public T GetById(object id)
        {
            throw new NotImplementedException();
        }

        public void Insert(T obj)
        {
            string output = JsonConvert.SerializeObject(obj);
            File.AppendAllText(_file.Path, output + Environment.NewLine);
        }

        public void Update(T obj)
        {
            throw new NotImplementedException();
        }
    }
}
