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
        public UpdateTask()
        {
            InitializeComponent();
            conn = DependencyService.Get<ISQLite>().GetSQLiteConnection();
            //conn.CreateTable<MyTask>();
            //var data = (from tsk in conn.Table<MyTask>() select tsk);
            //TaskName.Text = "T5";

        }

        async void Update_TaskName(object sender, EventArgs e)
        {
           
            var myTsks = conn.Table<MyTask>().Where(x=>x.MyTaskName=="T5");
            foreach (var ta in myTsks)
            {
                ta.MyTaskName += "Task";
                conn.Update(ta);
            }
            
            await DisplayAlert("Message", "Your task name is successfully updated", "Ok");
        }

        async void Delete_TaskName(object sender, EventArgs e)
        {
            var obj = conn.Table<MyTask>().Where(x=>x.MyTaskName == "T5arif");
            foreach (var ta in obj)
            {
                var res = await DisplayAlert("Alert", "Are you sure you want to delete?", "Yes", "Cancel");
                if (res) {
                    conn.Delete(ta);
                    await DisplayAlert("Message", "Your task deleted successfully.", "Ok");
                }
                
            }
                

        }
    }
}