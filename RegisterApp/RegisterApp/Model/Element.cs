using Android.Widget;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace RegisterApp.Model
{
    public class Element
    {
        private bool mandatory;
        private List<string> values;
        private string type;

        public Element(bool mandatory, List<string> values, string type)
        {
            this.Mandatory = mandatory;
            this.Type = type;
            this.Values = values; 
        }

        public bool Mandatory { get => mandatory; set => mandatory = value; }
        public List<string> Values { get => values; set => values = value; }
        public string Type { get => type; set => type = value; }
    }
}
