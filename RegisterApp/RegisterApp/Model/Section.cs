using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace RegisterApp.Model
{
    public class Section
    {
        private string name;
        private ObservableCollection<Element> elements;

        public Section(string name)
        {
            this.Name = name;
            elements = new ObservableCollection<Element>();
        }


        public ObservableCollection<Element> Elements { get => elements; set => elements = value; }
        public string Name { get => name; set => name = value; }
    }
}
