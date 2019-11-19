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
        #endregion

        #region Constructor
        public AddContactPageViewModel(INavigationService navigationService, IContactService<Contact> contactService)
        {
            this.navigationService = navigationService;
            this.contactService = contactService;
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
        public DelegateCommand SaveContactCommand { get; private set; }
        public DelegateCommand CancelSaveCommand { get; private set; }
        #endregion

        #region initializers
        private void InitilizeCommands()
        {
            SaveContactCommand = new DelegateCommand(SaveContact);
            CancelSaveCommand  = new DelegateCommand(CancelSave);
        }
        #endregion

        private void SaveContact()
        {
            
        }

        private void CancelSave()
        {
            navigationService.Navigate(PageTokens.MainPage, false);
        }
    }
}
