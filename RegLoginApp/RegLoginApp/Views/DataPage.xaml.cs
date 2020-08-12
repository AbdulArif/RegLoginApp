using RegLoginApp.Tables;
using SQLite;
using System;
using System.Linq;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RegLoginApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DataPage : ContentPage
    {
        private SQLiteConnection conn;
        Student student;
        public DataPage()
        {
            InitializeComponent();
            conn = DependencyService.Get<ISQLite>().GetSQLiteConnection();
            conn.CreateTable<Student>();
        }

        private void SaveButton_Clicked(object sender, EventArgs e)
        {
            student = new Student();
            student.Name = Name.Text;
            student.Address = Address.Text;
            conn.Insert(student);
            Name.Text = "";
            Address.Text = "";
        }

        private void ShowButton_Clicked(object sender, EventArgs e)
        {
            var data = (from stu in conn.Table<Student>() select stu);
            dataList.ItemsSource = data;
        }
    }
}