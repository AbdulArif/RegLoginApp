using RegLoginApp.Tables;
using SQLite;
using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RegLoginApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        private SQLiteConnection conn;
        MyTask myTask;
        public HomePage()
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
               // SaveButton.IsEnabled = true;
                //setButtonVisibility(); 
                myTask.MyTaskName = Name.Text;
                conn.Insert(myTask);
                Name.Text = "";

                var msg = "Successfully" + a + " save";
                DisplayAlert("Alert", msg, "OK");
            }
            else
            {
                //SaveButton.IsEnabled = false;
                DisplayAlert("Alert", "Please insert task name less than 6 digit", "OK");
            }
            
        }

        private void ShowButton_Clicked(object sender, EventArgs e)
        {

            var data = (from tsk in conn.Table<MyTask>() select tsk.MyTaskName).ToList();
            dataList.ItemsSource = data;
        }

        async void NextPage_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EnterData());
            //setButtonVisibility();
        }
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