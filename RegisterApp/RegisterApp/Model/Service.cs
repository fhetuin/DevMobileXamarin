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
        private Formulaire formulaire;

        public Service(string title)
        {
            this.title = title;
            this.Sections = new ObservableCollection<Section>();
            
        }

        public string Title { get => title; set => title = value; }
        public ObservableCollection<Section> Sections { get => sections; set => sections = value; }
        public string Logo { get => logo; set => logo = value; }
        internal Formulaire Formulaire { get => formulaire; set => formulaire = value; }
    }
}
