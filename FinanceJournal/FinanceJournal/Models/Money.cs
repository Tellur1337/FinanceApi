using SQLite;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace FinanceJournal.Models
{
    public abstract class Money
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string? Category { get; set; }
        public string Name { get; set; }
        public int? Amount { get; set; }
        //public string Comment { get; set; }
        public DateTime? DateTimeAdding { get; set; }
    }
}
