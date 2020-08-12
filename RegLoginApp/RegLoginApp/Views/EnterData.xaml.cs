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

        public object dataList { get; private set; }

        public EnterData()
        {
            InitializeComponent();
            conn = DependencyService.Get<ISQLite>().GetSQLiteConnection();
            conn.CreateTable<Counts>();
            conn.CreateTable<RegUserTable>();

            //NamePicker.Items.Add("Arif");
            //NamePicker.Items.Add("Sofik");
            //NamePicker.Items.Add("Akkram");

            var data1 = (from regU in conn.Table<RegUserTable>() select regU.UserName).ToList();
            TaskPicker.ItemsSource = data1;

            //TaskPicker.Items.Add("T1");
            //TaskPicker.Items.Add("T2");
            //TaskPicker.Items.Add("T3");
            var data2 = (from tsk in conn.Table<MyTask>() select tsk.MyTaskName).ToList();
            TaskPicker.ItemsSource = data2;

        }

        private void Save_Clicked(object sender, EventArgs e)
        {
            counts = new Counts();
            counts.Name = NamePicker.SelectedItem.ToString();
            counts.Date = DatePicker.Date.ToString();
            counts.TaskName = TaskPicker.SelectedItem.ToString();
            counts.Count= int.Parse(EntryCount.Text);
           // EntryCount.text = "";

        }

        private void Cancel_Clicked(object sender, EventArgs e)
        {
            //var data = (from cnt in conn.Table<Counts>() select cnt);
            //dataList.ItemsSource = data;
        }
    }
}