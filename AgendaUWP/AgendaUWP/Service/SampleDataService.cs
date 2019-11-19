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
                    new Contact { FullName = "Eric", Age = 200, NickName = "EHMS"  },
                    new Contact { FullName = "Daniel Barros", Age = 100, NickName = "Dan"  },
                    new Contact { FullName = "Eric2", Age = 200, NickName = "EHMS2"  },
                };
        }
    }
}
