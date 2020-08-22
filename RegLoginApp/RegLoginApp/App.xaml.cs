using Xamarin.Forms;
using RegLoginApp.Views;
namespace RegLoginApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            //MainPage = new NavigationPage(new Masterdetailpage());
            //MainPage = new NavigationPage(new LoginPage());
            MainPage = new NavigationPage(new ChangeData());
            //MainPage = new NavigationPage(new ChangeTasks());
            //MainPage = new NavigationPage(new EnterData());



            //MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
