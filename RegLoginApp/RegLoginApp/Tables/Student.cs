using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegLoginApp.Tables
{
   public class Student
    {
        [PrimaryKey,AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

    }
}
