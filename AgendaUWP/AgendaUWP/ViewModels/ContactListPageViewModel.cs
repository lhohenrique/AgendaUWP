using AgendaUWP.Models;
using Prism.Commands;
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
        private INavigationService _navigationService;

        private ObservableCollection<ContactItemsGroup> data;
        public ObservableCollection<ContactItemsGroup> Data
        {
            get { return data; }
            set { SetProperty(ref data, value); }
        }

        public IEnumerable<ContactItemsGroup> GroupedContactItems { get; private set; }


        public DelegateCommand<Contact> EditCommand { get; private set; }

        #region initializers
        private void InitilizeCommands()
        {
            EditCommand = new DelegateCommand<Contact>(EditContact);
        }
        #endregion

        private void EditContact(Contact contact)
        {
            _navigationService.Navigate(PageTokens.DetailContactPage, contact);
        }

        public ContactListPageViewModel(IContactService<Contact> contactService, INavigationService navigationService)
        {
            this._contactService = contactService;
            this._navigationService = navigationService;
            Data = GetData();
            InitilizeCommands();
        }

        private ObservableCollection<ContactItemsGroup> GetData()
        {
            var contacts = _contactService.GetContacts();
            if (contacts != null && contacts.Count() > 0)
            {
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
