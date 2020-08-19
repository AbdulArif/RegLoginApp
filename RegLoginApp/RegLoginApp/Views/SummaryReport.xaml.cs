using RegLoginApp.Tables;
using SQLite;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RegLoginApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SummaryReport : ContentPage
    {
        private SQLiteConnection conn;

        public IList<string> aggCountdata2;

        public SummaryReport()
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
                                group cou2 by new { cou2.Name, cou2.TaskName } into g
                                select new { aName = g.Key.Name, aTaskName = g.Key.TaskName, aCount = g.Sum(u => u.Count) };

            var selItem = ((Picker)sender).SelectedItem;
            var fltList = from ag in aggCountdata2 where ag.aName.Contains((string)selItem) select ag; //filtered List

            if ((string)selItem == "Show All")
            {
                ListCountSumData.ItemsSource = aggCountdata2;
            }
            else
            {
                ListCountSumData.ItemsSource = fltList;
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