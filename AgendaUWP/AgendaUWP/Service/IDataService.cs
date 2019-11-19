using AgendaUWP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaUWP.Service
{
    public interface IDataService
    {
        IEnumerable<Contact> GetContacts();
    }
}
