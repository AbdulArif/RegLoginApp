using System.Collections.Generic;
using System.Linq;
using SQLite;
using RegLoginApp.Tables;

using Xamarin.Forms;

namespace RegLoginApp.Views
{

    public partial class Report : ContentPage
    {

        public IList<Counts> count { get; private set; }

        private SQLiteConnection conn;
        Student student;
        Counts counts;

        public Report()
        {

            InitializeComponent();

            //Cards = new List<Card>();
            //Cards.Add(new Card { PlanName = "plan1", Charges = "15", TotalDays = "12", DaysInWeek = "21" });
            //Cards.Add(new Card { PlanName = "plan2", Charges = "16", TotalDays = "13", DaysInWeek = "22" });
            //Cards.Add(new Card { PlanName = "plan3", Charges = "17", TotalDays = "14", DaysInWeek = "23" });
            //Cards.Add(new Card { PlanName = "plan4", Charges = "18", TotalDays = "13", DaysInWeek = "22" });
            //Cards.Add(new Card { PlanName = "plan5", Charges = "19", TotalDays = "15", DaysInWeek = "24" });
            //BindingContext = this;  //use it for Cards
            //BindingContext = counts;  //use it for LINQ output
            conn = DependencyService.Get<ISQLite>().GetSQLiteConnection();
            var countdata = (from cou in conn.Table<Counts>() select cou);

            var countTemp = (from cou in conn.Table<Counts>() select cou.Count);
            
            
            YourList.ItemsSource = countdata;

        }


        //public class Card
        //{
        //    public string PlanName { get; set; }
        //    public string Charges { get; set; }
        //    public string TotalDays { get; set; }
        //    public string DaysInWeek { get; set; }
        //}
    }
}