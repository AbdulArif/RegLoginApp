using RegLoginApp.Tables;
using RegLoginApp.Views;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RegLoginApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private SQLiteConnection conn;
        RegUserTable regUserTable;
        public MainPage()
        {
            //SetValue(NavigationPage.HasNavigationBarProperty, false);
            InitializeComponent();
            conn = DependencyService.Get<ISQLite>().GetSQLiteConnection();
            conn.CreateTable<RegUserTable>();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            //var dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "UserDatabase.db");
            //var db = new SQLiteConnection(dbpath);
            //db.CreateTable<RegUserTable>();
            var item = new RegUserTable()
            {
                UserName = EntryUserName.Text,
                Password = EntryUserPassword.Text,
                Email = EntryUserEmail.Text,
                PhoneNumber = EntryUserPhoneNumber.Text
            };
            conn.Insert(item);
            Device.BeginInvokeOnMainThread(async () => {
                var result = await this.DisplayAlert("Congrats", "User registration successfull", "Yes", "Cancel");
                if (result)
                    await Navigation.PushAsync(new LoginPage());
            });
        }
    }
}
