using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AC.Models
{
    public class GroupOfItems
    {
        public List<Item> Items { get; set;}
        public string Title { get; set; }
        public Image Image { get; set; }
        public GroupOfItems(List<Item> items)
        {
            Items = new List<Item>(items);
        }
    }
}
