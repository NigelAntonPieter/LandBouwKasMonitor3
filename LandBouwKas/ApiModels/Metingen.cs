using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandBouwKas.ApiModels
{
    public class Metingen
    {
        public DateTime meetdatum {  get; set; }
        public List<Zone> zones { get; set; }
    }
}
