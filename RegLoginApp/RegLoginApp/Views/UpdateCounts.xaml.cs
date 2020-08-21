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
        public UpdateCounts(int id)
        {
            conn = DependencyService.Get<ISQLite>().GetSQLiteConnection();
            InitializeComponent();
            cntId = id;
            Id.Text = cntId.ToString();
        }

        async void Update_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Message", "your data is successfully saved." , "Ok");
        }
    }
}