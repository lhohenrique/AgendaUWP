﻿using Newtonsoft.Json;
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
            CreateContactFile();
        }

        public async void CreateContactFile()
        {
            _newFolder = await ApplicationData.Current.LocalFolder.CreateFolderAsync(_folderName, CreationCollisionOption.OpenIfExists);

            try
            {
                StorageFile storageFile = await _newFolder.GetFileAsync(_fileName);
                _file = storageFile;
            }
            catch
            {
                _file = await _newFolder.CreateFileAsync(_fileName);
                File.WriteAllText(_file.Path, JsonConvert.SerializeObject(new List<T>()));
            }

        }

        public void Delete(T parm)
        {
            IEnumerable<T> all = GetAll();
            List<T> list = all.Where(obj => obj.ToString() != parm.ToString()).ToList();
            UpdateFile(list);
        }

        public IEnumerable<T> GetAll()
        {
            List<T> results = new List<T>();

            if (_file != null)
            {
                string file = File.ReadAllText(@_file.Path);
                results = JsonConvert.DeserializeObject<List<T>>(file);
            }
            return results;
        }

        public T GetById(object id)
        {
            throw new NotImplementedException();
        }

        public void Insert(T parm)
        {
            List<T> list = GetAll().ToList();
            list.Add(parm);
            UpdateFile(list);
        }

        public void Update(T parm)
        {
            IEnumerable<T> all = GetAll();
            List<T> list = all.Where(obj => obj.ToString() != parm.ToString()).ToList();
            list.Add(parm);
            UpdateFile(list);
        }

        private void UpdateFile(List<T> list)
        {
            File.WriteAllText(_file.Path, "");
            File.AppendAllText(_file.Path, JsonConvert.SerializeObject(list));
        }
    }
}
