using System;
using System.Collections.Generic;
using Data.DataService;
using Prism.Mvvm;
using Windows.UI.Xaml.Media.Imaging;

namespace Service.Model
{
    public class Contact : BindableBase
    {
        #region Constructors
        public Contact(string FullName, string NickName, string Age, string Phone, BitmapImage Photo)
        {
            this.FullName = FullName;
            this.NickName = NickName;
            this.Age = Age;
            this.Phone = Phone;
        }
        
        public Contact()
        {

        }
        #endregion

        #region properties
        BitmapImage _photo;
        public BitmapImage Photo
        {
            get {return _photo;}
            set { SetProperty(ref _photo, value);}
        }

        private string _url;
        public string URL
        {
            get { return _url; }
            private set { SetProperty(ref _url, value); }
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

        private string _age;
        public string Age
        {
            get { return _age; }
            set { SetProperty(ref _age, value); }
        }

        private string _phone;
        public string Phone
        {
            get { return _phone; }
            set { SetProperty(ref _phone, value); }
        }

        public override string ToString()
        {
            return FullName + NickName + Age + Phone;
        }

        public void Validate()
        {
            var messages = new List<string>();

            if (IsNullOREmpty(_fullname))
                messages.Add("Invalid Full Name Field");

            if (IsNullOREmpty(_nickname))
                messages.Add("Invalid Nick Name Field");

            if (IsNullOREmpty(_age))
                messages.Add("Invalid Age Field");

            if (IsNullOREmpty(_phone) || !IsValidPhone(_phone))
                messages.Add("Invalid Phone Field");

            if (messages.Count > 0)
                throw new Exception(string.Join(Environment.NewLine, messages));
        }

        private bool IsValidPhone(string phone)
        {
            bool isValid = true;
            try
            {
                System.Convert.ToInt32(phone);
            }
            catch (Exception)
            {
                isValid = false;
            }

            if (phone.Length < 9)
                isValid = false;
            
            return isValid;
        }

        private bool IsNullOREmpty(string field)
        {
            return field == null || field.Length == 0;
        }
        #endregion
    }
}
