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
    public partial class ChangeData : ContentPage
    {
        private SQLiteConnection conn;
        Counts counts;

        public ChangeData()
        {
            InitializeComponent();
        }

        async void ChangeCount_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ChangeCounts());
        }

        async void ChangeTask_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ChangeTasks());
        }
    }
}