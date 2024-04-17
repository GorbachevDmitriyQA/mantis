using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using LinqToDB;
using LinqToDB.Configuration;

namespace MantisTests
{
    public class MantisDB : LinqToDB.Data.DataConnection
    {
        public MantisDB() : base("MySql.Data.MySqlClient",
    "Server=127.0.0.1;Port=3306;Database=bugtracker;Uid=root;Pwd=;charset=utf8;Allow Zero Datetime=true")
        { }

        public ITable<ProjectData> Project { get { return GetTable<ProjectData>(); } } 
    }
}
