using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace exsss
{
    [Activity(Label = "Activity1")]
    public class Activity1 : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            //create database if it doesn't exist
            DBRepository dbr = new DBRepository();
            dbr.CreateDatabase();

            //create table (if it doesn't exist)
            dbr.CreateTable();
            SetContentView(Resource.Layout.layout1);
            var items = dbr.GetData();
            var listView = FindViewById<ListView>(Resource.Id.listView1);

            listView.Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, items);

            // Create your application here
        }
    }
}