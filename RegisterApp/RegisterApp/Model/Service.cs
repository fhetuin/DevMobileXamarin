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
        private Grid formulaire;

        public Service(string title)
        {
            this.title = title;
            this.Sections = new ObservableCollection<Section>();
           

        }


        public void CreateFormulaire()
        {
            Grid grid = new Grid();
            foreach (Section section in sections)
            {
                foreach (Element element in section.Elements)
                {
                    switch (element.Type)
                    {
                        case "image":
                            Image image = new Image();
                            image.Source = element.Values[0];
                            grid.Children.Add(image);
                            break;
                        case "edit":
                            Entry entry = new Entry();
                            entry.Placeholder = element.Values[0];
                            grid.Children.Add(entry);
                            break;
                        case "label":
                            Label label = new Label();
                            label.Text = element.Values[0];
                            grid.Children.Add(label);
                            break;
                        case "radioGroup":
                            Picker picker = new Picker();
                            picker.ItemsSource = element.Values;
                            grid.Children.Add(picker);
                            break;
                        case "switch":
                            Xamarin.Forms.Switch sw = new Xamarin.Forms.Switch();
                            grid.Children.Add(sw);
                            break;
                        case "button":
                            Xamarin.Forms.Button button = new Xamarin.Forms.Button();
                            button.Text = element.Values[0];
                            grid.Children.Add(button);
                            break;
                    }
                }
            }

            formulaire = grid;
        }

        public string Title { get => title; set => title = value; }
        public ObservableCollection<Section> Sections { get => sections; set => sections = value; }
        public string Logo { get => logo; set => logo = value; }
    }
}
