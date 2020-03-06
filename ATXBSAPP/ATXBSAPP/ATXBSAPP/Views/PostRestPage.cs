using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ATXBSAPP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PostRestPage : ContentPage
    {
        private const string url = "https://jsonplaceholder.typicode.com/posts";
        private HttpClient _Client = new HttpClient();
        private ObservableCollection<Post> _post;

        public PostRestPage()
        {
            Title = "Noticias";
            InitializeComponent();
        }

        protected override async void OnAppearing()

        {
            var content = await _Client.GetStringAsync(url);
            var post = JsonConvert.DeserializeObject<List<Post>>(content);
            _post = new ObservableCollection<Post>(post);
            Post_List.ItemsSource = _post;
            base.OnAppearing();
        }

        async void Chat_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new WebPage()));
        }

        
    }
}