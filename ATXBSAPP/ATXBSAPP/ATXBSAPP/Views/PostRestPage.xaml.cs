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
        /*private const string url = "https://jsonplaceholder.typicode.com/posts";
        private HttpClient _Client = new HttpClient();
        private ObservableCollection<Post>_post;*/
        public ICommand TapCommand => new Command<string>(async (url) => await Launcher.OpenAsync(url));
        RestService _restService; 
        public PostRestPage()
        {
            Title = "Noticias";
            InitializeComponent();
            BindingContext = this;
            _restService = new RestService();
        }

        protected override async void OnAppearing()
        {
            string url = "http://atxcrmws.azurewebsites.net/adx_ads.asmx";
            List<ValueN> weatherData = await _restService.GetWeatherDataAsync();
            BindingContext = weatherData;
            OnAppearing();
        }
        async void Chat_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new WebPage()));
        }
    }
}
