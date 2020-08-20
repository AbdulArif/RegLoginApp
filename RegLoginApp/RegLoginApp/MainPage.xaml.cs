using RegLoginApp.Tables;
using RegLoginApp.Views;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            //var emailPattern =
            //    "^(?(")(".+?(?<!\\)"@)| (([0 - 9a - z]((\.(? !\.)) |[-!#\$%&'\
            //    *\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))(?(\[)(\[(\d
            //    {1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-
            //        z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";
            var userName = EntryUserName.Text;
            var password = EntryUserPassword.Text;
            var email = EntryUserEmail.Text;
            var PhNo = EntryUserPhoneNumber.Text;
            //if(Regex.IsMatch(email,emailPattern))
            //{

            //}
if (!string.IsNullOrWhiteSpace(userName) && userName.Length < 16 && !string.IsNullOrWhiteSpace(password) && !string.IsNullOrWhiteSpace(email) && !string.IsNullOrWhiteSpace(PhNo) && PhNo.Length < 11) 
            {
                regUserTable = new RegUserTable()
                {
                    UserName = EntryUserName.Text,
                    Password = EntryUserPassword.Text,
                    Email = EntryUserEmail.Text,
                    PhoneNumber = EntryUserPhoneNumber.Text
                };
                conn.Insert(regUserTable);
                Device.BeginInvokeOnMainThread(async () => {
                    var result = await this.DisplayAlert("Congrats", "User registration successfull", "Yes", "Cancel");
                    if (result)
                        await Navigation.PushAsync(new LoginPage());
                });
            }
            else
            {
                DisplayAlert("Alert", "Please insert USER NAME less than 16 digit", "OK");
            }

        }
    }
}
