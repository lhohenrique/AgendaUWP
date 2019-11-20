using AgendaUWP.Models;
using Prism.Commands;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using Service.Model;
using Service.Contact;
using System.Collections.Generic;

namespace AgendaUWP.ViewModels
{
    class AddContactPageViewModel : ViewModelBase
    {
        #region properties
        private INavigationService navigationService;
        private IContactService<Contact> contactService;
        private Contact contact;
        public Contact Contact
        {
            get { return contact; }
            set { SetProperty(ref contact, value); }
        }
        #endregion

        #region Constructor
        public AddContactPageViewModel(INavigationService navigationService, IContactService<Contact> contactService)
        {
            this.navigationService = navigationService;
            this.contactService = contactService;
            Contact = new Contact();
            InitilizeCommands();
        }
        #endregion

        #region overrides
        public override void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState)
        {
            base.OnNavigatedTo(e, viewModelState);
        }
        public override void OnNavigatingFrom(NavigatingFromEventArgs e, Dictionary<string, object> viewModelState, bool suspending)
        {
            base.OnNavigatingFrom(e, viewModelState, suspending);
        }
        #endregion

        #region commands
        public DelegateCommand SaveCommand { get; private set; }
        public DelegateCommand CancelCommand { get; private set; }
        #endregion

        #region initializers
        private void InitilizeCommands()
        {
            SaveCommand = new DelegateCommand(SaveContact);
            CancelCommand  = new DelegateCommand(CancelSave);
        }
        #endregion

        private void SaveContact()
        {
            contactService.Add(Contact);
            navigationService.Navigate(PageTokens.MainPage, false);
        }

        private void CancelSave()
        {
            navigationService.Navigate(PageTokens.MainPage, false);
        }
    }
}
