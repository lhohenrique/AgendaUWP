using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaUWP.Models
{
    public class Contact : BindableBase
    {
        #region properties
        private string _url;
        public string URL
        {
            get { return _url; }
            set { SetProperty(ref _url, value); }
        }

        private string _fullname;
        public string FullName
        {
            get { return _fullname; }
            set { SetProperty(ref _fullname, value); }
        }

        private string _nickname;
        public string NickName
        {
            get { return _nickname; }
            set { SetProperty(ref _nickname, value); }
        }

        private int _age;
        public int Age
        {
            get { return _age; }
            set { SetProperty(ref _age, value); }
        }

        private int _phone;
        public int Phone
        {
            get { return _phone; }
            set { SetProperty(ref _phone, value); }
        }
        #endregion
    }
}
