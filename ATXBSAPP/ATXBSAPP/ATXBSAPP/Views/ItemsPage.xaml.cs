using System;
using System.ComponentModel;
using Xamarin.Forms;
using ATXBSAPP.ViewModels;
using Xamarin.Essentials;
using System.Windows.Input;

namespace ATXBSAPP.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel viewModel;
        public ICommand TapCommand => new Command<string>(async (url) => await Launcher.OpenAsync(url));
        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ItemsViewModel();
            BindingContext = this;
        }

        /*async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Item;
            if (item == null)
                return;

            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));

            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }*/

        async void Chat_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new WebPage()));
        }

        async void support_Clicked(object sender, EventArgs e)
        {
            await Browser.OpenAsync("https://atx.crm.dynamics.com/main.aspx?appid=cfdbc5f7-d0fc-e911-a814-000d3a1b142f&pagetype=dashboard&id=e6941e88-d854-e911-a97e-000d3a19907d&type=system&_canOverride=true");
        }



        /* protected override void OnAppearing()
         {
             base.OnAppearing();

             if (viewModel.Items.Count == 0)
                 viewModel.LoadItemsCommand.Execute(null);
         }*/
    }
}