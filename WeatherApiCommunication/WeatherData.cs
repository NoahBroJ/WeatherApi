using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApiCommunication
{
    public class WeatherData
    {
        private string name;
        private string temp;

        public string Name { get => name; }
        public string Temp { get => temp; }

        public WeatherData(string name, Dictionary<string, double> main)
        {
            this.name = name;
            temp = main["temp"] - 273.15 + " °C";
        }
    }
}
