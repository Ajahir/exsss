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
    [Activity(Label = "Activity2")]
    public class Activity2 : Activity
    {
        private EditText updateData;
        private Button updatebtn;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_main);
            updatebtn = FindViewById<Button>(Resource.Id.update_btn);
            updatebtn.Click += Updatebtn_Click;
            updateData = FindViewById<EditText>(Resource.Id.updateedit);
            
            try
            {
                string dpPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "student.db3"); //Call Database  
                var db = new SQLiteConnection(dpPath);
                var data = db.Table<ToDoTasks>(); //Call Table  
                int idvalue = int.Parse(updateData.Text);
                var data1 = (from values in data
                             where values.Id == idvalue
                             select new ToDoTasks
                             {
                                 Task = values.Task,

                             }).ToList<ToDoTasks>(); 
                if (data1.Count > 0)
                {
                    foreach (var val in data1)
                    {
                        updateData.Text = val.Task;

                    }

                }
                else
                {
                    Toast.MakeText(this, "Data Not Available", ToastLength.Short).Show();
                }
            }
            catch(Exception e) {
                Toast.MakeText( this,"Data Not Available"+e.Message,ToastLength.Short).Show();
            }
            
        }

        private void Updatebtn_Click(object sender, EventArgs e)
        {
            try
            {
                string dpPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "database.db3"); //Call Database  
                var db = new SQLiteConnection(dpPath);
                var data = db.Table<ToDoTasks>();
                int idvalue = Convert.ToInt32(updateData.Text);
                var data1 = (from values in data
                             where values.Id == idvalue
                             select values).Single();
                data1.Task = updateData.Text;
              
                db.Update(data1);
                Toast.MakeText(this, "Updated Successfully", ToastLength.Short).Show();
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, ex.ToString(), ToastLength.Short).Show();
            }
        }
    }
    }
    
