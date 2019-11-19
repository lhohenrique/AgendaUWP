using AgendaUWP.Models;
using AgendaUWP.Service;
using Prism.Windows.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaUWP.ViewModels
{
    public class ContactListPageViewModel : ViewModelBase
    {
        private readonly IDataService _dataService;

        public ContactListPageViewModel(IDataService dataService)
        {
            this._dataService = dataService;
            GetData();
        }

        private void GetData()
        {
            var contacts = _dataService.GetContacts();
            GroupedContactItems = contacts.GroupBy(m => m.FullName[0] , (key, list) => new ContactItemsGroup(key, list));
        }

        public IEnumerable<ContactItemsGroup> GroupedContactItems { get; private set; }
    }
}
