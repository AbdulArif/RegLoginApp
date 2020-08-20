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
    public partial class Report : ContentPage
    {

        private SQLiteConnection conn;

        public IList<string> aggCountdata2;

        public Report()
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
            //fetches aggregated count, by Name, By TaskName
            var aggCountdata2 = from cou2 in conn.Table<Counts>()
                                group cou2 by new { cou2.Name, cou2.TaskName, cou2.Date } into g
                                select new { aName = g.Key.Name, aDate = g.Key.Date, aTaskName = g.Key.TaskName, aCount = g.Sum(u => u.Count) };

            var selItem = ((Picker)sender).SelectedItem;
            var fltList = from ag in aggCountdata2 where ag.aName.Contains((string)selItem) select ag; //filtered List

            if ((string)selItem == "Show All")
            {
                //Following two lines work!
                var subStrDate = aggCountdata2.Select(w => new { w.aName, realDate = w.aDate.Substring(0, w.aDate.IndexOf(" ")).Trim(), w.aTaskName, w.aCount });
                ListCountData.ItemsSource = subStrDate;  //realDate is string a string, meaning, StringFormat will not work in XAML
            }
            else
            {
                var fltStrDate = fltList.Select(f => new { f.aName, realDate = f.aDate.Substring(0, f.aDate.IndexOf(" ")).Trim(), f.aTaskName, f.aCount });
                ListCountData.ItemsSource = fltStrDate;
            }
        }


        /* public class Card {
            public string PlanName { get; set; }
            public string Charges { get; set; }
            public string TotalDays { get; set; }
            public string DaysInWeek { get; set; } 
        } */
    }
}