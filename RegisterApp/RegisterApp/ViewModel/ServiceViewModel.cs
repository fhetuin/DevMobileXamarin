using RegisterApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace RegisterApp.ViewModel
{
    public class ServiceViewModel
    {
        private ObservableCollection<Service> services;

        public ServiceViewModel()
        {
            services = new ObservableCollection<Service>();
            services.Add(new Service("Netflix", "https://img3.telestar.fr/var/telestar/storage/images/3/0/5/6/3056045/netflix-annonce-des-projets-france_width1024.png"));
            services.Add(new Service("Spotify", "https://images-eu.ssl-images-amazon.com/images/I/51rttY7a%2B9L.png"));
            services.Add(new Service("Deezer", "https://img3.telestar.fr/var/telestar/storage/images/3/0/5/6/3056045/netflix-annonce-des-projets-france_width1024.png"));
        }

        public ObservableCollection<Service> Services
        {
            get { return services; }
        }
    }
}
