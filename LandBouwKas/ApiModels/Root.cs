using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandBouwKas.ApiModels
{
    public class Root
    {
        public Record record { get; set; }
        public List<Gewas> gewassen { get; set; }
    }
}
