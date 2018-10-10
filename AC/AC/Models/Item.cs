﻿using System;
using Xamarin.Forms;

namespace AC.Models
{
    public enum WordType { verb, noun, adjective }
    public class Item
    {
        public WordType WordType { get; set; }
        public string Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public Image Image { get; set; }
    }
}