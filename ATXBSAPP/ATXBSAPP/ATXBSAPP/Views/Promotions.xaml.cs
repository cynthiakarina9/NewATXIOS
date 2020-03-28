
using ATXAPP;
using ATXBSAPP.ViewModels;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static ATXBSAPP.ViewModels.NewsViewModel;

namespace ATXBSAPP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Promotions : ContentPage
    {
        public List<ValueN> weatherData = new List<ValueN>();
        RestServicePromo _restService;
        public Promotions()
        {
            InitializeComponent();
            _restService = new RestServicePromo();
        }

        async void Chat_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new WebPage()));
        }

        protected override async void OnAppearing()
        {
            if (weatherData.Count < 1)
            {
                weatherData = await _restService.GetWeatherData2Async();
                BindingContext = weatherData;
                OnAppearing();
            }                   
        }
    }
}