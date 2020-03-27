using ATXAPP;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static ATXBSAPP.ViewModels.NewsViewModel;

namespace ATXBSAPP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PostRestPage : ContentPage
    {
        public List<ValueN> weatherData = new List<ValueN>();
        /*private const string url = "https://jsonplaceholder.typicode.com/posts";
        private HttpClient _Client = new HttpClient();
        private ObservableCollection<Post>_post;*/
       
        RestService _restService; 
        //public ICommand TapCommand = new Command<string>(async (url) => await Launcher.OpenAsync(url));
        public PostRestPage()
        {
            Title = "Noticias";
            InitializeComponent();
            _restService = new RestService();
        }

        protected override async void OnAppearing()
        {
            string url = "http://atxcrmws.azurewebsites.net/adx_ads.asmx";           

            if (weatherData.Count < 1)
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
        async void Link0_Clicked(object sender, EventArgs e)
        {
            await Browser.OpenAsync("https://atx.mx/news/");
        }
        async void Link1_Clicked(object sender, EventArgs e)
        {
            weatherData = await _restService.GetWeatherDataAsync();
            string data = weatherData[0].new_linkpost;
            await Browser.OpenAsync(data);
        }

        async void Link2_Clicked(object sender, EventArgs e)
        {
            weatherData = await _restService.GetWeatherDataAsync();
            string data = weatherData[1].new_linkpost;
            await Browser.OpenAsync(data);
        }

        async void Link3_Clicked(object sender, EventArgs e)
        {
            weatherData = await _restService.GetWeatherDataAsync();
            string data = weatherData[2].new_linkpost;
            await Browser.OpenAsync(data);
        }

        async void Link4_Clicked(object sender, EventArgs e)
        {
            weatherData = await _restService.GetWeatherDataAsync();
            string data = weatherData[3].new_linkpost;
            await Browser.OpenAsync(data);
        }
    }
}
