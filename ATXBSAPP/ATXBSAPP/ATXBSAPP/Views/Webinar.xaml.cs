using ATXAPP;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static ATXBSAPP.ViewModels.WebinarVewModel;

namespace ATXBSAPP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Webinar : ContentPage
    {
        public List<ValueW> weatherData3 = new List<ValueW>();
        RestServiceWebinar _restService;
        public Webinar()
        {
            InitializeComponent();
            Title = "Webinars";
            _restService = new RestServiceWebinar();
        }

        protected override async void OnAppearing()
        {
            if (weatherData3.Count < 1)
            {
                weatherData3 = await _restService.GetWeatherData3Async();
                BindingContext = weatherData3;
                OnAppearing();
            }
        }
        async void Chat_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new WebPage()));
        }
        async void Link1_Clicked(object sender, EventArgs e)
        {
            await Browser.OpenAsync("https://www.atx.mx/news");
        }
    }
}