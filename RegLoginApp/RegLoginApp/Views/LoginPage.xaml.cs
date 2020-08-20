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
            if (!string.IsNullOrWhiteSpace(EntryName.Text) && EntryName.Text.Length < 16 && !string.IsNullOrWhiteSpace(Entrypassword.Text))
            {
                var myquery = conn.Table<RegUserTable>().Where(u => u.UserName.Equals(EntryName.Text) && u.Password.Equals(Entrypassword.Text)).FirstOrDefault();
                if (myquery != null)
                {
                    App.Current.MainPage = new NavigationPage(new Report());
                }
                else
                {
                    var result = await this.DisplayAlert("Alert", "User Name or Password incorrect! Please change.", "Yes", "Cancel");
                    if (result)
                        await Navigation.PushAsync(new LoginPage());
                    else
                    {
                        await Navigation.PushAsync(new LoginPage());
                    }
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