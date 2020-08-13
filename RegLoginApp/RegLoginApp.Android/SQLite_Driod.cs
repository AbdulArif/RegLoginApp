using System.IO;
using RegLoginApp.Droid;
using SQLite;

//[assembly:Dependency(typeof(SQLite_Driod))]
[assembly: Xamarin.Forms.Dependency(typeof(SQLite_Driod))]
namespace RegLoginApp.Droid
{
    public class SQLite_Driod : ISQLite
    {
        public SQLiteConnection GetSQLiteConnection()
        {
            var dbName = "UserDb.sqlite";
            var dbPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);

            var path = Path.Combine(dbPath,dbName);
            var conn = new SQLiteConnection(path);
            return conn;
                
         }
    }
}