using AgendaUWP.Models;
using Prism.Commands;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using Service.Model;
using Service.Interface;
using System.Collections.Generic;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using System;

namespace AgendaUWP.ViewModels
{
    class ContactFormPageViewModel : ViewModelBase
    {
        #region properties
        private INavigationService navigationService;
        private IContactService contactService;
        private bool IsEdit = false;
        private Contact contact;
        public Contact Contact
        {
            get { return contact; }
            set { SetProperty(ref contact, value); }
        }
        #endregion

        #region Constructor
        public ContactFormPageViewModel(INavigationService navigationService, IContactService contactService)
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

            if(e.Parameter as Contact != null)
            {
                Contact = e.Parameter as Contact;
                IsEdit = true;
            }
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
            if (IsEdit)
            {
                contactService.Update(Contact);
            }
            else
            {
                contactService.Insert(Contact);
            }
            navigationService.Navigate(PageTokens.MainPage, false);
        }

        private void CancelSave()
        {
            navigationService.Navigate(PageTokens.MainPage, false);
        }
    }
}
