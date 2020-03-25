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
        public List<ValueN> weatherData3 = new List<ValueN>();
        ItemsViewModel viewModel;

        public ICommand TapCommand => new Command<string>(async (url) => await Launcher.OpenAsync(url));
        RestServicePromo _restService2;
        RestService _restService;
        public ItemsPage()
        {
            InitializeComponent();

            //BindingContext = viewModel = new ItemsViewModel();
            BindingContext = this;
            _restService2 = new RestServicePromo();
            _restService = new RestService();
        }

        protected override async void OnAppearing()
        {
            if (weatherData.Count == 0)
            {
                weatherData = await _restService.GetWeatherDataAsync();
                BindingContext = weatherData;
                weatherData2 = await _restService2.GetWeatherData2Async();
                BindingContext = weatherData2;
                OnAppearing();
            }
            
        }



        async void Chat_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new WebPage()));
        }

        async void Webinars_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new Webinar()));
        }
        async void support_Clicked(object sender, EventArgs e)
        {
            await Browser.OpenAsync("https://soporte.atx.com.mx");
        }



        /* protected override void OnAppearing()
         {
             base.OnAppearing();

             if (viewModel.Items.Count == 0)
                 viewModel.LoadItemsCommand.Execute(null);
         }*/
    }
}