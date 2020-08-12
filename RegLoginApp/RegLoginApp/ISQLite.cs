using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegLoginApp
{
   public interface ISQLite
    {
        SQLiteConnection GetSQLiteConnection();

    }
}
