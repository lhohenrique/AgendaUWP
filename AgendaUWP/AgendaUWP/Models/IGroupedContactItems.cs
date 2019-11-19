using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaUWP.Models
{
    public interface IGroupedContactItems : IGrouping<Char, Contact>
    {
    }
}
