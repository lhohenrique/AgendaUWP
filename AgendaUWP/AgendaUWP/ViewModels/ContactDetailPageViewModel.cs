using AgendaUWP.Models;
using Prism.Commands;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using Service;
using Service.Interface;
using Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace AgendaUWP.ViewModels
{
    public class ContactDetailPageViewModel : ViewModelBase
    {
        #region properties
        private INavigationService navigationService;
        private IContactService contactService;
        private Contact selectedContact;
        public Contact SelectedContact
        {
            get { return selectedContact; }
            set { SetProperty(ref selectedContact, value); }
        }


        #endregion

        #region Constructor
        public ContactDetailPageViewModel(INavigationService navigationService, IContactService contactService)
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
            SelectedContact = (Contact)e.Parameter;
        }

        public override void OnNavigatingFrom(NavigatingFromEventArgs e, Dictionary<string, object> viewModelState, bool suspending)
        {
            base.OnNavigatingFrom(e, viewModelState, suspending);
        }
        #endregion

        #region commands
        public DelegateCommand CancelCommand { get; private set; }
        public DelegateCommand<Contact> NavigateToEditContactPageCommand { get; set; }
        public DelegateCommand<Contact> ContactDeleteCommand { get; set; }
        #endregion

        #region initializers
        private void InitilizeCommands()
        {
            CancelCommand = new DelegateCommand(Cancel);
            NavigateToEditContactPageCommand = new DelegateCommand<Contact>(NavigateToEditContactPage);
            ContactDeleteCommand = new DelegateCommand<Contact>(DeleteAsync);
        }
        #endregion


        #region methods
        private void Cancel()
        {
            navigationService.Navigate(PageTokens.MainPage, false);
        }


        private void NavigateToEditContactPage(Contact contact)
        {
            navigationService.Navigate(PageTokens.ContactFormPage, contact);
        }

        private async void DeleteAsync(Contact contact)
        {
            ContentDialogResult ConfirmResult = await DisplayContactDeleteDialog();

            if(ConfirmResult == ContentDialogResult.Primary)
            {
                contactService.Delete(contact);
                navigationService.Navigate(PageTokens.MainPage, false);
            }
        }

        private async Task<ContentDialogResult> DisplayContactDeleteDialog()
        {
            ContentDialog ContactDeleteDialog = new ContentDialog
            {
                Title = "Delete contact permanently?",
                Content = "If you delete this contact, you won't be able to recover it. Do you want to delete it?",
                PrimaryButtonText = "Delete",
                SecondaryButtonText = "Cancel",
                
            };

            return await ContactDeleteDialog.ShowAsync();
        }

        #endregion
    }
}
