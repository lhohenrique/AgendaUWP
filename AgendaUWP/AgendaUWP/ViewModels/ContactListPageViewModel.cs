using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using Service.Contact;
using Service.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace AgendaUWP.ViewModels
{
    public class ContactListPageViewModel : ViewModelBase
    {
        private readonly IContactService<Contact> _contactService;

        private ObservableCollection<ContactItemsGroup> data;
        public ObservableCollection<ContactItemsGroup> Data
        {
            get { return data; }
            set { SetProperty(ref data, value); }
        }

        public IEnumerable<ContactItemsGroup> GroupedContactItems { get; private set; }
        
        public ContactListPageViewModel(IContactService<Contact> contactService)
        {
            this._contactService = contactService;
            Data = GetData();
        }

        private ObservableCollection<ContactItemsGroup> GetData()
        {
            var contacts = _contactService.GetContacts();
            if (contacts != null && contacts.Count() > 0) {
                GroupedContactItems = contacts.GroupBy(m => m.FullName[0], (key, list) => new ContactItemsGroup(key, list));
                return new ObservableCollection<ContactItemsGroup>(GroupedContactItems);
            }
            else
            {
                return null;
            }
        }
    }
}
