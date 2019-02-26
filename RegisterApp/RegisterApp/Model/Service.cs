using System;
using System.Collections.Generic;
using System.Text;

namespace RegisterApp.Model
{
    public class Service
    {
        private string title;
        private string image;

        public Service(string title, string image)
        {
            this.title = title;
            this.Image = image;
        }

        public string Title { get => title; set => title = value; }
        public string Image { get => image; set => image = value; }
    }
}
