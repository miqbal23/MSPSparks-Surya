using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteSample.Models
{
    class MSPCrew
    {
        [PrimaryKey][AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Campus { get; set; }
    }
}
