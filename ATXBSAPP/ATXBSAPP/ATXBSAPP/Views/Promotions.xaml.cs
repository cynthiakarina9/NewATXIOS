
using ATXBSAPP.ViewModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ATXBSAPP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Promotions : ContentPage
    {
        static string serviceUri = "https://atx.crm.dynamics.com/";
        public string redirectUrl = "https://atx.api.crm.dynamics.com/api/data/v9.1/";
        List<NewsViewModel> PromoItems;
        public ICommand TapCommand => new Command<string>(async (url) => await Launcher.OpenAsync(url));
        /*private const string url = "https://jsonplaceholder.typicode.com/posts";
       private HttpClient _Client = new HttpClient();
       private ObservableCollection<Post>_post;*/
        public Promotions()
        {
            Title = "Promociones";
            InitializeComponent();
            //RetrieveAccounts();
            BindingContext = this;
        }

        async void Chat_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new WebPage()));
        }

        /*protected override async void OnAppearing()

       {
           var content = await _Client.GetStringAsync(url);
           var post = JsonConvert.DeserializeObject<List<Post>>(content);
           _post = new ObservableCollection<Post>(post);
           Post_List.ItemsSource = _post;
           base.OnAppearing();
       }*/

       public void RetrieveAccounts()
        {
            string token = "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6IllNRUxIVDBndmIwbXhvU0RvWWZvbWpxZmpZVSIsImtpZCI6IllNRUxIVDBndmIwbXhvU0RvWWZvbWpxZmpZVSJ9.eyJhdWQiOiJodHRwczovL2F0eC5jcm0uZHluYW1pY3MuY29tLyIsImlzcyI6Imh0dHBzOi8vc3RzLndpbmRvd3MubmV0LzNhNWVmMmIxLTg2YzYtNDFiYy1hMzBjLTk0NzA5YThkMDU5MC8iLCJpYXQiOjE1ODQwNDg3ODIsIm5iZiI6MTU4NDA0ODc4MiwiZXhwIjoxNTg0MDUyNjgyLCJhY3IiOiIxIiwiYWlvIjoiNDJOZ1lJaitzWlJCNVlxYjU1YTVTb3JxUy9aK1dNZWo1bjg4UGpyaVFzWjc5VWRCRDBJQiIsImFtciI6WyJwd2QiXSwiYXBwaWQiOiI2N2ZmNjU5Yy1kZmZlLTQzNjgtYWJmOC01NDlmZDRkNDY2ODMiLCJhcHBpZGFjciI6IjAiLCJmYW1pbHlfbmFtZSI6IkludGVncmFjaW9uIiwiZ2l2ZW5fbmFtZSI6IlVzdWFyaW8gZGUiLCJpcGFkZHIiOiIxODcuMTU3LjE2Ni44NCIsIm5hbWUiOiJVc3VhcmlvIGRlICBJbnRlZ3JhY2lvbiIsIm9pZCI6IjBmNGVlODRhLWMxMDEtNGJiMi1hOTgxLTA0ZmU0ZGVmMTk0ZCIsInB1aWQiOiIxMDAzMjAwMDhGNDU5RUM4Iiwic2NwIjoidXNlcl9pbXBlcnNvbmF0aW9uIiwic3ViIjoiay1MUHZ5eFRJcGdsemRRX3FfYlRSbXB0LURRUTdBVzJXZVhRalVxZjdxTSIsInRpZCI6IjNhNWVmMmIxLTg2YzYtNDFiYy1hMzBjLTk0NzA5YThkMDU5MCIsInVuaXF1ZV9uYW1lIjoidWRlaUBhdHgubXgiLCJ1cG4iOiJ1ZGVpQGF0eC5teCIsInV0aSI6Ijc4MHllTHMzalVxNHBkcURPQ3BNQUEiLCJ2ZXIiOiIxLjAifQ.LdwMaXiHIZDHBoD7elja2_V_NI8Parer7ZONX-PbeT6DnNqzVvfn0w4fEmI99hOp7FMe1w1N_yR07wv_p0GMXGYJ4EmcjcMXq58bjrJquZcBwTQtwqfn3xmG8-zz9Xxm7ZUbbOX-laap5K7wQeswZDmyIIREWw6Vr0KAwCJuinC63RM5gza_4pUu9hVATMAR5nn5FoUOqd3y59puLTVhIl9by_ti2xdujOScXxfpuC4ddNYzqOF_qEh1uzJ_g-DzCtxEbsmDijLMb6FLrVTmugaW1tW9_UZk3Ih173urABAwNoRHZMLcIkBnuNurRtXbt1ubNfKMduIvNX8gdBZZiQ";
            HttpClient httpClient = null;
            httpClient = new HttpClient();
            //Default Request Headers needed to be added in the HttpClient Object
            httpClient.DefaultRequestHeaders.Add("OData-MaxVersion", "4.0");
            httpClient.DefaultRequestHeaders.Add("OData-Version", "4.0");
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //Set the Authorization header with the Access Token received specifying the Credentials
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            httpClient.BaseAddress = new Uri(redirectUrl);
            var response = httpClient.GetAsync("adx_ads?$select=adx_name,").Result;
            var accounts="";
            if (response.IsSuccessStatusCode)
            {
                accounts = response.Content.ReadAsStringAsync().Result;
            }
   
        }

    }
}