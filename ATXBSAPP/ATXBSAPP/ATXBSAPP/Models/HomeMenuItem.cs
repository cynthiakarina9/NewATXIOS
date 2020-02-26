using System;
using System.Collections.Generic;
using System.Text;

namespace ATXBSAPP.Models
{
    public enum MenuItemType
    {
        Browse,
        About,
        News
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
