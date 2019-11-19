using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataService
{
    public class ListDataStorage : IDataStorage
    {
        private List<IDataRecord> _records;

        public ListDataStorage()
        {
            _records = new List<IDataRecord>();
        }

        public void Save(IDataRecord dataRecord)
        {
            _records.Add(dataRecord);
        }
    }
}
