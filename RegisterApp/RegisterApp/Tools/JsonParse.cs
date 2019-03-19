using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using RegisterApp.Model;

namespace RegisterApp.Tools
{
    public class JsonParse
    {

        public static List<Service> ParseJson(string json)
        {
            if (!string.IsNullOrEmpty(json))
            {
                List<Service> services = new List<Service>();
                dynamic objson = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
                foreach(var service in objson.services)
                {
                    Service newService = new Service((string)service.title);
                    foreach (var element in service.elements)
                    {
                        if (((string)element.section).Equals("title"))
                        {
                            newService.Logo = element.value[0];
                        }
                        else
                        {
                            Section section = (from sect in newService.Sections where sect.Name.Equals(element.section) select sect).FirstOrDefault();
                            if (section != null)
                            {
                                int index = newService.Sections.IndexOf(section);
                                newService.Sections[index].Elements.Add(new Element((bool)element.mandatory, (List<string>)element.value, (string)element.type));
                            }
                            else
                            {
                                Section newSection = new Section((string)element.section);
                                List<string> values = new List<string>();
                                foreach (var val in element.value)
                                {
                                    values.Add((string)val);
                                }
                                newSection.Elements.Add(new Element((bool)element.mandatory, values, (string)element.type));
                                newService.Sections.Add(newSection);
                            }
                        }
                    }
                    newService.Formulaire = new Formulaire(newService.Sections.ToList());
                    services.Add(newService);  
                }
                return services;
            }
            else
            {
                return null;
            }

        }
    }
}
