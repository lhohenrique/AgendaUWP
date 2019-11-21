using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.DataService;
using Service.Model;

namespace Service.Interface
{
    public interface IContactService : IGenericRepository<Contact>
    {
        
    }
}
