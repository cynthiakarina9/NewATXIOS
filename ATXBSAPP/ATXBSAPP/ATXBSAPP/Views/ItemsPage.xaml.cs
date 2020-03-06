using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using ATXBSAPP.Models;
using ATXBSAPP.Views;
using ATXBSAPP.ViewModels;
using Xamarin.Essentials;

namespace ATXBSAPP.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel viewModel;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ItemsViewModel();
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