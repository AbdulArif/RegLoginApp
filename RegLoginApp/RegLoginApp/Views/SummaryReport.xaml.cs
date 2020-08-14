using RegLoginApp.Tables;
using SQLite;
using System.Linq;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RegLoginApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SummaryReport : ContentPage
    {
        private SQLiteConnection conn;
        //Student student;
        Counts counts;
        public SummaryReport()
        {
            InitializeComponent();

            conn = DependencyService.Get<ISQLite>().GetSQLiteConnection();
            //conn.CreateTable<Student>();
            //var data = (from stu in conn.Table<Student>() select stu);

            //conn.CreateTable<Counts>();
            var data = (from cou in conn.Table<Counts>() select cou);
            dataList.ItemsSource = data;
        }
    }
}