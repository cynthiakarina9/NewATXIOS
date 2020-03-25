
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
        RestServicePromo _restService;
        public Promotions()
        {
            Title = "Promociones";
            InitializeComponent();
            _restService = new RestServicePromo();
        }

        async void Chat_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new WebPage()));
        }

        protected override async void OnAppearing()
        {
            string url = "http://atxcrmws.azurewebsites.net/adx_ads.asmx";
            List<ValueN> weatherData = await _restService.GetWeatherData2Async();
            BindingContext = weatherData;
            OnAppearing();
        }
    }
}