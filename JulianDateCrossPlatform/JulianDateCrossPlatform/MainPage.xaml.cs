namespace JulianDateCrossPlatform
{
    using System;

    using Xamarin.Forms;

    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            //var embeddedJuliusImage = new Image
            //{
            //    Source = ImageSource.FromResource(
            //        "JulianDateCrossPlatform.julius.jpg",
            //        typeof(MainPage).GetTypeInfo()
            //            .Assembly)
            //};

            //this.BackgroundImage = 

            this.BindingContext = this;

            InitializeComponent();

            this.Year = DateTime.Today.Year;
            this.DateSlider.Value = DateTime.Today.DayOfYear;
            this.DateSlider.Minimum = 1;
            this.DateSlider.Maximum = (new DateTime(this.Year, 12, 31)).DayOfYear;
        }

        public int Year { get; set; }

        protected override void OnAppearing()
        {
            this.SetLabels(DateTime.Now);

            base.OnAppearing();
        }

        private void DateSlider_OnValueChanged(object sender, ValueChangedEventArgs e)
        {
            int julianDate = Convert.ToInt32(e.NewValue);
            int year = DateTime.Today.Year;
            var date = new DateTime(year, 1, 1).AddDays(julianDate - 1);
            this.SetLabels(date);
        }

        private void SetLabels(DateTime date)
        {
            this.GregorianDateLabel.Text = date.ToShortDateString();
            this.JulianDateLabel.Text = date.DayOfYear.ToString();
        }
    }
}