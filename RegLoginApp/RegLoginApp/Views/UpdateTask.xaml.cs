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
    public partial class UpdateTask : ContentPage
    {
        private SQLiteConnection conn;
        public Student stn;
        private string tskName;

        public UpdateTask(string tName)
        {
            InitializeComponent();
            conn = DependencyService.Get<ISQLite>().GetSQLiteConnection();
            //conn.CreateTable<MyTask>();
            //var data = (from tsk in conn.Table<MyTask>() select tsk);

            tskName = tName;
            TaskName.Text = tskName;

        }

        async void Update_TaskName(object sender, EventArgs e)
        {
            //Capture the new task name from the EntryCell
            EntryCell entryCellVal = (EntryCell)sender;
            string txt = entryCellVal.Text;

            var myTsks = conn.Table<MyTask>().Where(x => x.MyTaskName == tskName);
            foreach (var ta in myTsks)
            {
                //ta.MyTaskName += "Task";

                ta.MyTaskName = txt; //set the new task name from EntryCell
                conn.Update(ta); //update the task name
            }

            //Now we should UPDATE the Counts table with the updated Task name
            var myCounts = conn.Table<Counts>().Where(x => x.TaskName == tskName);
            foreach (var ta in myCounts)
            {
                ta.TaskName = txt; //set the new task name from EntryCell
                conn.Update(ta); //update the task name in Counts table
            }

            await DisplayAlert("Message", "Task name successfully updated. All related data also updated.", "Ok");
            await Navigation.PushAsync(new ChangeTasks());
        }

        async void Delete_TaskName(object sender, EventArgs e)
        {
            var obj = conn.Table<MyTask>().Where(x => x.MyTaskName == tskName);

            foreach (var ta in obj)
            {
                var res = await DisplayAlert("Alert", "Sure you want to delete \"" + tskName + "\"?", "Yes", "Cancel");
                if (res)
                {
                    conn.Delete(ta);

                    //Now we should DEELTE  the Counts table 
                    var myCounts = conn.Table<Counts>().Where(x => x.TaskName == tskName);
                    foreach (var mc in myCounts)
                    {
                        conn.Delete(mc); //DELETE the records from Counts table
                    }
                    await DisplayAlert("Message", "Task deleted successfully.", "Ok");
                    await Navigation.PushAsync(new ChangeTasks());
                }

            }


        }
    }
}