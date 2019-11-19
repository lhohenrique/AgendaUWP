using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaUWP.Models
{
    public class ContactItemsGroup : IGrouping<Char, Contact>
    {
        private List<Contact> _contactItemsGroup;

        public ContactItemsGroup(Char key, IEnumerable<Contact> items)
        {
            Key = key;
            _contactItemsGroup = new List<Contact>(items);
        }

        public char Key { get; }

        public IEnumerator<Contact> GetEnumerator() => _contactItemsGroup.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => _contactItemsGroup.GetEnumerator();
    }
}
