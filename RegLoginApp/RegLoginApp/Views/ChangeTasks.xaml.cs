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
    public partial class ChangeTasks : ContentPage
    {
        private SQLiteConnection conn;
        public ChangeTasks()
        {
            InitializeComponent();
            conn = DependencyService.Get<ISQLite>().GetSQLiteConnection();
            conn.CreateTable<MyTask>();

            var data = (from tsk in conn.Table<MyTask>() select tsk);
            taskList.ItemsSource = data;

            address.Detail = "123 Abc Street";
            testPlaceholder.Placeholder = "(Shopping)"; //placeholder text
            testPlaceholder.Text = "(Text Shopping)"; //real text

        }
        async void GoBack(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ChangeData());
        }
        async void UpdateDB_1(object sender, EventArgs e)
        {
            await DisplayAlert("Message", "Updating database...", "Ok");
            await Navigation.PushAsync(new ChangeData());
        }
        async void UpdateDB_2(object sender, EventArgs e)
        {
            var res = await DisplayAlert("Message", "Updating database...", "Ok", "Cancel");
            if (res)
            {
                await DisplayAlert("Message", "You pressed OK.", "Ok");
            }
            else
            {
                await DisplayAlert("Message", "You pressed Cancel.", "Ok");
            }


        }

        async void OnTapDoThis(object sender, EventArgs e)
        {
            TextCell lblClicked = (TextCell)sender;
            string txt = lblClicked.Text;

            var updateTask = new UpdateTask(txt);
            //updateTask.BindingContext =txt.ToString();

            await Navigation.PushAsync(updateTask);

            //await DisplayAlert("Message", "You tapped me!", "Ok");
            //await Navigation.PushAsync(new UpdateTask());
        }
    }
}