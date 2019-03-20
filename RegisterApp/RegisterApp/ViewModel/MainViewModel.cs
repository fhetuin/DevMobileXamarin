using RegisterApp.Tools;
using RegisterApp.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Xamarin.Forms;

namespace RegisterApp.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<Service> services = new ObservableCollection<Service>();
        private ServiceDataTemplateSelector serviceDataTemplateSelector;
        private Service selectedService = null;

        public MainViewModel()
        {
            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(App)).Assembly;
            Stream stream = assembly.GetManifestResourceStream("RegisterApp.service.json");
            string json = string.Empty;
            using (var reader = new System.IO.StreamReader(stream))
            {
                json = reader.ReadToEnd();
            }
            if (json != string.Empty)
            {
                List<Service> serviceList = JsonParse.ParseJson(json);
                services = new ObservableCollection<Service>(serviceList);
                this.serviceDataTemplateSelector = new ServiceDataTemplateSelector(serviceList);
            }
        }

        public ServiceDataTemplateSelector ServiceDataTemplateSelector
        {
            get
            {
                return serviceDataTemplateSelector;
            }

            set
            {
                serviceDataTemplateSelector = value;
                OnPropertyChanged("ServiceDataTemplateSelector");
            
            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public Service SelectedService
        {
            get
            {
                return selectedService;
            }

            set
            {
                selectedService = value;
                OnPropertyChanged("SelectedService");

            }
        }


        public ObservableCollection<Service> Services
        {
            get
            {
                return services;
            }

            set
            {
                services = value;
                OnPropertyChanged("Services");

            }
        }


    }
}
