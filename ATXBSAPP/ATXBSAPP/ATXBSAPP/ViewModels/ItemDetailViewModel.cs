using System;

using ATXBSAPP.Models;
using Xamarin.Forms;

namespace ATXBSAPP.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Item Item { get; set; }
        public ItemDetailViewModel(Item item = null)
        {
            Title = item?.Text;
            Item = item;
            //OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://atx.mx/acerca/"));
        }
    }
}
