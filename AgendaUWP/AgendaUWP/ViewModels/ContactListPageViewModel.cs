using Prism.Windows.Mvvm;
using Service.Contact;
using Service.Model;
using System.Collections.Generic;
using System.Linq;

namespace AgendaUWP.ViewModels
{
    public class ContactListPageViewModel : ViewModelBase
    {
        private readonly IContactService<Contact> _contactService;

        public ContactListPageViewModel(IContactService<Contact> contactService)
        {
            this._contactService = contactService;
            GetData();
        }

        private void GetData()
        {
            var contacts = _contactService.GetContacts();
            GroupedContactItems = contacts.GroupBy(m => m.FullName[0] , (key, list) => new ContactItemsGroup(key, list));
        }

        public IEnumerable<ContactItemsGroup> GroupedContactItems { get; private set; }
    }
}
