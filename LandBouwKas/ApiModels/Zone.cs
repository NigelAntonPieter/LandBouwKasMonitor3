using LandBouwKas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandBouwKas.ApiModels
{
    internal class Zone
    {
        public int id { get; set; }
        public string zoneNaam { get; set; }
        public List<Gewas> gewassen {  get; set; }
    }
}
