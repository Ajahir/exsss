using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace exsss
{
    class DBRepository
    {
        public void CreateDatabase()
        {
            string dbPath = Path.Combine(System.Environment.GetFolderPath
                (System.Environment.SpecialFolder.Personal), "database.db3");
            var db = new SQLiteConnection(dbPath);
        }

        public void CreateTable()
        {
            string dbPath = Path.Combine(System.Environment.GetFolderPath
               (System.Environment.SpecialFolder.Personal), "database.db3");
            var db = new SQLiteConnection(dbPath);
            db.CreateTable<ToDoTasks>();
        }

        public string InsertRecord(string task)
        {
            string dbPath = Path.Combine(System.Environment.GetFolderPath
               (System.Environment.SpecialFolder.Personal), "database.db3");
            var db = new SQLiteConnection(dbPath);
            ToDoTasks item = new ToDoTasks();
            item.Task = task;
            db.Insert(item);
            return task;
        }
        public List<string> GetData()
        {
            string dbPath = Path.Combine(System.Environment.GetFolderPath
               (System.Environment.SpecialFolder.Personal), "database.db3");
            var db = new SQLiteConnection(dbPath);
            List<string> data = new List<string>();
            foreach (var item in db.Table<ToDoTasks>())
            {
                var zad = item.Task.ToString();

                data.Add(zad);
            }
            return data;

        }
    }
}