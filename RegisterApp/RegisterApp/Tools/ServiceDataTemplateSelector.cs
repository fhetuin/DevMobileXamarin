using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using RegisterApp.Model;
using Element = RegisterApp.Model.Element;

namespace RegisterApp.Tools
{
    public class ServiceDataTemplateSelector : DataTemplateSelector
    {

        public Dictionary<string, DataTemplate> DataTemplates = new Dictionary<string, DataTemplate>();

        public ServiceDataTemplateSelector(List<Service> services)
        {
            foreach(Service service in services)
            {
                var serviceDataTemplate = new DataTemplate(() =>
                {
                    var stackLayout = new StackLayout();

                    foreach (Section section in service.Sections)
                    {
                        var stackLayoutSection = new StackLayout();
                        var border = new BoxView() { BackgroundColor = Color.Green, HeightRequest = 5, VerticalOptions = LayoutOptions.End, HorizontalOptions = LayoutOptions.FillAndExpand };
                        var border2 = new BoxView() { BackgroundColor = Color.Green, HeightRequest = 1, VerticalOptions = LayoutOptions.Start, HorizontalOptions = LayoutOptions.FillAndExpand };
                        stackLayoutSection.Children.Add(border);
                        stackLayoutSection.Children.Add(border2);
                        foreach (Element element in section.Elements)
                        {
                            switch (element.Type)
                            {
                                case "image":
                                    Image image = new Image();
                                    image.Source = element.Values[0];
                                    stackLayoutSection.Children.Add(image);
                                    break;
                                case "edit":
                                    Entry entry = new Entry();
                                    entry.Placeholder = element.Values[0];
                                    stackLayoutSection.Children.Add(entry);
                                    break;
                                case "label":
                                    Label label = new Label();
                                    label.Text = element.Values[0];
                                    stackLayoutSection.Children.Add(label);
                                    break;
                                case "radioGroup":
                                    Picker picker = new Picker();
                                    picker.ItemsSource = element.Values;
                                    stackLayoutSection.Children.Add(picker);
                                    break;
                                case "switch":
                                    Xamarin.Forms.Switch sw = new Xamarin.Forms.Switch();
                                    stackLayoutSection.Children.Add(sw);
                                    break;
                                case "button":
                                    Xamarin.Forms.Button button = new Xamarin.Forms.Button();
                                    button.Text = element.Values[0];
                                    stackLayoutSection.Children.Add(button);
                                    break;
                            }
                          
                        }

                        stackLayout.Children.Add(stackLayoutSection);

                    }
                    return new ViewCell { View = stackLayout, Height = 400 };
                });

                DataTemplates.Add(service.Title, serviceDataTemplate);
            }

        }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            if (item is Service)
            {
                return DataTemplates[((Service)item).Title];
            }

            return null;
        }
    }
}
