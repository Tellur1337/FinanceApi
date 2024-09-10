using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Linq;
using FinanceJournal.Models;

namespace FinanceJournal
{
    public class FinanceRepository
    {
        SQLiteConnection database;
        public FinanceRepository(string databasePath)
        {
            database = new SQLiteConnection(databasePath);
            database.CreateTable<Income>();
            database.CreateTable<Encrease>();
            database.CreateTable<Category>();
            //Category category = new Category {Id=0, Name = "All" };
            //if (GetCategories().Any(e => e.Name == "All"))
            //    { }
            //else
            //{
            //    SaveCategory(category);
            //}


        }
        public IEnumerable<Money> GetIncomes()
        {
            var res = database.Table<Income>().ToList<Money>();
            return res.Count != 0 ? res : new List<Money>();
        }
        public Income GetIncome(int id) => database.Get<Income>(id);

        public int DeleteIncome(int id)
        {
            try
            {
                database.Delete<Income>(id);
            }
            catch(Exception ex) { }
            return 0;
        }

        public int SaveIncome(Income item)
        {
            if (item.Id != 0)
            {
                database.Update(item);
                return item.Id;
            }
            else
            {
                return database.Insert(item);
            }
        }


        public IEnumerable<Money> GetEncreases()
        {
            var res = database.Table<Encrease>().ToList<Money>();
            return res.Count != 0 ? res : new List<Money>();
        }
        public Encrease GetEncrease(int id)
        {
            return database.Get<Encrease>(id);
        }
        public int DeleteEncrease(int id)
        {
            try
            {
                database.Delete<Encrease>(id);
            }
            catch (Exception ex) { }
            return 0;
        }
        public int SaveEncrease(Encrease encrease)
        {
            if (encrease.Id != 0)
            {
                database.Update(encrease);
                return encrease.Id;
            }
            else
            {
                return database.Insert(encrease);
            }
        }


        public IEnumerable<Category> GetCategories()
        {
            return database.Table<Category>().ToList();
        }
        public Category GetCategory(int id)
        {
            return database.Get<Category>(id);
        }
        public int DeleteCategory(int id)
        {
            return database.Delete<Category>(id);
        }
        public int SaveCategory(Category category)
        {
            return database.Insert(category);
        }
    }
}
