using Data.DataService;
using Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contact
{
    public class ContactService : IContactService<Model.Contact>
    {
        IDataStorage dataStorage;

        public ContactService(IDataStorage dataStorage)
        {
            this.dataStorage = dataStorage;
        }

        public void Add(Model.Contact contact)
        {
            dataStorage.Save(contact);
        }

        public IEnumerable<Model.Contact> GetContacts()
        {
            return new List<Model.Contact>()
                {
                    new Model.Contact { FullName = "aa Contact 1", Age = 200, NickName = "EHMS"  },
                    new Model.Contact { FullName = "aa Contact 2", Age = 100, NickName = "Dan"  },
                    new Model.Contact { FullName = "bb Contact 3", Age = 200, NickName = "EHMS2"  },
                    new Model.Contact { FullName = "bb Contact 4", Age = 200, NickName = "EHMS2"  },
                    new Model.Contact { FullName = "cc Contact 5", Age = 200, NickName = "EHMS2"  },
                    new Model.Contact { FullName = "cc Contact 6", Age = 200, NickName = "EHMS2"  },
                };
        }
    }
}
