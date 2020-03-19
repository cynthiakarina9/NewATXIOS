

namespace ATXBSAPP.Models
{
    public enum MenuItemType
    {
        Browse,
        About,
        News,
        Promotions,
        Store,
        Frecuency,
        Webinar
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
