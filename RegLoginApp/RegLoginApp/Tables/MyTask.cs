﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegLoginApp.Tables
{
    public class MyTask
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string MyTaskName { get; set; }
    }
}
