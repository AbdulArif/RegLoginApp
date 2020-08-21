using System;
using System.Linq;
using SQLite;
using RegLoginApp.Tables;

using Xamarin.Forms;
using System.Globalization;
using System.Collections.Generic;
using Xamarin.Forms.Xaml;

namespace RegLoginApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChangeCounts : ContentPage
    {

        private SQLiteConnection conn;

        public ChangeCounts()
        {
            InitializeComponent();
            #region
            conn = DependencyService.Get<ISQLite>().GetSQLiteConnection();

            //Set User name ino the Picker
            var userName = (from regU in conn.Table<RegUserTable>() select regU.UserName).Distinct().ToList(); //fetch Distinct
            userName.Insert(0, "Show All"); //add a new entry at the top of the list, also can use userName.Prepend("Show All")
            NamePicker.ItemsSource = userName;
            NamePicker.SelectedItem = "Show All"; //default value OR, NamePicker.SelectedIndex=0
        }
        #endregion
        private void Picker_OnSelectedIndexChanged(object sender, EventArgs e)
        {

            var detData = from cou2 in conn.Table<Counts>() select cou2;

            var selItem = ((Picker)sender).SelectedItem;
            var fltList = from ag in detData where ag.Name.Contains((string)selItem) select ag; //filtered List

            if ((string)selItem == "Show All")
            {
                //Following two lines work!
                var subStrDate = detData.Select(w => new { w.ID, w.Name, realDate = w.Date.Substring(0, w.Date.IndexOf(" ")).Trim(), w.TaskName, w.Count });
                ListCountData.ItemsSource = subStrDate;  //realDate is string a string, meaning, StringFormat will not work in XAML
            }
            else
            {
                var fltStrDate = fltList.Select(f => new { f.ID, f.Name, realDate = f.Date.Substring(0, f.Date.IndexOf(" ")).Trim(), f.TaskName, f.Count });
                ListCountData.ItemsSource = fltStrDate;
            }
        }

        async void OnTapDoThis_1(object sender, EventArgs e)
        {
            ViewCell lblClicked = (ViewCell)sender;
            string txt = lblClicked.ToString(); //do not know how to parse the viewcell elements

            //await Navigation.PushAsync(updateTask);

            await DisplayAlert("Message", "You tapped me on " + txt + " !", "Ok");
            //await Navigation.PushAsync(new UpdateCounts());
        }
        async void OnTapDoThis_2(object sender, EventArgs e)
        {
            Label lblClicked = (Label)sender;
            int myId = Convert.ToInt32(lblClicked.Text);

            var detData = from cou2 in conn.Table<Counts>() select cou2;
            var fltList = from ag in detData where ag.ID.Equals(myId) select ag; //filtered List

            await DisplayAlert("Message", "You tapped me on " + myId + " !", "Ok");
            //await Navigation.PushAsync(new UpdateCounts());
        }
    }
}