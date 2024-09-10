using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceJournal.Models
{
    [Table("Category")]
    public class Category
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image_Link { get; set; }
    }
}
