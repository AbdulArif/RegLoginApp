using RegLoginApp.Tables;
using SQLite;
using System;
using System.IO;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RegLoginApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        private SQLiteConnection conn;
        RegUserTable regUserTable;
        public LoginPage()
        {
           // SetValue(NavigationPage.HasNavigationBarProperty, false);
            InitializeComponent();
            conn = DependencyService.Get<ISQLite>().GetSQLiteConnection();
            //conn.CreateTable<RegUserTable>();
        }
        //LogIn
        async void Button_Clicked(object sender, EventArgs e)
        {
            //var dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "UserDatabase.db");
            //var db = new SQLiteConnection(dbpath);
            var myquery = conn.Table<RegUserTable>().Where(u => u.UserName.Equals(EntryName.Text) && u.Password.Equals(Entrypassword.Text)).FirstOrDefault();
            if (myquery != null)
            {
                App.Current.MainPage = new NavigationPage(new HomePage());
            }
            else
            {
                var result = await this.DisplayAlert("Error", "User Name or Password incorrect", "Yes", "Cancel");
                if (result)
                    await Navigation.PushAsync(new LoginPage());
                else
                {
                    await Navigation.PushAsync(new LoginPage());
                }
            }
        }
        //SIGNUP
        async void Button_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }

    }
}