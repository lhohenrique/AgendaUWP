﻿using AgendaUWP.Models;
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
    class AddContactPageViewModel : ViewModelBase
    {
        #region properties
        private INavigationService navigationService;
        #endregion

        #region Constructor
        public AddContactPageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            initilizeCommands();
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
        public DelegateCommand SaveContactCommand { get; set; }
        public DelegateCommand CancelSaveCommand { get; set; }
        #endregion

        #region initializers
        private void initilizeCommands()
        {
            SaveContactCommand = new DelegateCommand(SaveContact);
            CancelSaveCommand  = new DelegateCommand(CancelSave);
        }
        #endregion

        private void SaveContact()
        {
            Debug.WriteLine("SaveContact");
        }

        private void CancelSave()
        {
            navigationService.Navigate(PageTokens.MainPage, false);
        }
    }
}