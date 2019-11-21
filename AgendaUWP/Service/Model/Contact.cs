using Data.DataService;
using Prism.Mvvm;
using Windows.UI.Xaml.Media.Imaging;

namespace Service.Model
{
    public class Contact : BindableBase
    {
        #region Constructors
        public Contact(string FullName, string NickName, int Age, string Phone, BitmapImage Photo)
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

        private int _age;
        public int Age
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
        #endregion
    }
}
