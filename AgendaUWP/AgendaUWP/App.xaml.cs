using AgendaUWP.Models;
using Data.DataService;
using Prism.Unity.Windows;
using Service.Services;
using Service.Interface;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;

namespace AgendaUWP
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : PrismUnityApplication
    {
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
        }

        protected override Task OnLaunchApplicationAsync(LaunchActivatedEventArgs args)
        {
            NavigationService.Navigate(PageTokens.MainPage, null);
            return Task.FromResult<object>(null);
        }

        protected override void ConfigureContainer()
        {
            RegisterTypeIfMissing(typeof(IContactService), typeof(ContactService), true);            
            base.ConfigureContainer();
        }
    }
}
