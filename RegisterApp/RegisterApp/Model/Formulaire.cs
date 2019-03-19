using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace RegisterApp.Model
{
    class Formulaire : Grid
    {
        public Formulaire(List<Section> sections)
        {
            foreach (Section section in sections)
            {
                foreach (Element element in section.Elements)
                {
                    RowDefinitions.Add(new RowDefinition());
                    switch (element.Type)
                    {
                        case "image":
                            Image image = new Image();
                            image.Source = element.Values[0];
                            Children.Add(image);
                            break;
                        case "edit":
                            Entry entry = new Entry();
                            entry.Placeholder = element.Values[0];
                            Children.Add(entry);
                            break;
                        case "label":
                            Label label = new Label();
                            label.Text = element.Values[0];
                            Children.Add(label);
                            break;
                        case "radioGroup":
                            Picker picker = new Picker();
                            picker.ItemsSource = element.Values;
                            Children.Add(picker);
                            break;
                        case "switch":
                            Xamarin.Forms.Switch sw = new Xamarin.Forms.Switch();
                            Children.Add(sw);
                            break;
                        case "button":
                            Xamarin.Forms.Button button = new Xamarin.Forms.Button();
                            button.Text = element.Values[0];
                            Children.Add(button);
                            break;
                    }
                }
            }
        }
    }
}
