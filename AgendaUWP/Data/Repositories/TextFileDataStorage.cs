using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataService
{
    public class TextFileDataStorage : IDataStorage
    {
        private string _path;

        public TextFileDataStorage(string path)
        {
            this._path = path;
        }

        public List<IDataRecord> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Save(IDataRecord dataRecord)
        {
            File.WriteAllText(_path, dataRecord.ToString());
        }
    }
}
