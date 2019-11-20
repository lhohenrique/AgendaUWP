using AgendaUWP.Models;
using Prism.Commands;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using Service;
using Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaUWP.ViewModels
{
    public class DetailContactPageViewModel : ViewModelBase
    {
        #region properties
        private INavigationService navigationService;
        private Contact selectedContact;

        public Contact SelectedContact
        {
            get { return selectedContact; }
            set { SetProperty(ref selectedContact, value); }
        }
        #endregion

        #region Constructor
        public DetailContactPageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            InitilizeCommands();
        }
        #endregion

        #region overrides
        public override void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState)
        {
            base.OnNavigatedTo(e, viewModelState);

            if (e.Parameter != null && e.Parameter is Contact)
            {
                var contact = (Contact)e.Parameter;
                SelectedContact = contact;
            }

        }

        public override void OnNavigatingFrom(NavigatingFromEventArgs e, Dictionary<string, object> viewModelState, bool suspending)
        {
            base.OnNavigatingFrom(e, viewModelState, suspending);
        }
        #endregion

        #region commands
        public DelegateCommand CancelCommand { get; private set; }
        #endregion

        #region initializers
        private void InitilizeCommands()
        {
            CancelCommand = new DelegateCommand(Cancel);
        }
        #endregion

        private void Cancel()
        {
            navigationService.Navigate(PageTokens.MainPage, false);
        }
    }
}
