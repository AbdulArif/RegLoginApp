using RegLoginApp.Tables;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RegLoginApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UpdateCounts : ContentPage
    {
        private SQLiteConnection conn;
        public Counts counts;
        private int cntId;
        private int myCount;
        public UpdateCounts(int id)
        {
            conn = DependencyService.Get<ISQLite>().GetSQLiteConnection();
            InitializeComponent();
            counts = new Counts();
            //var allData = (from cnt in conn.Table<Counts>() select cnt);
            //var fltList = from ag in allData where ag.ID.Equals(cntId) select ag;

            var countById = conn.Table<Counts>().Where(x => x.ID == id).Single();
            cntId = id;

            Id.Text = id.ToString();
            Name.Text = countById.Name;

            DatePicker.Date = DateTime.Parse(countById.Date);

            var taskName = (from tsk in conn.Table<MyTask>() select tsk.MyTaskName).ToList();
            TaskName.ItemsSource = taskName;

            TaskName.SelectedItem = countById.TaskName;

            Count.Text = countById.Count.ToString();

        }

        async void Update_Counts(object sender, EventArgs e)
        {
            var countById = conn.Table<Counts>().Where(c => c.ID == cntId);
            foreach (var co in countById)
            {
                co.Date = DatePicker.Date.ToString(); //"8/18/2020 12:00:00 AM"; 
                co.TaskName = TaskName.SelectedItem.ToString();
                co.Count = myCount;
                conn.Update(co); //update the record
            }
            await DisplayAlert("Message", "Updated successfully.", "Ok");
            await Navigation.PushAsync(new ChangeCounts());
        }
        async void Delete_Counts(object sender, EventArgs e)
        {
            var countById = conn.Table<Counts>().Where(c => c.ID == cntId);
            foreach (var co in countById)
            {
                var res = await DisplayAlert("Alert", "Sure you want to delete record Id " + co.ID + "?", "Ok", "Cancel");
                if (res)
                {
                    conn.Delete(co); //Delete the record
                    await DisplayAlert("Message", "Deleted successfully.", "Ok");
                    await Navigation.PushAsync(new ChangeCounts());
                }

            }


        }

        async void Count_Completed(object sender, EventArgs e)
        {
            EntryCell entryCellVal = (EntryCell)sender;
            myCount = Convert.ToInt32(entryCellVal.Text);
        }

    }
}