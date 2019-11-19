using Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Model
{
    public interface IGroupedContactItems : IGrouping<Char, Contact>
    {
    }
}
