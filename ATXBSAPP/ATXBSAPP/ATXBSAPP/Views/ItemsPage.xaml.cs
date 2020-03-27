using System;
using System.ComponentModel;
using Xamarin.Forms;
using ATXBSAPP.ViewModels;
using Xamarin.Essentials;
using System.Windows.Input;
using ATXAPP;
using System.Collections.Generic;
using static ATXBSAPP.ViewModels.NewsViewModel;

namespace ATXBSAPP.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemsPage : ContentPage
    {
        public List<ValueN> weatherData = new List<ValueN>();
        public List<ValueN> weatherData2 = new List<ValueN>();

        RestService _restService;
        public ItemsPage()
        {
            InitializeComponent();
            Title = "Inicio";
            _restService = new RestService();
        }

        protected override async void OnAppearing()
        {
            if (weatherData.Count == 0)
            {
                weatherData = await _restService.GetWeatherDataAsync();
                BindingContext = weatherData;
                OnAppearing();
            }
        }

        async void Chat_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new WebPage()));
        }
        async void Webinar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new Webinar()));
        }
        async void support_Clicked(object sender, EventArgs e)
        {
            await Browser.OpenAsync("https://soporte.atx.com.mx");
        }
        async void Link1_Clicked(object sender, EventArgs e)
        {
            weatherData = await _restService.GetWeatherDataAsync();
            string data1 = weatherData[0].new_linkpost;
            await Browser.OpenAsync(data1);
        }

    }
}