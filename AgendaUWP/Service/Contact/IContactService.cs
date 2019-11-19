using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contact
{
    public interface IContactService<Contact>
    {
        void Add(Contact contact);        
    }
}
