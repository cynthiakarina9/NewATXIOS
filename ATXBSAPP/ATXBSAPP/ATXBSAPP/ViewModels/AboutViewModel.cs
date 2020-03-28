
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ATXBSAPP.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://atx.mx/acerca/"));
        }

        public ICommand OpenWebCommand { get; }
    }
}