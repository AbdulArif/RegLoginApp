using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RegLoginApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Report : ContentPage
    {

        // public List<Card> datagrids { get; set; }
        //public MyItems ObservableCollection<Card> { get; set; }

        public Report()
        {
            
            InitializeComponent();
           // List<Card> myCard = myCard.Add(new Card() { PlanName = "plan1", Charges = "1500", TotalDays = "12", DaysInWeek = "21" });

            List<Card> cards = new List<Card>
                {
                   new Card{ PlanName = "plan1", Charges = "1500", TotalDays = "12", DaysInWeek = "21"  }
                   
                };
            //MyItems = new ObservableCollection<Card>();
            //myCard.Add(new Card() { PlanName = "plan1", Charges = "1500", TotalDays = "12", DaysInWeek="21" });
            //MyItems.Add(new Card() { PlanName = "plan2", Charges = "2500", TotalDays = "22", DaysInWeek = "22" });
            //datagrids.Add(new Card() { PlanName = "plan3", Charges = "3500", TotalDays = "32", DaysInWeek = "23" });
            //datagrids.Add(new Card() { PlanName = "plan4", Charges = "4500", TotalDays = "42", DaysInWeek = "24" });
            //datagrids.Add(new Card() { PlanName = "plan5", Charges = "5500", TotalDays = "52", DaysInWeek = "25" });
             BindingContext = cards;
            //datalist.ItemsSource = cards;
        }
        public class Card{
            public string PlanName { get; set; }
            public string Charges { get; set; }
            public string TotalDays { get; set; }
            public string DaysInWeek { get; set; }
        }
    }
}