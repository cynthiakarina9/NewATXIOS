using System;
using System.Windows.Input;
using ATXBSAPP.Models;
using Xamarin.Essentials;
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
        }
    }
}
