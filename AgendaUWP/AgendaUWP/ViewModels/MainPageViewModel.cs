using AgendaUWP.Models;
using Prism.Commands;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaUWP.ViewModels
{
    class MainPageViewModel : ViewModelBase
    {
        #region properties
        private INavigationService navigationService;
        #endregion

        #region constructors
        public MainPageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
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
        public DelegateCommand NavigateToAddContactPageCommand { get; set; }
        #endregion

        #region initializers
        private void InitilizeCommands()
        {
            NavigateToAddContactPageCommand = new DelegateCommand(NavigateToAddContactPage);
        }
        #endregion

        private void NavigateToAddContactPage()
        {
            navigationService.Navigate(PageTokens.AddContactPage, false);
        }
    }
}
