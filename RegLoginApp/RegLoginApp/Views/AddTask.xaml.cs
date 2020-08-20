using RegLoginApp.Tables;
using SQLite;
using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RegLoginApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddTask : ContentPage
    {
        private SQLiteConnection conn;
        MyTask myTask;
        public AddTask()
        {
            InitializeComponent();
            conn = DependencyService.Get<ISQLite>().GetSQLiteConnection();
            conn.CreateTable<MyTask>();
        }

        private void SaveButton_Clicked(object sender, EventArgs e)
        {
            myTask = new MyTask();
            var a= Name.Text;
            if (!string.IsNullOrWhiteSpace(Name.Text) && a.Length < 6)
            {
              
                myTask.MyTaskName = Name.Text;
                conn.Insert(myTask);
                Name.Text = "";

                var msg = "Successfully " + a + " saved.";
                DisplayAlert("Success", msg, "OK");
            }
            else
            {
                //SaveButton.IsEnabled = false;
                DisplayAlert("Alert", "Please add task name less than 6 characters", "OK");
            }
            
        }

        private void ShowButton_Clicked(object sender, EventArgs e)
        {

            var data = (from tsk in conn.Table<MyTask>() select tsk);
            dataList.ItemsSource = data;

        }

        //async void NextPage_Clicked(object sender, EventArgs e)
        //{
        //    await Navigation.PushAsync(new EnterData());
        //    //setButtonVisibility();
        //}
        // disable Button
        //private void setButtonVisibility()
        //{
        //    if ((Name.Text != String.Empty))
        //    {
        //        SaveButton.IsEnabled = true;
                
        //    }
        //    else
        //    {
        //        SaveButton.IsEnabled = false;
               
        //    }
        //}

    }
}