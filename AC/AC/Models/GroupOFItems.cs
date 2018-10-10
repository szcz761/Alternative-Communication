﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AC.Models
{
    public class GroupOfItems
    {
        public List<Item> Items { get; set;}
        public string Title { get; set; }
        public GroupOfItems(List<Item> items)
        {
            Items = new List<Item>(items);
        }

    }
}
