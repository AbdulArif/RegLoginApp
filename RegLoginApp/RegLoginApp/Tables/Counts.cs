using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegLoginApp.Tables
{
    public  class Counts
    {

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public string TaskName { get; set; }
        public int Count { get; set; }
    }

}
