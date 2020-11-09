using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace JulianDate
{
    [Activity(Label = "Julian Date", MainLauncher = true, Icon = "@drawable/JuliusCaesarIcon")]
    public class MainActivity : Activity
    {
        private TextView textViewForJulianDate;
        private TextView textViewForGregorianDate;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            var buttonForDatePickerDialog = FindViewById<Button>(Resource.Id.buttonForDatePickerDialog);
            buttonForDatePickerDialog.Click += ButtonForDatePickerDialog_Click;
            this.textViewForJulianDate = FindViewById<TextView>(Resource.Id.textViewForJulianDate);
            this.textViewForJulianDate.Text = DateTime.Today.DayOfYear.ToString();
            this.textViewForGregorianDate = FindViewById<TextView>(Resource.Id.textViewForGregorianDate);
            this.textViewForGregorianDate.Text = DateTime.Today.ToLongDateString();
        }

        private void ButtonForDatePickerDialog_Click(object sender, EventArgs e)
        {
            DatePickerFragment frag = DatePickerFragment.NewInstance(delegate (DateTime time)
            {
                this.textViewForGregorianDate.Text = time.ToLongDateString();
                this.textViewForJulianDate.Text = time.DayOfYear.ToString();
            });

            frag.Show(FragmentManager, DatePickerFragment.TAG);
        }


        public override void OnConfigurationChanged(Android.Content.Res.Configuration newConfig)
        {
            base.OnConfigurationChanged(newConfig);

            LinearLayout linearLayout = FindViewById<LinearLayout>(Resource.Id.linearLayout);
            if (newConfig.Orientation == Android.Content.Res.Orientation.Portrait)
            {
                linearLayout.Orientation = Orientation.Vertical;
            }
            else if (newConfig.Orientation == Android.Content.Res.Orientation.Landscape)
            {
                linearLayout.Orientation = Orientation.Horizontal;
            }
        }
        
    }
}

