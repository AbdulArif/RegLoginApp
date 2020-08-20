using RegLoginApp.Tables;
using SQLite;
using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RegLoginApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EnterData : ContentPage
    {
        private SQLiteConnection conn;
        Counts counts;

        public EnterData()
        {
            InitializeComponent();
            conn = DependencyService.Get<ISQLite>().GetSQLiteConnection();
            conn.CreateTable<Counts>();

            //NamePicker.Items.Add("Arif");
            //NamePicker.Items.Add("Sofik");
            //NamePicker.Items.Add("Akkram");

            var userName = (from regU in conn.Table<RegUserTable>() select regU.UserName).ToList();
            NamePicker.ItemsSource = userName;

            //taskpicker.items.add("t1");
            //taskpicker.items.add("t2");
            //taskpicker.items.add("t3");
            var taskName = (from tsk in conn.Table<MyTask>() select tsk.MyTaskName).ToList();
            TaskPicker.ItemsSource = taskName;
            

        }

        private void Save_Clicked(object sender, EventArgs e)
        {
            counts = new Counts();
            var a = EntryCount.Text;
            if (!string.IsNullOrWhiteSpace(a) && a.Length < 6)
            { 
                counts.Name = NamePicker.SelectedItem.ToString();
                counts.Date = DatePicker.Date.ToString();
                counts.TaskName = TaskPicker.SelectedItem.ToString();
                counts.Count= int.Parse(a);

                conn.Insert(counts);
                EntryCount.Text = "";
                DisplayAlert("Success", "Data submitted successfully!", "OK");

            }
            else
            {
                DisplayAlert("Alert", "Please insert Count less than 6 digit", "OK");
            }
        }

        //async void Report_Clicked(object sender, EventArgs e)
        //{
        //    await Navigation.PushAsync(new Report());
        //}
    }
}