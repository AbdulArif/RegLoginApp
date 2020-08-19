﻿using System;
using System.Linq;
using SQLite;
using RegLoginApp.Tables;

using Xamarin.Forms;
using System.Globalization;

namespace RegLoginApp.Views
{

    public partial class Report : ContentPage
    {

        //  public IList<Card> Cards { get; private set; }

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
            // BindingContext = this;  //use it for Cards

            conn = DependencyService.Get<ISQLite>().GetSQLiteConnection();

            //fetches all records for detail report: It works
            var countdata = (from cou in conn.Table<Counts>() select cou);
            foreach (var item in countdata)
            {
                System.Console.WriteLine(item.Date);
            }


            //fetches aggregated count, by Name
            var aggCountdata1 = from cou1 in conn.Table<Counts>()
                                group cou1 by cou1.Name into g
                                select new { aName = g.Key, aCount = g.Sum(u => u.Count) };

            //fetches aggregated count, by Name, By TaskName
            var aggCountdata2 = from cou2 in conn.Table<Counts>()
                                group cou2 by new { cou2.Name, cou2.TaskName } into g
                                select new { aName = g.Key.Name, aTaskName = g.Key.TaskName, aCount = g.Sum(u => u.Count) };


            //Where clause filter: It works
            //var countdata = from cou in conn.Table<Counts>() where cou.Name.Contains("User1") select cou;  //fetches filtered records


            //Let's change the "date string" into a real "date object" in LINQ so that date can be formatted in XAML using StringFormat options

            //Let's first pick the first 10 chars of "MM/DD/YYYY hh:mm:ss tt"

            //Following two lines work!
            var subStrDate = countdata.Select(w => new { w.Name, realDate=w.Date.Substring(0, w.Date.IndexOf(" ")).Trim(), w.TaskName, w.Count });
            ListCountData.ItemsSource = subStrDate;  //realDate is string a string, meaning, StringFormat will not work in XAML

            //Following two lines work too!
            //string to date conversion in the SELECT query of LINQ
            //var res = countdata.Select(w => new { w.Name, realDate = DateTime.ParseExact(w.Date.Substring(0, 10).Trim(), "M/d/yyyy", CultureInfo.InvariantCulture), w.TaskName, w.Count });
            //ListCountData.ItemsSource = res; //here realDate is a date object, you can now do all kinds of date format using StringFormat in XAML
            
        }


        /* public class Card {
            public string PlanName { get; set; }
            public string Charges { get; set; }
            public string TotalDays { get; set; }
            public string DaysInWeek { get; set; } 
        } */
    }
}