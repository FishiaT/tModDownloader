using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tModDownloader
{
    public class ModItem
    {
        public string ID { get; set; }
        public string SteamURL { get; set; }
        public Image Icon { get; set; }
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public string AuthorURL { get; set; }

        public ModItem(string id, Image icon, string title, string description)
        {
            ID = id;
            Icon = icon;
            Title = title;
        }
    }
}
