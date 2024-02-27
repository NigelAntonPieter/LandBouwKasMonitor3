using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandBouwKas.ApiModels
{
    internal class Gewas
    {
        public int gewasId { get; set; }
        public string gewasNaam { get; set; }
        public Temperatuur temperatuur { get; set; }
        public Vochtigheid vochtigheid { get; set; }
        public Bodemgezondheid bodemgezondheid { get; set; }
        public Zonlicht zonlicht { get; set; }

    }
}
