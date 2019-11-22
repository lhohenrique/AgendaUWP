using AgendaUWP.Models;
using Prism.Commands;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using Service.Interface;
using Service.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace AgendaUWP.ViewModels
{
    public class ContactListPageViewModel : ViewModelBase
    {

        #region properties

        private readonly IContactService _contactService;
        private INavigationService _navigationService;

        private ObservableCollection<ContactItemsGroup> data;
        public ObservableCollection<ContactItemsGroup> Data
        {
            get { return data; }
            set { SetProperty(ref data, value); }
        }

        public IEnumerable<ContactItemsGroup> GroupedContactItems { get; private set; }

        private string _searchQuery;
        public string SearchQuery
        {
            get { return _searchQuery; }
            set
            {
                SetProperty(ref _searchQuery, value);
                Search(_searchQuery);
            }
        }

        #endregion

        #region constructors

        public ContactListPageViewModel(IContactService contactService, INavigationService navigationService)
        {
            this._contactService = contactService;
            this._navigationService = navigationService;
            Data = GetData();
            InitilizeCommands();
        }

        #endregion

        #region commands

        public DelegateCommand<Contact> DetailCommand { get; private set; }

        #endregion

        #region initializers

        private void InitilizeCommands()
        {
            DetailCommand = new DelegateCommand<Contact>(GoToDetailContact);
        }

        #endregion

        #region methods

        private void GoToDetailContact(Contact contact)
        {
            _navigationService.Navigate(PageTokens.ContactDetailPage, contact);
        }

        private ObservableCollection<ContactItemsGroup> GetData()
        {
            var contacts = _contactService.GetAll();

            GroupedContactItems = GetGroupedContactItemsFromList(contacts);

            return new ObservableCollection<ContactItemsGroup>(GroupedContactItems);

        }

        private void Search(string query)
        {
            var contacts = _contactService.GetAll();

            query = query.ToLowerInvariant();
            contacts = contacts.Where(obj => obj.FullName.ToLowerInvariant().Contains(query)).ToList();

            GroupedContactItems = GetGroupedContactItemsFromList(contacts);

            Data = new ObservableCollection<ContactItemsGroup>(GroupedContactItems);
        }

        private IEnumerable<ContactItemsGroup> GetGroupedContactItemsFromList(IEnumerable<Contact> contacts)
        {
            return GroupedContactItems = contacts
                                    .OrderBy(c => c.FullName)
                                    .GroupBy(c => c.FullName.FirstOrDefault(), (key, list) => new ContactItemsGroup(key, list));
        }
        #endregion
    }
}
