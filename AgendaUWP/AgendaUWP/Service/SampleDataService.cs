using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgendaUWP.Models;

namespace AgendaUWP.Service
{
    class SampleDataService : IDataService
    {
        public IEnumerable<Contact> GetContacts()
        {
            return new List<Contact>()
                {
                    new Contact { FullName = "aa Contact 1", Age = 200, NickName = "EHMS"  },
                    new Contact { FullName = "aa Contact 2", Age = 100, NickName = "Dan"  },
                    new Contact { FullName = "bb Contact 3", Age = 200, NickName = "EHMS2"  },
                    new Contact { FullName = "bb Contact 4", Age = 200, NickName = "EHMS2"  },
                    new Contact { FullName = "cc Contact 5", Age = 200, NickName = "EHMS2"  },
                    new Contact { FullName = "cc Contact 6", Age = 200, NickName = "EHMS2"  },
                };
        }
    }
}
