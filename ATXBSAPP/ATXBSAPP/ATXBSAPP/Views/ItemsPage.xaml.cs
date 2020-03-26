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
        public List<ValueN> weatherData_conten = new List<ValueN>();


        public ICommand TapCommand => new Command<string>(async (url) => await Launcher.OpenAsync(url));
        RestServicePromo _restService2;
        RestService _restService;
        public ItemsPage()
        {
            InitializeComponent();
            Title = "Inicio";
            BindingContext = this;
            _restService2 = new RestServicePromo();
            _restService = new RestService();
        }

        protected override async void OnAppearing()
        {
            if (weatherData.Count == 0)
            {
                weatherData = await _restService.GetWeatherDataAsync();
                weatherData2 = await _restService2.GetWeatherData2Async();
                /*
                //noticias
                weatherData_conten[0].adx_name = weatherData[0].adx_name;
                weatherData_conten[0].new_descripcion = weatherData[0].new_descripcion;
                weatherData_conten[0].adx_releasedate = weatherData[0].adx_releasedate;
                weatherData_conten[0].new_urlimagen = weatherData[0].new_urlimagen;
                weatherData_conten[0].new_linkpost = weatherData[0].new_linkpost;
                weatherData_conten[0].createdby = weatherData[0].createdby;
                //promocio
                weatherData_conten[0].atx_name = weatherData2[0].atx_name;
                weatherData_conten[0].atx_descripcion = weatherData2[0].atx_descripcion;
                weatherData_conten[0].atx_validadesde = weatherData2[0].atx_validadesde;
                weatherData_conten[0].atx_validahasta = weatherData2[0].atx_validahasta;*/

                
                
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

    }
}