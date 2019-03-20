using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;

namespace RegisterApp.Model
{
    public class Service
    {
        private string title;
        private string logo;
        private ObservableCollection<Section> sections;

        public Service(string title)
        {
            this.title = title;
            this.Sections = new ObservableCollection<Section>();
        }

        public List<Service> ToList()
        {
            List<Service> services = new List<Service>();
            services.Add(this);
            return services;
        }
        public string Title { get => title; set => title = value; }
        public ObservableCollection<Section> Sections { get => sections; set => sections = value; }
        public string Logo { get => logo; set => logo = value; }
    }
}
