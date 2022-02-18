using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;

namespace exsss
{
    [Activity(Label = "DATABASE", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.AddTask);

            //define buttons
            Button save, view;

            save = FindViewById<Button>(Resource.Id.button1);
            view = FindViewById<Button>(Resource.Id.button2);

            save.Click += save_click;
            view.Click += cancel_click;

            DBRepository dbr = new DBRepository();
            dbr.CreateDatabase();

            //create table (if it doesn't exist)
            dbr.CreateTable();

            var items = dbr.GetData();
            var listView = FindViewById<ListView>(Resource.Id.listView4);

            listView.Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, items);
            listView.ItemClick += ListView_ItemClick;
           // listView.Click += ListView_Click;


        }

        private void ListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            StartActivity(typeof(Activity2));
        }



        private void save_click(object sender, EventArgs e)
        {
            DBRepository dbr = new DBRepository();
            EditText name = FindViewById<EditText>(Resource.Id.editText1);

            //enter user's input(task name) to table

            var result = dbr.InsertRecord(name.Text);

            Toast.MakeText(this, "added", ToastLength.Short).Show();
        }

        private void cancel_click(object sender, EventArgs e)
        {
            StartActivity(typeof(Activity1));
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}